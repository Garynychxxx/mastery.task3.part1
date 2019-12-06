using Core;
using NUnit.Framework;

namespace SeleniumWithPageObjectDemo.Features
{
    [TestFixture]
    public class SearchPageTest : TestHelper
    {
        [Test]
        public void Test1()
        {
            Navigation.NavigateTo(ConfigManager.StartUrl);
            SearchPage.SearchFor("how to use explicit waits" + "\n");
            SearchPage.ValidateSearchResultsAreVisible();
        }
    }
}