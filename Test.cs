using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using MedForums_testing;


namespace MedForums_testing
{
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void LoadSiteAsAdmin()
        {
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Url = "http://medforums-qa.us-west-2.elasticbeanstalk.com/admin/";
        }

        [Test(Description = "add conference")]
        public void AddConference()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("conference");
            Methods.Logout();
            driver.Close();
        }


        [Test(Description = "add app")]
        public void AddApp()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("app");
            Methods.Logout();
            driver.Close();
        }

        [Test(Description = "add book")]
        public void AddBook()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("book");
            Methods.Logout();
            driver.Close();
        }

        /* Cannot Create Blogs in Current Version
        [Test(Description = "add blog")]
        public void AddBlog()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("blog");
            Methods.Logout();
            driver.Close();
        }
        */

        [Test(Description = "add course")]
        public void AddCourse()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("course");
            Methods.Logout();
            driver.Close();
        }

        [Test(Description = "add online resource")]
        public void AddOnlineResource()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("onlineResource");
            Methods.Logout();
            driver.Close();
        }

        [Test(Description = "add podcast")]
        public void AddPodcast()
        {
            Methods Methods = new Methods();
            Methods.Login();
            Methods.AddProduct("podcast");
            Methods.Logout();
            driver.Close();
        }
    }
}
