using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MetroFramework.Forms;
///selenium
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ChromeDriverUpdater;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroForm
    {
        ChromeDriverService _chromeDriverService;
        ChromeDriver _chromeDriver;
        string Element = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/section/div[2]/form/div[1]/ul/li";
        string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //폴더명에 허용안되는 문자가 들어올시 변경되기 위해 선언
        string manga_name2 = string.Empty;
        string _name = string.Empty;
        string _manga_name = string.Empty;
        string code = string.Empty;

        int _num = 4;
        public Form1()
        {
            InitializeComponent();
            dgv.RowHeadersVisible = false;
            label1.Text = Text = @"reisen_downloder";
            _chromeDriverService = ChromeDriverService.CreateDefaultService();
            //바탕화면에 만화 폴더 생성
            if (!Directory.Exists(localpath + "\\만화"))
            {
                Directory.CreateDirectory(localpath + "\\만화");
            }
        }
        //검색
        private void search_Click(object sender, EventArgs e)
        {
            search_function();
        }

        //enter Key로 검색
        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                search_function();
            }
        }

        //검색결과
        private void search_function()
        {
            try
            {
                var option = new ChromeOptions();
                option.AddArgument("--headless");
                _chromeDriverService.HideCommandPromptWindow = true;
                _chromeDriver = new ChromeDriver(_chromeDriverService, option);
                _chromeDriver.Navigate().GoToUrl("https://manatoki106.net/comic?stx=" + search_text.Text);
                dgv_add();
            }
            catch { }

        }

        //데이터 추가
        private void dgv_add()
        {
            dgv.Rows.Clear();
            var headline = _chromeDriver.FindElementsByXPath(Element);
            string name;
            for (int i = 0; i < headline.Count; i++)
            {
                name = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/section/div[2]/form/div[1]/ul/li[" + (i + 1) + "]/div/div/div/div[1]/div/div/a/span";
                var selenium_name = _chromeDriver.FindElementByXPath(name);
                dgv.Rows.Add(i + 1, selenium_name.Text);
            }
        }
        //다음 페이지
        private void next_Click(object sender, EventArgs e)
        {
            _num++;
            var headline = _chromeDriver.FindElementsByXPath(Element);
            string page = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/section/div[2]/form/div[4]/ul/li[" + _num + "]/a";
            var btn = _chromeDriver.FindElementByXPath(page);
            btn.Click();
            dgv_add();
        }


        //이전 페이지
        private void previous_Click(object sender, EventArgs e)
        {
            _num--;
            var headline = _chromeDriver.FindElementsByXPath(Element);
            string page = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/section/div[2]/form/div[4]/ul/li[" + _num + "]/a";
            var btn = _chromeDriver.FindElementByXPath(page);
            btn.Click();
            dgv_add();
        }

        //다운 버튼
        private void down_Click(object sender, EventArgs e)
        {
            int manga_num = dgv.CurrentRow.Index + 1;
            var headline = _chromeDriver.FindElementsByXPath(Element);
            string page = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/section/div[2]/form/div[1]/ul/li[" + manga_num + "]/div/div/div/div[1]/div/a";
            var manga = _chromeDriver.FindElementByXPath(page);
            manga.Click();
            kmdir();
            manga_click();
        }

        //폴더 생성
        private void kmdir()
        {
            int manga_num = dgv.CurrentRow.Index;
            string manga_name = dgv.Rows[manga_num].Cells[1].Value.ToString();

            //폴더명에  \ / : * ? " < > | 이 포함 되는지 확인
            if (manga_name.Contains("\\"))
                manga_name2 = manga_name.Replace("\\", "");
            else if (manga_name.Contains("/"))
                manga_name2 = manga_name.Replace("/", "");
            else if (manga_name.Contains(":"))
                manga_name2 = manga_name.Replace(":", "");
            else if (manga_name.Contains("*"))
                manga_name2 = manga_name.Replace("*", "");
            else if (manga_name.Contains("?"))
                manga_name2 = manga_name.Replace("?", "");
            else if (manga_name.Contains("\""))
                manga_name2 = manga_name.Replace("\"", "");
            else if (manga_name.Contains("<"))
                manga_name2 = manga_name.Replace("<", "");
            else if (manga_name.Contains(">"))
                manga_name2 = manga_name.Replace(">", "");
            else if (manga_name.Contains("|"))
                manga_name2 = manga_name.Replace("|", "");
            else
                manga_name2 = manga_name;


            if (Directory.Exists(localpath + "\\만화" + "\\" + manga_name2) == false)
            {
                Directory.CreateDirectory(localpath + "\\만화\\" + manga_name2);
            }
        }
        private void kmdir2(string name)
        {
            if (Directory.Exists(localpath + "\\만화" + "\\" + manga_name2 + "\\" + name) == false)
            {
                Directory.CreateDirectory(localpath + "\\만화\\" + manga_name2 + "\\" + name);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            down_load();
        }


        //화 클릭
        private void manga_click()
        {
            Element = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/div[4]/section/article/form/div/ul/li";
            var headline = _chromeDriver.FindElementsByXPath(Element);
            var images = _chromeDriver.FindElements(By.TagName("a"));
            //int dwon = headline.Count / 100;

            for (int i = 0; i < images.Count; i++)
            {
                var rinkurl = images[i].GetAttribute(code);
            }
            for (int i = images.Count; i >= 0; i--)
            {
                try
                {
                    _name = "/html/body/div[1]/div/div[2]/div[2]/div/div[1]/div[1]/div[4]/section/article/form/div/ul/li[" + (i + 1) + "]/div[2]/a";
                    var manga_name = _chromeDriver.FindElementByXPath(_name);
                    _manga_name = manga_name.Text.Substring(0, manga_name.Text.LastIndexOf('화'));
                    kmdir2(_manga_name + "화");
                    manga_name.Click();
                    mangacode(i);
                    down_load();
                    //_chromeDriver.Navigate().Back();
                }
                catch { continue;}
                //downloding.Value += dwon;
            }
            notifyIcon1.BalloonTipText = manga_name2 + "다운로드 완료";
            notifyIcon1.BalloonTipTitle = "마나토끼 다운로더";
            notifyIcon1.ShowBalloonTip(2);
            _chromeDriver.Quit();
            _chromeDriver.Close();
            //downloding.Visible = false;
        }

        private void mangacode(int num)
        {
            var images2 = _chromeDriver.FindElements(By.TagName("option"));
            
            code = images2[num].GetAttribute("value");
        }
        private void down_load()
        {
            //downloding.Visible = true;
            int j = 1;
            var images = _chromeDriver.FindElements(By.TagName("img"));
            var images2 = _chromeDriver.FindElements(By.TagName("option"));
            string mangacode = string.Empty;
            List<string> str2 = new List<string>();
            string[] str = null;

            for (int i = 0; i < images2.Count; i++)
            {
                var test = images2[0].GetAttribute("class");
                mangacode = test;
            }
            
            for (int i = 0; i < images.Count; i++)
            {
                try
                {
                    var imgurl = images[i].GetAttribute("data-" + mangacode);
                    var imgname = images[i].GetAttribute("alt");

                    WebClient daonloader = new WebClient();

                    if (imgurl == null || (!imgurl.Contains(code) && !imgurl.Contains("type"))) continue;
                    daonloader.DownloadFile(imgurl, localpath + "\\만화\\" + manga_name2 + "\\" + _manga_name + "화\\" + manga_name2 + "_" + j + ".jpg");
                    j++;
                }
                catch
                {
                    continue;
                }
            }
            _chromeDriver.Navigate().Back();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            Updater updater = new Updater();
            try
            {
                updater.Update(System.IO.Directory.GetCurrentDirectory() + @"\ChromeDriver.exe");
            }
            catch {  }
        }
    }
}