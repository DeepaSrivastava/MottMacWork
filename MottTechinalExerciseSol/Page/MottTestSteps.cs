using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace MottTechinalExerciseSol.Page
{ 
    [Binding]
    public class MottTestSteps : CommonTestSteps
    {
        [Given(@"the user is on '(.*)'")]
        public void GivenTheUserIsOn(string url)
        {
            LaunchBrowser();
            NavigateToURL(url);
        }
        
        [When(@"the user clicked on '(.*)' tab")]
        public void WhenTheUserClickedOnMenuTab(string menu)
        {
            ClickOnMenuTab(menu);
        }

        [When(@"the user search for '(.*)'")]
        public void WhenTheUserSearchFor(string searchText)
        {
        CareerSearch(searchText);
        }
                
        [Then(@"verify the result contains '(.*)' role")]
        public void ThenVerifyTheResultContainsRole(string role)
        {
            VerifySearchCareerListItems(role);
        }
        
        [Then(@"clicks on '(.*)'")]
        public void ThenClicksOn(string job)
        {
            ClickOnViewJob(job);
        }
        [Then(@"new '(.*)' tab page should load")]
        public void ThenNewTabPageShouldLoad(string menu)
        {
            GetPageTitle(menu);
        }

    }
}
