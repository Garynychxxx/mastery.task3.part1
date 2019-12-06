using System;
using System.IO;
using Core.Selenium;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigManager
    {
        public static IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
            .AddJsonFile("appsettings.json")
#endif
            .Build();

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public static string StartUrl => Configuration["StartUrl"];
        
        /// <summary>
        /// Gets the wait length.
        /// </summary>
        /// <value>
        /// The wait.
        /// </value>
        public static double Wait => Convert.ToDouble(Configuration["Wait"]);

        /// <summary>
        /// Gets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public static BrowserType Browser 
        {
            get
            {
                var browser = Configuration["Browser"];
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
        }
    }
}