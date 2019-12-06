using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium;

namespace Core.Selenium.BrowserFactory
{
    public static class DriverFactory
    {
        private static readonly Dictionary<BrowserType, DriverBuilder> BrowserDictionary = new Dictionary<BrowserType, DriverBuilder> {
            { BrowserType.Chrome, new ChromeDriverBuilder() }
        };

        /// <summary>
        /// Open browser and get driver.
        /// </summary>
        public static IWebDriver GetDriver()
        {
            var driver = BrowserDictionary[ConfigManager.Browser].GetDriver();
            driver.Manage().Window.Size = new Size(1680, 1020);
            return driver;
        }
    }
}