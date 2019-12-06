using PageModels;

namespace SeleniumWithPageObjectDemo.Steps
{
    public class SearchPageSteps {
        public void SearchFor(string text) => new SearchPage().SearchFor(text);

        public void ValidateSearchResultsAreVisible() => new SearchPage().Validate().SearchResultsAreVisible();
    }

}
