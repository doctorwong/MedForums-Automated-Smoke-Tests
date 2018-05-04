﻿/*
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
    public class Functions
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
                case "app":
                    //Click App
                    driver.FindElement(By.ClassName(Selectors.app)).Click();

                    //Enter Apple Link
                    driver.FindElement(By.CssSelector(Selectors.appleLink)).SendKeys(Data.appleLink);

                    //Enter Google link
                    driver.FindElement(By.CssSelector(Selectors.googleLink)).SendKeys(Data.googleLink);
                    break;

                case "conference":
                    //Click Conference
                    driver.FindElement(By.ClassName(Selectors.conference)).Click();

                    //Enter Start Date
                    driver.FindElement(By.Id(Selectors.startDate)).SendKeys(Data.startDate);

                    //Enter End Date
                    driver.FindElement(By.Id(Selectors.endDate)).SendKeys(Data.endDate);

                    //Enter location venue name
                    driver.FindElement(By.Id(Selectors.venueName)).SendKeys(Data.venueName);

                    //Enter location address
                    driver.FindElement(By.Id(Selectors.locationAddress)).SendKeys(Data.locationAddress);

                    //Enter conference location
                    driver.FindElement(By.CssSelector(Selectors.conferenceLocation)).SendKeys(Data.conferenceLocation);
                    break;

                case "book":
                    //Click Book
                    driver.FindElement(By.ClassName(Selectors.book)).Click();

                    //Enter Page Count
                    driver.FindElement(By.Id(Selectors.pageCount)).SendKeys(Data.pageCount);

                    //Enter ISBN
                    driver.FindElement(By.Id(Selectors.ISBN)).SendKeys(Data.ISBN);
                    break;

                case "blog":
                    //Click Blog
                    driver.FindElement(By.ClassName(Selectors.blog)).Click();
                    driver.FindElement(By.CssSelector(Selectors.blogAuthor)).SendKeys(Data.blogAuthor);
                    break;

                case "course":
                    //Click Course
                    driver.FindElement(By.ClassName(Selectors.course)).Click();
                    driver.FindElement(By.CssSelector(Selectors.courseStart)).SendKeys(Data.courseEnd);
                    break;

                case "onlineResource":
                    //Click Online Resource
                    driver.FindElement(By.ClassName(Selectors.onlineResource)).Click();
                    break;

                case "podcast":
                    //Click Podcast
                    driver.FindElement(By.ClassName(Selectors.podcast)).Click();
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

            //facebook link
            driver.FindElement(By.Id(Selectors.facebookLink)).SendKeys(Data.facebookLink);

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

            //Verify Fields
            switch (productType)
            {
                case "app":
                    IWebElement productAuthor = driver.FindElement(By.Id(Selectors.productAuthor));
                    Assert.IsTrue(productAuthor.Text.Contains(Data.appAuthor));
                    break;

                case "book":
                    IWebElement bookAuthor = driver.FindElement(By.Id(Selectors.productAuthor));
                    Assert.IsTrue(bookAuthor.Text.Contains(Data.bookAuthor));
                    break;

                case "blog":
                    IWebElement blogAuthor = driver.FindElement(By.Id(Selectors.productAuthor));
                    Assert.IsTrue(productAuthor.Text.Contains(Data.blogAuthor));
                    break;
                /*
                case "conference":
                    IWebElement conferenceLocation = driver.FindElement(By.CssSelector(Selectors.conferenceLocation));
                    Assert.IsTrue(conferenceLocation.Text.Contains(Data.conferenceLocation));
                    IWebElement locationVenueName = driver.FindElement(By.ClassName(Selectors.venueName));
                    Assert.IsTrue(locationVenueName.Text.Contains(Data.venueName));
                    IWebElement locationAddress = driver.FindElement(By.ClassName(Selectors.locationAddress));                  
                    Assert.IsTrue(locationAddress.Text.Contains(Data.locationAddress));
                    break;
                    */


                default:
                    break;
            }
            IWebElement productName = driver.FindElement(By.CssSelector(Selectors.productName));
            Assert.IsTrue(productName.Text.Contains(Data.name));

            IWebElement productDescription = driver.FindElement(By.Id(Selectors.productDescription));
            Assert.IsTrue(productDescription.Text.Contains(Data.description));

            
            break;


        }
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
class Tests
{
    public void LoadSiteAsAdmin() => Functions.Login();
}
