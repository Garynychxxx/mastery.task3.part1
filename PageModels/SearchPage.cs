namespace PageModels
{
    public class SearchPage
    {
        private SearchPageElementMap _map => new SearchPageElementMap();

        public SearchPageValidator Validate() => new SearchPageValidator(_map);

        public void SearchFor(string value) => _map.FillSearchField(value);
    }
}