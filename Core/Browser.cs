using System.Threading;
using Core.Selenium;

namespace Core
{
    /// <summary>
    /// This class provide common browser functionality: navigating to pages, managing windows, alerts, capturing screenshots
    /// </summary>
    public class Browser
    {
        public string CurrentUrl => WebDriver.Driver.Url;
        public WebDriver WebDriver;
        private static readonly ThreadLocal<Browser> _localBrowser = new ThreadLocal<Browser>();

        protected Browser()
        {
            WebDriver = WebDriver.Current;
        }

        /// <summary>
        /// Get current browser instance
        /// </summary>
        /// <returns></returns>
        public static Browser Current => _localBrowser.Value ?? (_localBrowser.Value = new Browser());

        /// <summary>
        /// Navigates to a provided URL
        /// </summary>
        /// <param name="url"></param>
        public void NavigateToUrl(string url)
        {
            WebDriver.Driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            _localBrowser.Value = null;
            WebDriver.Quit();
        }
    }
}