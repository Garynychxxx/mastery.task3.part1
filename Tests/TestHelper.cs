using Core;
using SeleniumWithPageObjectDemo.Steps;

namespace SeleniumWithPageObjectDemo
{
    public class TestHelper : BaseTest
    {
        protected NavigationSteps Navigation => new NavigationSteps();

        protected SearchPageSteps SearchPage => new SearchPageSteps();
    }
}