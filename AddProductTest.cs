/*
 * This test:
 * 1. Logs into the website as an administrator
 * 2. Creates a new product with inputs in all fields (conference)
 * 3. Checks if the new product is added
 * 4. Checks if all product details entered is saved
 * */

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace MedForums_testing
{
    class AddProductTest
    {
        IWebDriver driver;

        [SetUp]
        public void LoadSiteAsAdmin()
        {
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Url = "http://medforums-qa.us-west-2.elasticbeanstalk.com/admin/";        
        }

        [Test]
        //Login into web app

        public void SmokeTest()
        {
            //Logs into web app and verifies user is logged in as admin
            driver.FindElement(By.CssSelector("input[id='id_username']")).SendKeys("medforums");
            driver.FindElement(By.CssSelector("input[id='id_password']")).SendKeys("medforums!");
            driver.FindElement(By.CssSelector("input[value='Log in']")).Click();
            driver.FindElement(By.LinkText("VIEW SITE")).Click();
            IWebElement loggedIn = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(loggedIn.Text.Contains("Admin"));

            //Click 'Feature your Education Product'
            driver.FindElement(By.LinkText("Feature your Education Product")).Click();

            //Click Conference
            driver.FindElement(By.ClassName("card-body")).Click();

            //Enter conference name
            driver.FindElement(By.CssSelector("input[id='id_name']")).SendKeys("Sample Conference");

            //Enter Product URL
            driver.FindElement(By.CssSelector("input[id='id_product_url']")).SendKeys("http://www.google.com");

            //Enter Location
            driver.FindElement(By.CssSelector("input[id='id_location_name']")).SendKeys("New York, NY");

            //Enter minimum price
            driver.FindElement(By.Id("id_price")).SendKeys("99");

            //Enter maximum price
            driver.FindElement(By.Id("id_price_max")).SendKeys("9999");

            //Enter description
            driver.FindElement(By.Id("id_description")).SendKeys("Sample Description");

            //Enter Start Date
            driver.FindElement(By.Id("id_start_date")).SendKeys("06/01/2019");

            //Enter End Date
            driver.FindElement(By.Id("id_end_date")).SendKeys("06/01/2020");

            //Enter location venue name
            driver.FindElement(By.Id("id_location_venue_name")).SendKeys("Sanctum Santorum");

            //Enter location address
            driver.FindElement(By.Id("id_location_address")).SendKeys("177a Bleecker St, New York, NY 10012");

            //Enter Company
            driver.FindElement(By.Id("id_company")).SendKeys("Strange INC");

            //Enter discount code
            driver.FindElement(By.Id("id_discount_code")).SendKeys("WIZZARD");

            //Enter conference facebook page link
            driver.FindElement(By.Id("id_fb_url")).SendKeys("https://www.facebook.com/DoctaWong");

            //Enter conference Twitter link
            driver.FindElement(By.Id("id_twitter_url")).SendKeys("https://twitter.com/williewonga");

            //Enter Twitter Account
            driver.FindElement(By.Id("id_twitter_handles")).SendKeys("@williewonga");

            //Select occupation dropdown
            driver.FindElement(By.Id("occupation-button")).Click();
            driver.FindElement(By.CssSelector("div[data-occupation-id='16']")).Click();

            //Select speciality dropdown
            driver.FindElement(By.Id("speciality-button")).Click();
            driver.FindElement(By.CssSelector("div[data-speciality-id='22']")).Click();

            //Select an other tag
            driver.FindElement(By.Id("other-button")).Click();
            driver.FindElement(By.CssSelector("div[data-other-id='6']")).Click();

            //Select License
            new SelectElement(driver.FindElement(By.CssSelector("select[name='license_type_select']"))).SelectByValue("ENTERPRISE");

            //Click Submit
            driver.FindElement(By.CssSelector("button[name='submitFormButton']")).Click();

            //Verify Fields
            IWebElement productName = driver.FindElement(By.CssSelector("p[class ='product-name']"));
            Assert.IsTrue(productName.Text.Contains("Sample Conference"));
            IWebElement productLocation = driver.FindElement(By.CssSelector("p[class ='product-location']"));
            Assert.IsTrue(productLocation.Text.Contains("New York, NY"));
            IWebElement productDateRange = driver.FindElement(By.CssSelector("p[class ='product-date-range']"));
            Assert.IsTrue(productDateRange.Text.Contains("Jun 01, 2019 - Jun 01, 2020"));
            IWebElement truncatedDescription = driver.FindElement(By.Id("truncated-description"));
            Assert.IsTrue(truncatedDescription.Text.Contains("Sample Description"));
            IWebElement locationVenueName = driver.FindElement(By.ClassName("location-venue-name"));
            Assert.IsTrue(locationVenueName.Text.Contains("Sanctum Santorum"));
            IWebElement locationAddress = driver.FindElement(By.ClassName("location-address"));
            Assert.IsTrue(locationAddress.Text.Contains("177a Bleecker St, New York, NY 10012"));

            //Tests if a user can log out of the web app
            driver.FindElement(By.CssSelector("div[class='profile-picture']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn btn-light']")).Click();
            IWebElement loggedOut = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(loggedOut.Text.Contains("Log In"));
        }

        [TearDown]
        //Closes the browser
        public void Logout()
        {
            driver.Close();
        }
    }
}
