using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MottTechinalExerciseSol.Page
{
    [Binding]
    public class CommonTestSteps
     {

        public static IWebDriver driver;

        public static By Search=> By.Id("search-career-search-temp");
        public static By SearchResultNumber => By.CssSelector("div.lf-1x3.lf-1x1st > p");
        public static By SearchResultTable => By.Id("j-careers-search__results");
        public static By SearchListItem => By.CssSelector("div.c-careers-search__list-item > h6");
        public static By ViewJobButton => By.CssSelector("div.lf-69x500.l-flex > a");
        public static By MenuLink => By.CssSelector("# PrimaryMenu > div > div > ul.primary-navigation > li");

        public static void LaunchBrowser()
        {
            driver = new ChromeDriver();
        }

        public static void NavigateToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        public static void CareerSearch(string searchtext)
        {
            IWebElement searchBox=driver.FindElement(Search);
            searchBox.Click();
            searchBox.SendKeys(searchtext);
            searchBox.SendKeys(Keys.Enter);
        }
        public static int GetResultCount()
        {

            var searchResult = WaitForElementToPresent(SearchResultNumber).Text;
            searchResult = searchResult.Split(" ")[5];
           
            return Convert.ToInt32(searchResult);

        }

        public static void VerifySearchCareerListItems(string role)
        {
            var resultItems = driver.FindElement(SearchResultTable).FindElements(SearchListItem);
            if(resultItems.Count>0)
            {
                Assert.IsTrue(resultItems.First(x => x.Text.Contains(role)).Displayed, $"does not contain {role}");
            }
        }

        public static void GetPageTitle(string menu)
        {
            var pTitle = driver.Title;
            Assert.IsTrue(pTitle.Contains(menu), $" Title does not contain {menu}");
            driver.Navigate().Back();
            WaitForPageLoad();
        }

        public static void ClickOnViewJob(string job)
        {
            ClickOnElement(ViewJobButton, job);
            Assert.IsTrue(WaitForElementToPresent(ViewJobButton).Text.Contains(job), $"does not contain {job}");
            
        }

        public static void ClickOnMenuTab(string linkname)
        {
            ClickOnElement(MenuLink, linkname);
            WaitForPageLoad();

            var links = driver.FindElements(By.TagName("a"));

            for (int i = 0; i < links.Count(); i++)
            {
                var newLinks = driver.FindElements(By.TagName("a"));
                newLinks[i].Click();
                WaitForPageLoad();
            }
        }

        public static void ClickOnElement(By by, string linkname)
        {
            IWebElement element;
            var elements = driver.FindElements(by);

            if (elements.Count == 0)
            {
                driver.Navigate().Refresh();
                elements = driver.FindElements(by);
            }
            element = elements.First(x => x.Text.Equals(linkname));
            element.Click();

        }

        public static IWebElement WaitForElementToPresent(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(d => d.FindElements(by).Count > 0);
            return driver.FindElement(by);

        }

        public static void WaitForPageLoad()
        {
            try
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                if (j.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    Console.WriteLine("Page in ready state");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Page not in ready state");
            }
        }
    }
}
