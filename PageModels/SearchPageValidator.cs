using NUnit.Framework;

namespace PageModels
{
    public class SearchPageValidator
    {
        private readonly SearchPageElementMap _map;
        
        public SearchPageValidator(SearchPageElementMap map)
        {
            _map = map;
        }
        
        public void SearchResultsAreVisible() => Assert.True(_map.AreQuestionBlocksVisible(), "No any search results");
    }
}