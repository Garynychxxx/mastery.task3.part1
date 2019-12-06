using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Selenium;
using OpenQA.Selenium;

namespace PageModels
{
    public class SearchPageElementMap
    {
        protected internal WebDriver WebDriver;
        public SearchPageElementMap()
        {
            WebDriver = WebDriver.Current;
        }

        private IWebElement TxtSearch => WebDriver.Driver.FindElement(By.CssSelector("#search input"));

        private IEnumerable<IWebElement> QuestionBlocks => WebDriver.Driver.FindElements(By.CssSelector(".question-summary"));
        
        public SearchPageElementMap FillSearchField(string value)
        {
            WebDriver.Wait.Until(d => TxtSearch.Displayed);
            TxtSearch.SendKeys(value);
            return this;
        }
        
        public bool AreQuestionBlocksVisible() => WebDriver.Wait.Until(driver => QuestionBlocks.Any(el => el.Displayed));
    }
}