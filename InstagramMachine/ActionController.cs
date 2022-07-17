using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace InstagramMachine
{
    internal class ActionController
    {
        IWebDriver d;
        AutoItX3 x = new AutoItX3();
        Process[] pName;
        Form1 f;
        Random r = new Random();
        ImgResizer iR = new ImgResizer();
        Email m = new Email();
        UserControl2 uc2;
        UserControl1 uc1;

        public static String accountName;
        public static String posts;
        public static String followers;
        public static String following;
        public static String actualProfile;

        public static Mutex MuTexLock = new Mutex();

        public ActionController()
        {
            
        }

        public ActionController(UserControl2 uc2)
        {
            this.uc2 = uc2;
        }

        public async void Post(String path, String proxy, String profile, Label state)
        {
            MuTexLock.WaitOne();
            do
            {
                Thread.Sleep(10000);
                pName = Process.GetProcessesByName("chrome");
            }
            while (pName.Length != 0);

            if (state.InvokeRequired)
            {
                state.Invoke(new MethodInvoker(delegate
                {
                    state.Text = "Running\nPost";
                    state.ForeColor = Color.Green;
                }));
            }

            f = new Form1();
            String message = "";

            try
            {
                var c = new ChromeOptions();

                c.AddArguments(String.Format(@"--user-data-dir=C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()));
                c.AddArguments(String.Format(@"--profile-directory={0}", profile));
                c.AddExcludedArgument("--enable-automation");
                c.AcceptInsecureCertificates = true;
                c.AddArguments("--ignore-ssl-errors");
                c.AddArgument("start-maximized");
                c.AddArguments("--lang=en");
                c.AddArguments("--disable-blink-features=AutomationControlled");
                c.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36");

                var commandTimeout = TimeSpan.FromSeconds(30);

                if (proxy != "")
                {
                    Proxy p = new Proxy();
                    p.Kind = ProxyKind.Manual;
                    p.IsAutoDetect = false;
                    p.HttpProxy = proxy;
                    p.SslProxy = proxy;
                    c.Proxy = p;
                }

                d = new ChromeDriver(String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));



                d.Navigate().GoToUrl("https://www.instagram.com/");
                r.Sleep();

                var newPost = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@aria-label='New Post']")));
                newPost.Click();
                r.Sleep();

                var selectFile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Select from computer']")));
                selectFile.Click();
                r.Sleep();

                if (File.Exists(String.Format(@"{0}\resizedImg\imgPath.txt", path)))
                {
                    String[] lineArr = File.ReadAllLines(String.Format(@"{0}\resizedImg\imgPath.txt", path));
                    String pathToImg = lineArr[0];
                    r.Sleep();

                    x.ControlFocus("Open", "", "Edit1");
                    x.ControlSetText("Open", "", "Edit1", String.Format("{0}", pathToImg));
                    x.ControlClick("Open", "", "Button1");

                    String[] temp = new string[lineArr.Length - 1];

                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = lineArr[i + 1];
                    }

                    File.WriteAllLines(String.Format(@"{0}\resizedImg\imgPath.txt", path), temp);
                }
                else if (!File.Exists(String.Format(@"{0}\resizedImg\imgPath.txt", path)))
                {
                    iR.ImageResize(path);

                    String[] lineArr = File.ReadAllLines(String.Format(@"{0}\resizedImg\imgPath.txt", path));
                    String pathToImg = lineArr[0];
                    r.Sleep();

                    x.ControlFocus("Open", "", "Edit1");
                    x.ControlSetText("Open", "", "Edit1", String.Format("{0}", pathToImg));
                    x.ControlClick("Open", "", "Button1");

                    String[] temp = new string[lineArr.Length - 1];

                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = lineArr[i + 1];
                    }

                    File.WriteAllLines(String.Format(@"{0}\resizedImg\imgPath.txt", path), temp);
                }
                r.Sleep();

                var next = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Next']")));
                next.Click();
                r.Sleep();

                var next2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Next']")));
                next2.Click();

                r.Hashtag(path);
                r.Sleep();


                var hashtag = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[6]/div[2]/div/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/textarea")));
                hashtag.SendKeys(r.GetHashtags());
                r.Sleep();

                var share = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Share']")));
                share.Click();
                r.Sleep();

                message = "Post succesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm") + "\n" + "Photos left in folder: ";

                m.Mail(message);
                r.Sleep();

                d.Quit();

                if (state.InvokeRequired)
                {
                    state.Invoke(new MethodInvoker(delegate
                    {
                        state.Text = "Offline";
                        state.ForeColor = Color.Red;
                    }));
                }

                r.Sleep();
                MuTexLock.ReleaseMutex();
            }
            catch (Exception ex)
            {
                message = "Post unsuccesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm") + "\n\n" + ex;

                m.Mail(message + "\n" + ex.ToString());
                r.Sleep();

                d.Quit();
                r.Sleep();
            }
        }

        public async void Like(String path, String proxy, String profile, int nbOfLike, Label state)
        {
            MuTexLock.WaitOne();
            do
            {
                Thread.Sleep(10000);
                pName = Process.GetProcessesByName("chrome");
            }
            while (pName.Length != 0);

            if (state.InvokeRequired)
            {
                state.Invoke(new MethodInvoker(delegate
                {
                    state.Text = "Running\nLike";
                    state.ForeColor = Color.Green;
                }));
            }

            f = new Form1();
            int likeCounter = 0;
            String message = "";

            try
            {
                var c = new ChromeOptions();

                c.AddArguments(String.Format(@"--user-data-dir=C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()));
                c.AddArguments(String.Format(@"--profile-directory={0}", profile));
                c.AddExcludedArgument("--enable-automation");
                c.AcceptInsecureCertificates = true;
                c.AddArguments("--ignore-certificate-errors");
                c.AddArguments("--ignore-ssl-errors");
                c.AddArgument("start-maximized");
                c.AddArguments("--lang=en");
                c.AddArguments("--disable-blink-features=AutomationControlled");
                c.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");

                var commandTimeout = TimeSpan.FromSeconds(20);

                if (proxy != "")
                {
                    Proxy p = new Proxy();
                    p.Kind = ProxyKind.Manual;
                    p.IsAutoDetect = false;
                    p.HttpProxy = proxy;
                    p.SslProxy = proxy;
                    c.Proxy = p;
                }

                d = new ChromeDriver(String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));

                r.HashtagLike(path);
                d.Navigate().GoToUrl(String.Format("https://www.instagram.com/explore/tags/{0}/", r.GetHashtagToLike()));
                r.Sleep();

                var followers = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/main/article/div[1]/div/div/div[1]/div[1]/a")));
                followers.Click();
                r.Sleep();

                do
                {
                    var likeBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[6]/div[3]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/button")));
                    
                    var nextBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@aria-label='Next']")));
                    bool isNotLiked = d.FindElements(By.XPath("//*[@aria-label='Like']")).Count() > 0;
                    bool isLiked = d.FindElements(By.XPath("//*[@aria-label='Unlike']")).Count() > 0;

                    if (isLiked)
                    {
                        nextBtn.Click();
                    }
                    else if (isNotLiked)
                    {
                        likeBtn.Click();
                        r.Sleep();

                        likeCounter++;

                        nextBtn.Click();                        
                    }

                    r.Sleep();
                }
                while (likeCounter != nbOfLike);

                message = "Likes succesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                m.Mail(message);
                r.Sleep();

                d.Quit();

                if (state.InvokeRequired)
                {
                    state.Invoke(new MethodInvoker(delegate
                    {
                        state.Text = "Offline";
                        state.ForeColor = Color.Red;
                    }));
                }

                r.Sleep();
                MuTexLock.ReleaseMutex();
            }
            catch (Exception ex)
            {
                message = "Likes unsuccesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                m.Mail(message + "\n" + ex.ToString());
                r.Sleep();

                d.Quit();
                r.Sleep();
            }

        }

        public async void Follow(String path, String proxy, String profile, int nbOfFollow, String acc, Label state)
        {
            MuTexLock.WaitOne();
            do
            {
                Thread.Sleep(10000);
                pName = Process.GetProcessesByName("chrome");
            }
            while (pName.Length != 0);

            if (state.InvokeRequired)
            {
                state.Invoke(new MethodInvoker(delegate
                {
                    state.Text = "Running\nFollow";
                    state.ForeColor = Color.Green;
                }));
            }

            f = new Form1();
            int followersCounter = 0;
            int followBtnCounter = 1;
            String message = "";

            try
            {
                var c = new ChromeOptions();

                c.AddArguments(String.Format(@"--user-data-dir=C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()));
                c.AddArguments(String.Format(@"--profile-directory={0}", profile));
                c.AddExcludedArgument("--enable-automation");
                c.AcceptInsecureCertificates = true;
                c.AddArguments("--ignore-certificate-errors");
                c.AddArguments("--ignore-ssl-errors");
                c.AddArgument("start-maximized");
                c.AddArguments("--lang=en");
                c.AddArguments("--disable-blink-features=AutomationControlled");
                c.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");

                var commandTimeout = TimeSpan.FromSeconds(20);

                if (proxy != "")
                {
                    Proxy p = new Proxy();
                    p.Kind = ProxyKind.Manual;
                    p.IsAutoDetect = false;
                    p.HttpProxy = proxy;
                    p.SslProxy = proxy;
                    c.Proxy = p;
                }

                d = new ChromeDriver(String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));

                d.Navigate().GoToUrl(String.Format("https://www.instagram.com/{0}/", acc));
                r.Sleep();

                var follower = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/main/div/header/section/ul/li[2]/a")));
                follower.Click();
                r.Sleep();

                do
                {
                    var currentUser = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(String.Format("/html/body/div[6]/div/div/div/div[2]/ul/div/li[{0}]", followBtnCounter))));
                    var button = currentUser.FindElement(By.XPath(".//button"));

                    if (button.Text.Equals("Follow"))
                    {
                        button.Click();
                        followersCounter++;
                    }

                    followBtnCounter++;
                    r.Sleep();

                }
                while (followersCounter != nbOfFollow);

                var closeFollow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@aria-label='Close']")));
                closeFollow.Click();
                r.Sleep();

                var profileImg = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[3]/div/div[6]/div[1]/span/img")));
                profileImg.Click();
                r.Sleep();

                var prof = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[3]/div/div[6]/div[2]/div[2]/div[2]/a[1]")));
                prof.Click();
                r.Sleep();

                actualProfile = profile;
                accountName = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/section/main/div/header/section/div[1]/h2"))).Text;
                posts = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/section/main/div/header/section/ul/li[1]/div"))).Text;
                followers = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/section/main/div/header/section/ul/li[2]/a"))).Text;
                following = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/section/main/div/header/section/ul/li[3]/a"))).Text;

                message = "Follows succesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                m.Mail(message);
                r.Sleep();

                d.Quit();

                if (state.InvokeRequired)
                {
                    state.Invoke(new MethodInvoker(delegate
                    {
                        state.Text = "Offline";
                        state.ForeColor = Color.Red;
                    }));
                }

                r.Sleep();
                MuTexLock.ReleaseMutex();
            }
            catch (Exception ex)
            {
                //message = "Follows unsuccesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                //m.Mail(message + "\n" + ex.ToString());
                //r.Sleep();

                //d.Quit();
                //r.Sleep();
            }
        }

        public async void Unfollow(String path, String proxy, String profile, int nbOfUnfollow, Label state)
        {
            MuTexLock.WaitOne();
            do
            {
                Thread.Sleep(10000);
                pName = Process.GetProcessesByName("chrome");
            }
            while (pName.Length != 0);

            if (state.InvokeRequired)
            {
                state.Invoke(new MethodInvoker(delegate
                {
                    state.Text = "Running\nUnfollow";
                    state.ForeColor = Color.Green;
                }));
            }

            f = new Form1();
            int unfollowCounter = 0;
            int unfollowBtnCounter = 1;
            String message = "";

            try
            {
                var c = new ChromeOptions();

                c.AddArguments(String.Format(@"--user-data-dir=C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()));
                c.AddArguments(String.Format(@"--profile-directory={0}", profile));
                c.AddExcludedArgument("--enable-automation");
                c.AcceptInsecureCertificates = true;
                c.AddArguments("--ignore-certificate-errors");
                c.AddArguments("--ignore-ssl-errors");
                c.AddArgument("start-maximized");
                c.AddArguments("--lang=en");
                c.AddArguments("--disable-blink-features=AutomationControlled");
                c.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");

                var commandTimeout = TimeSpan.FromSeconds(20);

                if (proxy != "")
                {
                    Proxy p = new Proxy();
                    p.Kind = ProxyKind.Manual;
                    p.IsAutoDetect = false;
                    p.HttpProxy = proxy;
                    p.SslProxy = proxy;
                    c.Proxy = p;
                }

                d = new ChromeDriver(String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data", f.GetComputerName()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));

                d.Navigate().GoToUrl("https://www.instagram.com/");
                r.Sleep();

                var myProfile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/main/section/div[3]/div[1]/div/div/div[1]/div/a")));
                myProfile.Click();
                r.Sleep();

                var following = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='react-root']/section/main/div/header/section/ul/li[3]/a")));
                following.Click();
                r.Sleep();

                do
                {
                    var currentUser2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(String.Format("/html/body/div[6]/div/div/div/div[3]/ul/div/li[{0}]", unfollowBtnCounter))));
                    var button2 = currentUser2.FindElement(By.XPath(".//button"));

                    if (button2.Text.Equals("Following"))
                    {
                        button2.Click();
                        r.Sleep();

                        var unfollow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Unfollow']")));
                        unfollow.Click();
                        r.Sleep();

                        unfollowCounter++;
                    }

                    unfollowBtnCounter++;
                    r.Sleep();

                }
                while (unfollowCounter != nbOfUnfollow);

                message = "Unfollows succesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                m.Mail(message);
                r.Sleep();

                d.Quit();

                if (state.InvokeRequired)
                {
                    state.Invoke(new MethodInvoker(delegate
                    {
                        state.Text = "Offline";
                        state.ForeColor = Color.Red;
                    }));
                }

                r.Sleep();
                MuTexLock.ReleaseMutex();
            }
            catch (Exception ex)
            {
                message = "Unfollows unsuccesfully made => " + DateTime.Now.ToString("MM / dd  HH: mm");

                m.Mail(message + "\n" + ex.ToString());
                r.Sleep();

                d.Quit();
                r.Sleep();
            }

        }

        public String GetAccountName()
        {
            return accountName;
        }
        public String GetPosts()
        {
            return posts;
        }
        public String GetFollowers()
        {
            return followers;
        }
        public String GetFollowing()
        {
            return following;
        }
        public String GetActualProfile()
        {
            return actualProfile;
        }
    }
}
