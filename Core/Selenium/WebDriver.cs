using System;
using System.Threading;
using Core.Selenium.BrowserFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Selenium
{
    public class WebDriver
    {
        private static readonly ThreadLocal<WebDriver> _localWebDriver = new ThreadLocal<WebDriver>();
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private WebDriver()
        {
            _localWebDriver.Value = this;
        }

        public static WebDriver Current => _localWebDriver.Value ?? new WebDriver();

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        /// <exception cref="NullReferenceException">The WebDriver driver instance was not initialized.You should first call the method Start.</exception>
        public IWebDriver Driver //TODO it's better to do a Driver 'internal' :) 
        {
            get => _driver ?? (_driver = DriverFactory.GetDriver());
            private set => _driver = value;
        }

        public WebDriverWait Wait => _wait ?? (_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ConfigManager.Wait)));
        
        /// <summary>
        /// Stops the browser.
        /// </summary>
        public void Quit()
        {
            Driver?.Quit();
            _localWebDriver.Value = null;
            Driver = null;
        }
    }
}