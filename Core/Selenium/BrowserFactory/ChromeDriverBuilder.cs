using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Selenium.BrowserFactory
{
    public class ChromeDriverBuilder : DriverBuilder
    {
        public override IWebDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();
            //usage chromeOptions.Add("some specific chrome settings");
            return new ChromeDriver(PathToDriverBinary, chromeOptions);
        }
    }
}