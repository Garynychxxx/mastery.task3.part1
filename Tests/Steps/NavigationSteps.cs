using Core;

namespace SeleniumWithPageObjectDemo.Steps
{
    public class NavigationSteps
    {
        public void NavigateTo(string url) => Browser.Current.NavigateToUrl(url);
    }
}