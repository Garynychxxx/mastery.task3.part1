using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace Core.Selenium.BrowserFactory
{
    public abstract class DriverBuilder
    {
        protected string PathToDriverBinary { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public abstract IWebDriver GetDriver();
    }
}