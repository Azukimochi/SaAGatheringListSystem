// <auto-generated>
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
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class GatheringListSystem : UdonSharpBehaviour
    {
        [SerializeField] private InputField _joinInfo;
        [SerializeField] private InputField _Discord;
        [SerializeField] private InputField _X;
        [SerializeField] private InputField _Tag;
        [SerializeField] private Text _Description;
        [SerializeField] private Toggle _toggle_Tech;
        [SerializeField] private Toggle _toggle_Academic;

        [SerializeField] private GameObject _creditPanelScroolView;

        [SerializeField] public Color _defaultColor = Color.black;
        [SerializeField] public Color _selectedColor = Color.gray;
        [SerializeField] public Color _todayColor = new Color(0.3f, 0.3f, 0.3f);

        public void _VketOnBoothEnter()
        {
                _currentWeek = Week.None;
                Reflesh();
        }
    
        public void ToggleCredit()
        {
            _creditPanelScroolView.SetActive(!_creditPanelScroolView.activeSelf);
            _creditPanelScroolView.GetComponentInChildren<Text>().fontSize = 11;
        }

        public void FilteringByAcademic()
        {
            Reflesh();
        }

        public void FilteringByTech()
        {
            Reflesh();
        }

        public void Reflesh()
        {
            var buttons = Buttons;
            foreach(var button in buttons)
                button.SetActive(false);
            foreach(var button in WeekButtons)
                button.GetComponentInChildren<Button>().image.color = _defaultColor;
            WeekButtons[(int)DateTime.Now.DayOfWeek].GetComponentInChildren<Button>().image.color = _todayColor;
            
            if (_currentWeek == Week.Sunday) { buttons = Buttons_Sun; WeekButtons[0].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Monday) { buttons = Buttons_Mon; WeekButtons[1].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Tuesday) { buttons = Buttons_Tue; WeekButtons[2].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Wednesday) { buttons = Buttons_Wed; WeekButtons[3].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Thursday) { buttons = Buttons_Thu; WeekButtons[4].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Friday) { buttons = Buttons_Fri; WeekButtons[5].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Saturday) { buttons = Buttons_Sat; WeekButtons[6].GetComponentInChildren<Button>().image.color = _selectedColor; } 
            if (_currentWeek == Week.Other) { buttons = Buttons_Other; WeekButtons[7].GetComponentInChildren<Button>().image.color = _selectedColor; }
            foreach(var button in buttons)
            {
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(715.6f, 110.01f);
                button.SetActive(true);
            }
            
            if (!_toggle_Tech.isOn)
                foreach (var x in Buttons_Tech)
                {
                    x.SetActive(false);
                }
            
            if (!_toggle_Academic.isOn)
                foreach (var x in Buttons_Academic)
                {
                    x.SetActive(false);
                }
        }

        [SerializeField] public GameObject[] WeekButtons;
        [SerializeField] public GameObject[] Buttons;
        [SerializeField] public GameObject[] Buttons_Academic;
        [SerializeField] public GameObject[] Buttons_Tech;
        [SerializeField] public GameObject[] Buttons_Sun;
        [SerializeField] public GameObject[] Buttons_Mon;
        [SerializeField] public GameObject[] Buttons_Tue;
        [SerializeField] public GameObject[] Buttons_Wed;
        [SerializeField] public GameObject[] Buttons_Thu;
        [SerializeField] public GameObject[] Buttons_Fri;
        [SerializeField] public GameObject[] Buttons_Sat;
        [SerializeField] public GameObject[] Buttons_Other;

        private Week _currentWeek = Week.None;

        public void OnClicked_Sun() {_currentWeek = Week.Sunday;Reflesh();}
        public void OnClicked_Mon() {_currentWeek = Week.Monday;Reflesh();}
        public void OnClicked_Tue() {_currentWeek = Week.Tuesday;Reflesh();}
        public void OnClicked_Wed() {_currentWeek = Week.Wednesday;Reflesh();}
        public void OnClicked_Thu() {_currentWeek = Week.Thursday;Reflesh();}
        public void OnClicked_Fri() {_currentWeek = Week.Friday;Reflesh();}
        public void OnClicked_Sat() {_currentWeek = Week.Saturday;Reflesh();}
        public void OnClicked_Other() {_currentWeek = Week.Other;Reflesh();}

        public void OnClicked_59() {_joinInfo.text = @"nisshi-dev｜にっし";_Discord.text = @"https://discord.gg/umnscaPNcy";_X.text = @"https://x.com/vrwebtechorg";_Tag.text = @"#Web技術集会";_Description.text = @"バーチャルでWeb技術について気軽に話す/聞くことができる技術系集会イベントです。

Web技術勉強中だよ！って初心者の方から、Web技術オタクの方まで、ぜひお気軽にご参加ください。";}
        public void OnClicked_58() {_joinInfo.text = @"DOVE/ディー";_Discord.text = @"";_X.text = @"https://x.com/DovetyNow";_Tag.text = @"#VRC技術系同人誌紹介集会";_Description.text = @"最初は主催から技術系同人誌イベントとおすすめ本をLT。以降は同人誌推薦も含めた雑談に移ります。同人誌全般が好きな方もお気軽にご参加ください。見るだけ、途中入退場自由。各自ブラウザを確認できる環境を推奨。参加は主催にJOIN。";}
        public void OnClicked_57() {_joinInfo.text = @"ごんびぃー";_Discord.text = @"";_X.text = @"https://x.com/GONBEEE_project";_Tag.text = @"#XR開発者集会";_Description.text = @"毎月たぶん第4月曜日開催！XRコンテンツの開発者・関係者をお呼びして、XRコンテンツ制作について登壇・議論するイベントです。
現実世界のXRエンジニアと、技術系VRChatterの架け橋となるようなイベント、、、にしていきたいな！";}
        public void OnClicked_56() {_joinInfo.text = @"KAGU3・いとじゅん";_Discord.text = @"https://discord.gg/UGCjerre";_X.text = @"https://x.com/Kagu3_IT";_Tag.text = @"#VRC_ITキャリア集会";_Description.text = @"ITエンジニアやITエンジニアになりたい人が、今後のキャリア形成について相談⁄雑談する集会です。
学生・非エンジニアでもOK。ITエンジニア的な雑談をしにくるでもOK。

たまにキャリアに関連するLT会（講演会）をします。";}
        public void OnClicked_54() {_joinInfo.text = @"@kumama_nui";_Discord.text = @"http://discord.gg/7EReqAK5Tk";_X.text = @"https://x.com/kumama_nui";_Tag.text = @"#CTF集会";_Description.text = @"CTFの集会です！セキュリティの情報共有を行うことを目的とした集会です！初心者、なんもわからんも大歓迎です。";}
        public void OnClicked_53() {_joinInfo.text = @"MisohitoNakai";_Discord.text = @"https://discord.gg/7BSnUpwu7b";_X.text = @"https://x.com/XENMVR";_Tag.text = @"#VRC微分音集会";_Description.text = @"毎月最初の金曜日に開催。微分音・Xenharmonicといった西洋音楽の12平均律を飛び出した音楽理論や調律理論、関連技術についての交流会です。
集会では不定期でLTやお悩み相談も開催予定。
音楽に関わりのあるすべての方々に、斬新で画期的な新時代の音楽のアプローチを提唱いたします。";}
        public void OnClicked_52() {_joinInfo.text = @"suusanex（須藤）・mishizaki";_Discord.text = @"";_X.text = @"https://join.slack.com/t/csharp-tokyo/shared_invite/enQtNjY5MjU1ODEyMjkzLWI1MWNhNTQzYzJmZWJmYThhZTRiNTgzNWIwMmYxZmEzZDg0NThhNzZiNDc4MTkyNTMyMzk4ZDM1MWUwZGZkNjg";_Tag.text = @"#csharptokyo";_Description.text = @"C# Tokyo とは、C#に関するオフラインイベントを主に東京で開催している団体です。TeamsやYoutube等でのオンラインイベントもやっています。

もくもく作業したり、会話したり、あるいはメタバース自体を色々と試してみたりなど、その日に集まったメンバーのノリでゆるめにやっています。
扱う話題も厳密に C# だけに限定はせず、周辺技術や C# とあわせて使われる技術などコミュニティメンバーが関心を持ちそうなことなら何でもありです。
コミュニティメンバーがメタバースに慣れてもらえたらというのはもちろん、メタバースからもC# Tokyoに興味を持ってもらえたら嬉しいです。

ぜひ気軽に参加してみてください！";}
        public void OnClicked_51() {_joinInfo.text = @"HOZUKI Roy";_Discord.text = @"https://t.co/ChtAY5mF2G";_X.text = @"https://note.com/hozukiroy/m/mef4485e8350c";_Tag.text = @"#MEDJS";_Description.text = @"医学論文のAIまとめ→医師が軽く付け足し・修正→VRChatのイベントで議論しながら修正されます。
https://note.com/hozukiroy/m/mef4485e8350c";}
        public void OnClicked_50() {_joinInfo.text = @"honahuku, bootjp";_Discord.text = @"https://t.co/DiVOz58oZO";_X.text = @"https://x.com/distributesys";_Tag.text = @"#分散システム集会";_Description.text = @"主にVRChat上で分散システムに関する集会を行っています";}
        public void OnClicked_49() {_joinInfo.text = @"黒洞ひかり";_Discord.text = @"";_X.text = @"https://x.com/kokudo_hikari";_Tag.text = @"#VRCブラックホール集会";_Description.text = @"宇宙最強の常識外れの天体「ブラックホール」
その魅力に引き寄せられたものが集う集会！

天文学や宇宙物理学やSFなど宇宙に関する幅広い話題について語り合う雑談系イベントです！宇宙や物理学について全く詳しくなくてもOK！初心者大歓迎です！

ブラックホールで焼肉したりマシュマロ焼けるギミックがあります";}
        public void OnClicked_47() {_joinInfo.text = @"jumius, Sho Hase, faruco10032, _kondo";_Discord.text = @"https://discord.gg/bynAkPg3Cs";_X.text = @"";_Tag.text = @"#VR研究Cafe";_Description.text = @"VR研究について雑談する集会です！広くVR研究に関連する技術やトピックについてもお話しています。";}
        public void OnClicked_46() {_joinInfo.text = @"MagicHour";_Discord.text = @"https://sites.google.com/view/vr-academia/access?authuser=0";_X.text = @"";_Tag.text = @"#VRアカデミア";_Description.text = @"開催曜日: 土日、あるいは祝日のことが多い
開催時間: 13時開始、あるいは21時開始のことが多い

「VRアカデミア」はなんとなくバーチャルっぽい学術好きな人たちによる集いです。そこでは毎月、自身が興味があるアカデミックな話題をぐだぐだお話する集会を開催しています！公式ウェブページや交流用のdiscordサーバーもありますので、ぜひ覗いてみてください〜";}
        public void OnClicked_44() {_joinInfo.text = @"主催:あどず_クライマー、副主催:Mukû5364（むくう）";_Discord.text = @"https://discord.gg/dXYXB3EcSN";_X.text = @"https://x.com/VRC_insect_";_Tag.text = @"#VRC昆虫集会";_Description.text = @"開催曜日: 金曜日

開催時間: 21:00 - 22:00 or 20:00~22:00

開催周期:春から秋は月1回 、冬は毎週

採集や昆虫を話したりする集会";}
        public void OnClicked_42() {_joinInfo.text = @"るいざ・しゃーろっと";_Discord.text = @"";_X.text = @"";_Tag.text = @"#VRC歴史集会";_Description.text = @"";}
        public void OnClicked_41() {_joinInfo.text = @"Kuretan・Gipi_3";_Discord.text = @"https://discord.com/invite/2JW4kudS3u";_X.text = @"";_Tag.text = @"#社会科学集会";_Description.text = @"";}
        public void OnClicked_40() {_joinInfo.text = @"enetto";_Discord.text = @"";_X.text = @"";_Tag.text = @"#黒猫雑学カフェ";_Description.text = @"意見交換と知見の共有を行う対話イベントです。";}
        public void OnClicked_39() {_joinInfo.text = @"Alnote_";_Discord.text = @"https://discord.gg/8ErchaWwXN";_X.text = @"https://x.com/Alnote_";_Tag.text = @"#論文紹介集会";_Description.text = @"隔週月曜日21:00から、主催の趣味的論文紹介をおこなっています。
範囲はVR系、画像処理系を中心に、幅広く紹介しています。";}
        public void OnClicked_38() {_joinInfo.text = @"VR酔い訓練集会運営・HOZUKI Roy";_Discord.text = @"https://t.co/ChtAY5mF2G";_X.text = @"https://www.fanbox.cc/@vrtrain";_Tag.text = @"#VR酔い訓練集会";_Description.text = @"26億人のVR酔い人類を解放したい集い。";}
        public void OnClicked_37() {_joinInfo.text = @"Prolin";_Discord.text = @"https://discord.com/invite/hYGVkeraKu";_X.text = @"";_Tag.text = @"#化学のおはなし会";_Description.text = @"";}
        public void OnClicked_36() {_joinInfo.text = @"cleantted";_Discord.text = @"https://discord.gg/VDQMrAb";_X.text = @"";_Tag.text = @"#VRC競プロ部";_Description.text = @"「VRC競プロ部」は、競技プログラミング（競プロ）をしている人が交流したり情報交換をする場です。

「VRC競プロ部」では、AtCoderが開催する「AtCoder Beginner Contest」(土曜 or 日曜 21:00-22:40)が終わったあと、
当日23:00からコンテストの参加者で振り返りと解説をする「ABC感想会」を開催しています。
「競プロを楽しく継続できる場」を目指して開催しているため、参加する人の状況に合わせて話をする内容を変えていますので、
初めてコンテストに参加した方も歓迎しています！
他にも、部員内で勉強会や作問が不定期に企画され開催されています。
競プロやってる方はもちろん、興味があって初めたい方、一緒に競プロをやる仲間がほしい方の参加を歓迎しています！";}
        public void OnClicked_35() {_joinInfo.text = @"kurone-kito";_Discord.text = @"https://discord.gg/hM5dpGaWgB";_X.text = @"";_Tag.text = @"#UIUXデザイン集会";_Description.text = @"Webで！ゲームで！業務システムで！皆さんの経験したクソUI・神UIなお話を飲み会感覚でお気軽にお聞かせください！";}
        public void OnClicked_34() {_joinInfo.text = @"yank.nvim・See2et";_Discord.text = @"https://discord.gg/GrXaGJCmut";_X.text = @"";_Tag.text = @"#Vimmer集会";_Description.text = @"およそ20年以上前に開発され、今でも多くのエンジニアが愛用しているテキストエディタVim。

幅広い環境で使うことができ、キーボードでのモードを切り替えながらの操作が特徴。

そんなテキストエディタVimのユーザーはときにVimmerと呼ばれます。そんなVimmerが集まるのがVimmer集会です。

Vimmer集会では、主にVimユーザー間での設定やプラグイン、その他の情報交換や雑談を主にしています。

また、Vimやそれに関するトピックについてのLTなども行っています。Vimを使っている、あるいはVimに少しでも興味がある方はぜひともお越しください！もしEmacsを使っていた場合は…どうなるかわかってますよね？";}
        public void OnClicked_32() {_joinInfo.text = @"NekoDOS・あんでぃ・Earl_Klutz";_Discord.text = @"https://discord.gg/7bKUrQecjm";_X.text = @"https://x.com/ManagementMeet";_Tag.text = @"#マネジメント集会";_Description.text = @"マネジメント集会は、「人間、誰しもがマネージャーだ！」という標語の元、様々な管理にかかわるトピックについて登壇発表会を行った後に自由交流という流れで運営している集会です。
現役経営者のねこどす、ガチ講師あんでぃ、企業参謀Kultzとライフプランがエグいmadaoが運営しながら、様々な方の登壇を受け付けております。
是非、お気軽にお越しください。
なお、アーカイブは、内容の価値などを鑑みた諸々の事情により基本公開しておりません。";}
        public void OnClicked_31() {_joinInfo.text = @"Nunu_3060";_Discord.text = @"";_X.text = @"";_Tag.text = @"";_Description.text = @"シェーダーに興味がある人で集まってお話や交流を行います。";}
        public void OnClicked_30() {_joinInfo.text = @"〆・えー";_Discord.text = @"https://discord.gg/5KJrhHMBGN";_X.text = @"";_Tag.text = @"#ITインフラ集会";_Description.text = @"インターネットやWebサービスを使っていて、普段意識することのないインフラ。
でもじつは、VRChatにもインフラの専門家が少なくない人数います。

インフラ集会では、インフラに興味を持った初心者の疑問解決から同業者のディープな情報交換まで、インフラについての話題を幅広く扱っています。通信、サーバーといった物理層の話題ならお手の物なユーザーと出会えるかもしれません。

土曜日の開催なのでそのまま朝まで盛り上がることも多々あります。

自宅にサーバーを置いているマニアックな方だけでなく、もちろん初心者の方も大歓迎！
この集会がきっかけで初めてサーバーを立ててみた人が何人もいます。

ITインフラに関するハードの話から環境構築、運用の話、悩んでいる問題の解決策、最新の技術や、使っている技術について、一緒に語り合いましょう！

興味がある方ならどなたでも歓迎ですので、ぜひお気軽にご参加ください。";}
        public void OnClicked_29() {_joinInfo.text = @"かるだん";_Discord.text = @"https://discord.gg/4jBzMFashh";_X.text = @"";_Tag.text = @"#バックエンド集会";_Description.text = @"";}
        public void OnClicked_28() {_joinInfo.text = @"garugaki";_Discord.text = @"https://vrchat.com/home/user/usr_163397f0-80d9-4d2d-821a-312ec75fd80c";_X.text = @"";_Tag.text = @"";_Description.text = @"「VRホビーロボット集会」は2020年10月より毎月開催しているモノづくり系集会で、モノづくりに興味のある方は誰でも歓迎のオープンな集会です。直近の技術系話題について雑談したり、技術系イベントや作品の進捗報告等など自由に交流しています。また、世界最大のVRイベントVirtual Market（通称Vket）に合わせて年2回「ニソコンVR」というVR上のロボコンを開催しています。このニソコンVRの優勝者にはリアルでの二足歩行ロボットコンテスト「ROBO-ONE」シード権が賞品として贈られるほか、御協賛頂いた企業より賞品が入賞者に送られるものとなっております。
その他、Vketへの出展、リアルのモノづくり系イベントMaker Faire Tokyo等々、VRとリアルにまたがった活動を行っています。
集会は毎月最終土曜21時より開催。フレプラでインスタンスを立てていますので、主催者「garugaki」にJOINしてください。たまに日付が変わることもありますので最新情報はツイッター@nisoconVRをチェックをお願いします。";}
        public void OnClicked_27() {_joinInfo.text = @"Mimi_fbx";_Discord.text = @"";_X.text = @"";_Tag.text = @"";_Description.text = @"この集会はBlenderを用いた創作活動をされている方や興味のある方を対象とした雑談メインの集会です！

開催後30分で集合写真撮影と連絡事項の共有を行い,以降自由解散となりますので10時までのイベントに参加したい方も間に合います.
アフターとして残って話される方も居ますが,イベント開催時と内容は変わりませんので写真撮影後も気兼ねなく参加できます.

イベント内では雑談から進捗報告,質問や成果物の自慢など様々な話題で行っています.
3DCG方面に明るい方に来ていただいたり,主催の趣味でBlenderから逸れ,3DCGの全般的な雑談をすることもありますのでBlenderは使っていないけど...といった方も楽しめます！

創作のための刺激がほしい方や,第一歩を踏み出したい方にオススメです！";}
        public void OnClicked_26() {_joinInfo.text = @"Tak1123";_Discord.text = @"https://t.co/bZ70vyhL14";_X.text = @"";_Tag.text = @"#VRC株式投資座談会";_Description.text = @"株式投資、投資信託、FX、暗号通貨、先物オプションなどの金融系投資に興味あるVRchat民が集まり交流をするイベントです(隔週土曜日21:00-)。2021年3月からイベントをスタートし、３年間継続しています。投資初心者から経験者まで幅広い層が参加し、個人投資家としてレベルアップできるように取り組んでいます。

★イベント前半(21:10-21:35)　
今週の市況分析や個人投資家が知っておいたほうがよい知識について主催者がLTを行います。

★イベント後半(21:35-21:55)
日本株投資、米国株投資などの分野に分かれ座談会を行います。

★最後に写真撮影(21:55-22:00)を行いイベントCloseの流れです。


ーーー注意事項-----
・個別株等の情報が出てきますが、投資を推奨しているものではありません。投資の判断は自己責任でお願いします。
・投資商品等の宣伝、営業、勧誘などの行為はご遠慮ください。
・投資は自己責任でお願いします。投資にかかわるいかなる損害において主催者、参加者は責任をとりません。
・入退場自由。";}
        public void OnClicked_25() {_joinInfo.text = @"digiponta";_Discord.text = @"https://t.co/aLMqxTKrAc";_X.text = @"";_Tag.text = @"#量子力学雑談会";_Description.text = @"量子力学に関連するyoutube動画を参加者で聴講し、雑談する集会です。";}
        public void OnClicked_23() {_joinInfo.text = @"破天荒解";_Discord.text = @"";_X.text = @"";_Tag.text = @"#BlenderUnity交流会";_Description.text = @"自作アバター、アクセサリー、衣装などの制作者同士で交流を深めたい方や雑談したい方！！ 改変アバターや自作アバターで趣味が合う人を探したい方！！";}
        public void OnClicked_22() {_joinInfo.text = @"慕狼ゆに";_Discord.text = @"https://discord.gg/zaTjFtDRP7";_X.text = @"";_Tag.text = @"#VRCエンジニア作業飲み集会";_Description.text = @"技術触ってる人が集まって、お酒飲みながら作業したり、ワイワイしたりする集会です! 毎週開催していて、VRChatとclusterで交互に開催しています。イベントの最後には、進捗共有会を開催しています。

エンジニア作業のみ集会の進捗共有会は、飲んだお酒も進捗に数えて良いゆるい共有会なので、誰でも気軽に自分の話したいことを話ししてOKです！（制限時間1分で床が抜けるようにしているので強制的にオチがつく！安心！）Discord鯖も用意していて、日曜日の朝にはもくもく会が開催されていたり、みんなでワイワイしています。

VRChatだとPCスペックが足りない、MacBookしか持っていないというエンジニアの人も気軽に参加できるように、隔週でcluster開催もしています。";}
        public void OnClicked_21() {_joinInfo.text = @"kiyone";_Discord.text = @"https://discord.gg/jfQ3gdBd4N";_X.text = @"";_Tag.text = @"";_Description.text = @"";}
        public void OnClicked_20() {_joinInfo.text = @"のりちゃん";_Discord.text = @"https://discord.gg/k8FPwtZ4fs";_X.text = @"https://x.com/noricha_vr";_Tag.text = @"#OSS集会";_Description.text = @"OSS（オープンソースソフトウェア）集会
VRChat用に開発しているシステムのソースコードをみんなで眺めたり、デバッグしたり、意見を出し合う集会です。個人開発集会の跡地を利用するのでエンジニアがたくさん集まってます。
プログラミング好きの方はぜひ遊びに来てね(^^)v";}
        public void OnClicked_19() {_joinInfo.text = @"のりちゃん";_Discord.text = @"https://discord.gg/k8FPwtZ4fs";_X.text = @"https://x.com/noricha_vr";_Tag.text = @"#個人開発集会";_Description.text = @"個人開発にまつわる話でワイワイする集会です。
個人開発をやっている方も初めてみたい方も大歓迎！ 
企画・技術・マーケティング・保守・運用など 技術的なことに限らない幅広い分野を想定しています。 
個人開発に興味がある方はぜひ遊びに来てください！";}
        public void OnClicked_18() {_joinInfo.text = @"いそひまかん・ぶんちん";_Discord.text = @"https://discord.gg/U4GJPhuZ8S";_X.text = @"https://x.com/dsGathering_vrc";_Tag.text = @"#DS集会VRC";_Description.text = @"データサイエンティスト集会(以下DS集会)はVRChat内でデータサイエンティストやデータサイエンスに興味ある人、初心者が集まって交流する定期イベントです。隔週木曜21時から開催しており、時にはデータサイエンスにちなんだLT企画も行っています。

コロナウイルスの影響でリアルでのオフラインイベントが急減し、代わりにオンラインイベントが開催されるようになりました。しかしビデオ通話などでの交流会はやりとりがし辛く、それが理由に社外のDSとの交流が減ってはいないでしょうか？

そうした不便さから、さながらオフラインイベントのような雰囲気で交流できる場を目指し、先代が22年4月からDS集会が始まりました。

今ではVRChat内で唯一のデータサイエンス系コミュニティとして、多くの知識交流の場となっています。最近ではデータサイエンスだけでなくデータエンジニアリングや統計などのテーマでも交流されるようになりました。
「身近にデータサイエンスについて相談できる知り合いがいない」、「社外のDSと交流してみたい」といった方は、もしご興味ありましたらご参加をお待ちしております。";}
        public void OnClicked_16() {_joinInfo.text = @"CHIHAYA⛩ちはや＆bd_";_Discord.text = @"https://discord.gg/7hjZwpWdUW";_X.text = @"https://x.com/wakaran_vrc";_Tag.text = @"#アバター改変なんもわからん集会";_Description.text = @"イベントは、隔週水曜日に開催され、講師による講演会と何でも質問できる交流会を交互に行っています。講師の方々は、プログラマーや経験豊富なクリエイターであり、彼らの知識と経験を共有することで、皆さんのスキル向上に役立てています。イベントはグループインスタンスで行われ、2つのインスタンスで同時に進行します。講演会の後は、本イベントのメインとなる「アバター改変なんもわからん交流会」に移り、参加者同士が自由に交流し、疑問点を相談し合います。この交流会は、温かい雰囲気の中で、初心者も安心して参加できる場です。";}
        public void OnClicked_15() {_joinInfo.text = @"げそん≺GesonAnko≻";_Discord.text = @"https://discord.gg/6rQ2PZTDqa";_X.text = @"";_Tag.text = @"#ML集会";_Description.text = @"機械学習（AI）関連でお話しつつ、LTなどをする情報共有会です！
最近のML界隈は成長が速すぎるからみんなで追おう！という思いから生まれました。
現在は自律動作するAIアバターがいたりして... あなたの目の前にいる存在は人ではないかもしれません。 
Discordもあるのでそちらもぜひ。";}
        public void OnClicked_14() {_joinInfo.text = @"digiponta";_Discord.text = @"https://discord.com/invite/25A5q7mDtk";_X.text = @"";_Tag.text = @"#VRC電子工作友の会";_Description.text = @"電子工作の関わる雑談や、自作品紹介、Youtube動画を、皆で観ること。";}
        public void OnClicked_12() {_joinInfo.text = @"みゅーとん";_Discord.text = @"";_X.text = @"https://bsky.app/profile/mewton.jp";_Tag.text = @"#VRChatフロントエンドエンジニア集会";_Description.text = @"# 概要

WEB フロントエンドの技術領域について, 興味関心のある人で集まりましょう。

仕事の愚痴, 知見の共有など, 話題は何でもOKです！

 

また, 参加条件として, 開発経験の有無は問いません。

これからフロントエンド開発を経験してみたい人も, ぜひご参加ください！

# 詳細
## スケジュール

毎月 第 3 火曜日 22:00 ~

## タイムテーブル
 
- 22:00 .. 会場オープン
- 22:50 .. 記念撮影
- 23:00 .. LT
- LT 終了後 .. 自由解散

## キーワード

以下のキーワードを本イベントはサポートしています. (主催が完全に把握していない技術も多数あります)
また, これに限らず, 類似の技術についてはサポート対象としています.

### 言語系

HTML, CSS, JavaScript, TypeScript, Ruby, Java, Perl, Rust, Kotlin, Elm, Flutter, PHP

### JS ライブラリ / フレームワーク系
 
jQuery, Angular, React, Vue.js, Solid.js, Svelte, Next.js, Nuxt, SvelteKit, SolidStart, qwik, fresh, Remix, Astro

### 非 JS フレームワーク系
 
Spring, Ruby on Rails, Rocket, Apache Struts, CakePHP, Hugo, jekyll

### ネイティブアプリ系

React Native, Electron, Tauri

### その他ライブラリ系

Browserify, Webpack, Vite, Rollup, ESBuild
jest, karma, power-assert, jasmine, vitest
playwright, selenuim, mabl, autify, testim

### CSS フレームワーク系
 
Bootstrap, TailwindCSS, Bruma

### ブラウザ系
 
Chromium, Firefox, Servo

### 概念系

a11y, e18e, SSR, CSR, SSG, ISR

# 参加方法

イベント会場は VRC Group ""WEB フロントエンド エンジニア集会"" の Group+ インスタンスで開かれます.
イベント参加前に, グループに参加するか, 主催の ""みゅーとん"" にフレンド申請を送ってください.

# その他
 
会場には sliden を設置しています.
LT したいネタがあれば, 23:00 からの LT タイムで時間を設けます.

事前にご相談ください.
 
また, 採用活動の一環として本イベントを利用することに制限を設けていません.
採用活動としてイベントを利用したい場合も, 事前にご相談ください.";}
        public void OnClicked_11() {_joinInfo.text = @"夜鍋ヨナ";_Discord.text = @"https://discord.gg/ZCnUCmncDK";_X.text = @"https://x.com/yonabeyona";_Tag.text = @"#CS集会 #VRC_CS集会";_Description.text = @"コンピュータサイエンスを、話したい！聞きたい！知識を共有したい！広くCSのお話したい人みんなあつまれー!!!!";}
        public void OnClicked_8() {_joinInfo.text = @"Nawashiro";_Discord.text = @"https://discord.gg/4NTwMMMw9P";_X.text = @"https://x.com/yineleyici";_Tag.text = @"#分散SNS集会";_Description.text = @"普段何気なく使っているSNS。でもその裏側には、様々な工夫や試みが隠されています。そして驚くべきことに、個人でSNSを運営して問題に取り組む人もいるのです。分散SNS集会は、分散SNSにちょっと興味がある人や利用者、運営者が集まって様々な知見を交換し、新しい技術や話題に触れたり、同じ話題や困難を分かち合い、より高めたり、楽しんだり、癒やされたりする場を作ることを目的にしています。あくまで一例ですが、・SNS上の安全のための取り組みについて・コンテンツの責任を誰が持つのか・毒性のあるコンテンツの生成を抑える構造が作れないか…などの話題を提案しています。SNSに関連するお話なら、UI/UXやインフラなども含めて幅広く歓迎しています。話題のMisskeyやBlueskyが気になるという方も、お気軽にご参加ください。";}
        public void OnClicked_7() {_joinInfo.text = @"そむにうむ＠森山";_Discord.text = @"https://discord.com/invite/M3996Mc";_X.text = @"https://x.com/Somnium";_Tag.text = @"";_Description.text = @"アバターのフィギュア化を始めをして、メタバース・アバター文化に関する様々なクリエイティブの可能性を語る集会です。
アバターフィギュアや制作物を作ってみたい人・興味のある人・VRChat初心者飲迎します。";}
        public void OnClicked_5() {_joinInfo.text = @"tanitta";_Discord.text = @"";_X.text = @"";_Tag.text = @"#VRCHoudini勉強会";_Description.text = @"VRChatで開催されているHoudiniについての勉強会です。Houdiniをまだよく知らない方から、実際に業務で使用している方まで幅広くご参加いただいています。";}
        public void OnClicked_4() {_joinInfo.text = @"彩瑞スピス";_Discord.text = @"https://discord.gg/KgMXYgZy8w";_X.text = @"";_Tag.text = @"#VRC脳波技術集会";_Description.text = @"VRC脳波技術集会は、主催者の脳波測定機器（BCI等）を利用したコンテンツ制作企画に関する開発の報告を始め、脳波技術に関する紹介やLT、制作物の展示などを行うイベントです。脳波技術に興味がある方や開発を行いたい方はは是非ご参加ください！";}
        public void OnClicked_3() {_joinInfo.text = @"fog";_Discord.text = @"https://discord.gg/Mes3nP3mZt";_X.text = @"";_Tag.text = @"#VRCゲーム開発集会";_Description.text = @"ゲーム開発（ゲームデザイン、2D・3Dグラフィック、シナリオ、音楽、プログラミング等）に関する交流イベントです。ゲーム開発に興味がある人なら誰でも参加できます！";}
        public void OnClicked_2() {_joinInfo.text = @"digiponta";_Discord.text = @"https://discord.gg/ECQ8k63CFk";_X.text = @"";_Tag.text = @"#TechGeekCafe";_Description.text = @"若手技術者と高齢技術者の交流/BOF/井戸端会議の場の提供。基本は、任意参加、任意解散です。お時間はある方、ご参加ください。参加条件：        自称技術オタクの方か、オタク技術に興味のある方";}
        public void OnClicked_1() {_joinInfo.text = @"eigo・きーたん";_Discord.text = @"https://discord.gg/zDRmrjgUnR";_X.text = @"";_Tag.text = @"";_Description.text = @"";}
    }

    public enum Week
    {
        None, 
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Other,
    } 
}
