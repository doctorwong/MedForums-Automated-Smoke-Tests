/*
 * This test:
 * 1. Logs into the website as an administrator
 * 2. Creates a new product with inputs in all fields (conference)
 * 3. Checks if the new product is added
 * 4. Checks if all product details entered is saved
 * */

using MedForums_testing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace MedForums_testing
{
    public class Methods
    {
        IWebDriver driver;
        public void Login()
        {
            //Loads webpage
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Url = "http://medforums-qa.us-west-2.elasticbeanstalk.com/admin/";

            //Logs into web app and verifies user is logged in as admin
            driver.FindElement(By.CssSelector(Selectors.userName)).SendKeys(Data.userName);
            driver.FindElement(By.CssSelector(Selectors.password)).SendKeys(Data.password);
            driver.FindElement(By.CssSelector(Selectors.loginButton)).Click();
            driver.FindElement(By.LinkText("VIEW SITE")).Click();
            IWebElement loggedIn = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(loggedIn.Text.Contains("Admin"));
        }

        public void AddProduct(string productType)
        {
            //Log into the website
            Login();

            //Click 'Feature your Education Product'
            driver.FindElement(By.LinkText(Selectors.addProduct)).Click();

            switch (productType)
            {
                //Selects the product type specified, and inputs information relevant to that product type
                case "app":
                    driver.FindElement(By.LinkText("App")).Click();
                    driver.FindElement(By.Id(Selectors.appleLink)).SendKeys(Data.appleLink);
                    driver.FindElement(By.Id(Selectors.googleLink)).SendKeys(Data.googleLink);
                    break;

                case "conference":
                    driver.FindElement(By.LinkText("Conference")).Click();
                    driver.FindElement(By.Id(Selectors.startDate)).SendKeys(Data.startDate);
                    driver.FindElement(By.Id(Selectors.endDate)).SendKeys(Data.endDate);
                    driver.FindElement(By.Id(Selectors.venueName)).SendKeys(Data.venueName);
                    driver.FindElement(By.Id(Selectors.locationAddress)).SendKeys(Data.locationAddress);
                    driver.FindElement(By.CssSelector(Selectors.conferenceLocation)).SendKeys(Data.conferenceLocation);
                    break;

                case "book":
                    driver.FindElement(By.LinkText("Book")).Click();
                    driver.FindElement(By.Id(Selectors.bookAuthor)).SendKeys(Data.bookAuthor);
                    driver.FindElement(By.Id(Selectors.pageCount)).SendKeys(Data.pageCount);
                    driver.FindElement(By.Id(Selectors.ISBN)).SendKeys(Data.ISBN);
                    break;

                case "blog":
                    driver.FindElement(By.LinkText("Blog")).Click();
                    driver.FindElement(By.Id(Selectors.blogAuthor)).SendKeys(Data.blogAuthor);
                    break;

                case "course":
                    driver.FindElement(By.LinkText("Course")).Click();
                    break;

                case "onlineResource":
                    driver.FindElement(By.LinkText("Online Resource")).Click();
                    break;

                case "podcast":
                    driver.FindElement(By.LinkText("Podcast")).Click();
                    break;

                default:
                    break;
            }

            //The following fields can be entered for all products

            //product name
            driver.FindElement(By.CssSelector(Selectors.name)).SendKeys(Data.name);

            //product url
            driver.FindElement(By.CssSelector(Selectors.productUrl)).SendKeys(Data.productUrl);

            //price
            driver.FindElement(By.Id(Selectors.minPrice)).SendKeys(Data.minPrice);
            driver.FindElement(By.Id(Selectors.maxPrice)).SendKeys(Data.maxPrice);

            //description
            driver.FindElement(By.Id(Selectors.description)).SendKeys(Data.description);

            //company
            driver.FindElement(By.Id(Selectors.company)).SendKeys(Data.company);

            //discount code
            driver.FindElement(By.Id(Selectors.discountCode)).SendKeys(Data.discountCode);

            //twitter link
            driver.FindElement(By.Id(Selectors.twitterLink)).SendKeys(Data.twitterLink);

            //twitter handle
            driver.FindElement(By.Id(Selectors.twitterAccount)).SendKeys(Data.twitterAccount);

            //dropdown fields
            driver.FindElement(By.Id(Selectors.occupationDropdown)).Click();
            driver.FindElement(By.CssSelector("div[data-occupation-id='16']")).Click();
            driver.FindElement(By.Id(Selectors.specialityDropdown)).Click();
            driver.FindElement(By.CssSelector("div[data-speciality-id='22']")).Click();
            driver.FindElement(By.Id(Selectors.otherDropdown)).Click();
            driver.FindElement(By.CssSelector("div[data-other-id='6']")).Click();

            //Select License
            new SelectElement(driver.FindElement(By.CssSelector(Selectors.license))).SelectByValue("ENTERPRISE");

            //Click Submit
            driver.FindElement(By.CssSelector(Selectors.submitButton)).Click();

            //Verify Product Creation
            IWebElement productName = driver.FindElement(By.CssSelector(Selectors.productName));
            Assert.IsTrue(productName.Text.Contains(Data.name));
        }

        public void Logout()
        {
            //Tests if a user can log out of the web app
            driver.FindElement(By.CssSelector("div[class='profile-picture']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn btn-light']")).Click();
            IWebElement loggedOut = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(loggedOut.Text.Contains("Log In"));
            driver.Close();
        }
    }

}

