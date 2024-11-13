using UnityEngine;
using VRC.SDKBase;
using UnityEngine.UI;

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using UnityEditor;
using System.IO;
#endif

namespace io.github.Azukimochi
{

    public class Generator : MonoBehaviour, IEditorOnly
    {
        public Button Template;
        public string DataURL = "https://vrc-ta-hub.com/api/v1/community/";
    }
     
#if UNITY_EDITOR

    [CustomEditor(typeof(Generator))]
    internal sealed class GeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Run"))
            {
                Run(target as Generator);
            }
        }

        public enum Week
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Other,
        }

        private static void Run(Generator generator)
        {
            using var source = new CancellationTokenSource();
            source.CancelAfter(TimeSpan.FromSeconds(5));
            using var client = new HttpClient();
            using var response = client.GetAsync(generator.DataURL, source.Token).Result;
            var text = response.Content.ReadAsStringAsync().Result;

            var datas = JsonConvert.DeserializeObject<Data[]>(text);
            Undo.SetCurrentGroupName("TaA Update");
            var idx = Undo.GetCurrentGroup();
            var container = generator.Template.transform.parent;
            foreach (Transform item in container.transform)
            {
                if (item == container || item == generator.Template.transform)
                    continue;
                Debug.LogError(item);
                Undo.DestroyObjectImmediate(item.gameObject);
            }
            var weeks = new[] { ("Sun", Week.Sunday), ("Mon", Week.Monday), ("Tue", Week.Tuesday), ("Wed", Week.Wednesday), ("Thu", Week.Thursday), ("Fri", Week.Friday), ("Sat", Week.Saturday), ("Other", Week.Other) };

            List<(GameObject Object, Week Week, string[] Tags)> objects = new();
            foreach (var data in datas.OrderBy(x => x.ID))
            {
                var newObj = GameObject.Instantiate(generator.Template.gameObject, generator.Template.transform.parent);
                Undo.RegisterCreatedObjectUndo(newObj, "");

                newObj.SetActive(true);
                newObj.name = data.Name;
                newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(715.6f, 0f);
                newObj.GetComponentInChildren<Text>().text = $"{DateTime.ParseExact(data.StartTime,"HH:mm:ss", null):HH:mm}{data.Frequency}\n{data.Name}\n主催・副主催：{data.Organizers}";
                newObj.GetComponentInChildren<Image>().color = data.Tags.Contains("tech", StringComparer.OrdinalIgnoreCase) ? new Color(0.85f, 0.95f, 1.0f) : new Color(0.95f, 0.95f, 0.8f);
                var button = newObj.GetComponent<Button>();
                var so = new SerializedObject(button);
                so.FindProperty("m_OnClick.m_PersistentCalls.m_Calls.Array.data[0].m_Arguments.m_StringArgument").stringValue = $"OnClicked_{data.ID}";
                so.ApplyModifiedProperties();

                var week = weeks.FirstOrDefault(x => data.Weekdays.Contains(x.Item1)).Item2;

                objects.Add((newObj, week, data.Tags));
            }

            {
                var system = generator.GetComponent<GatheringListSystem>();
                system.Buttons = objects.Select(x => x.Object).ToArray();
                system.Buttons_Sun = objects.Where(x => x.Week == Week.Sunday).Select(x => x.Object).ToArray();
                system.Buttons_Mon = objects.Where(x => x.Week == Week.Monday).Select(x => x.Object).ToArray();
                system.Buttons_Tue = objects.Where(x => x.Week == Week.Tuesday).Select(x => x.Object).ToArray();
                system.Buttons_Wed = objects.Where(x => x.Week == Week.Wednesday).Select(x => x.Object).ToArray();
                system.Buttons_Thu = objects.Where(x => x.Week == Week.Thursday).Select(x => x.Object).ToArray();
                system.Buttons_Fri = objects.Where(x => x.Week == Week.Friday).Select(x => x.Object).ToArray();
                system.Buttons_Sat = objects.Where(x => x.Week == Week.Saturday).Select(x => x.Object).ToArray();
                system.Buttons_Other = objects.Where(x => x.Week == Week.Other).Select(x => x.Object).ToArray();
                system.Buttons_Academic = objects.Where(x => x.Tags.Contains("academic", StringComparer.OrdinalIgnoreCase)).Select(x => x.Object).ToArray();
                system.Buttons_Tech = objects.Where(x => x.Tags.Contains("tech", StringComparer.OrdinalIgnoreCase)).Select(x => x.Object).ToArray();
                EditorUtility.SetDirty(system);
            }

            using var fs = File.CreateText(AssetDatabase.GUIDToAssetPath("3bd50020951c40a4f8929e52fbb71cbf"));
            fs.Write(@$"// <auto-generated>
using System;
using System.Data;
using UdonSharp;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VRC.SDK3.Data;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon;

namespace io.github.Azukimochi
{{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class GatheringListSystem : UdonSharpBehaviour
    {{
        [SerializeField] private InputField _joinInfo;
        [SerializeField] private InputField _Discord;
        [SerializeField] private InputField _X;
        [SerializeField] private InputField _Tag;
        [SerializeField] private Text _Description;
        [SerializeField] private Toggle _toggle_Tech;
        [SerializeField] private Toggle _toggle_Academic;

        [SerializeField] private GameObject _creditPanel;

        [SerializeField] public Color _defaultColor = Color.black;
        [SerializeField] public Color _selectedColor = Color.gray;
        [SerializeField] public Color _todayColor = new Color(0.3f, 0.3f, 0.3f);

        public void _VketStart()
        {{
            _currentWeek = (Week)(DateTime.Now.DayOfWeek + 1);
            Reflesh();
        }}
    
        public void ToggleCredit()
        {{
            _creditPanel.SetActive(!_creditPanel.activeSelf);
        }}

        public void FilteringByAcademic()
        {{
            Reflesh();
        }}

        public void FilteringByTech()
        {{
            Reflesh();
        }}

        public void Reflesh()
        {{
            var buttons = Buttons;
            foreach(var button in buttons)
                button.SetActive(false);
            foreach(var button in WeekButtons)
                button.GetComponentInChildren<Button>().image.color = _defaultColor;
            WeekButtons[(int)DateTime.Now.DayOfWeek].GetComponentInChildren<Button>().image.color = _todayColor;
            {string.Join(" ", weeks.Select((x, i) => $"if (_currentWeek == Week.{x.Item2}) {{ buttons = Buttons_{x.Item1}; WeekButtons[{i}].GetComponentInChildren<Button>().image.color = _selectedColor; }}"))}
            foreach(var button in buttons)
            {{
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(715.6f, 110.01f);
                button.SetActive(true);
            }}
            
            if (!_toggle_Tech.isOn)
                foreach (var x in Buttons_Tech)
                {{
                    x.SetActive(false);
                }}
            
            if (!_toggle_Academic.isOn)
                foreach (var x in Buttons_Academic)
                {{
                    x.SetActive(false);
                }}
        }}

        [SerializeField] public GameObject[] WeekButtons;
        [SerializeField] public GameObject[] Buttons;
        [SerializeField] public GameObject[] Buttons_Academic;
        [SerializeField] public GameObject[] Buttons_Tech;
{string.Join("\n", weeks.Select(x => $"        " +
            $"[SerializeField] public GameObject[] Buttons_{x.Item1};"))}

        private Week _currentWeek = Week.None;

{string.Join("\n", weeks.Select(week => $"        " +
            $"public void OnClicked_{week.Item1}() {{" +
            $"_currentWeek = Week.{week.Item2};" +
            $"Reflesh();" +
            $"}}"))}

{string.Join("\n", datas.Select(data => $"        " +
            $"public void OnClicked_{data.ID}() {{" +
            $"_joinInfo.text = @\"{data.Organizers}\";" +
            $"_Discord.text = @\"{data.Discord}\";" +
            $"_X.text = @\"{data.SNSUrl}\";" +
            $"_Tag.text = @\"{data.Hashtag}\";" +
            $"_Description.text = @\"{data.Description.Replace("\"", "\"\"")}\";" +
            $"}}"))}
    }}

    public enum Week
    {{
        None, 
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Other,
    }} 
}}
");

            Undo.CollapseUndoOperations(idx);
        }

        public record Data
        {
            [JsonProperty("id")]
            public int ID;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("created_at")]
            public string CreatedAt;

            [JsonProperty("updated_at")]
            public string UpdatedAt;

            [JsonProperty("start_time")]
            public string StartTime;

            [JsonProperty("duration")]
            public int Duration;

            [JsonProperty("weekdays")]
            public string[] Weekdays;

            [JsonProperty("frequency")]
            public string Frequency;

            [JsonProperty("organizers")]
            public string Organizers;

            [JsonProperty("group_url")]
            public string GroupUrl;

            [JsonProperty("organizer_url")]
            public string OrganizerUrl;

            [JsonProperty("sns_url")]
            public string SNSUrl;

            [JsonProperty("discord")]
            public string Discord;

            [JsonProperty("twitter_hashtag")]
            public string Hashtag;

            [JsonProperty("poster_image")]
            public string PosterImage;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("platform")]
            public string Platform;

            [JsonProperty("tags")]
            public string[] Tags;
        }
    }


#endif
}