namespace CLITaskRunner.Core.ApiClient
{
    public interface IQueryParamBuilder
    {
        QueryParamBuilder Filter(string key, string value);
        QueryParamBuilder Page(int page);
        QueryParamBuilder Limit(int limit);
        QueryParamBuilder Sort(string sort);
        QueryParamBuilder Order(string order);
        QueryParamBuilder Start(int start);
        QueryParamBuilder End(int end);
        QueryParamBuilder Gte(string field, int lowerBound);
        QueryParamBuilder Lte(string field, int upperBound);
        QueryParamBuilder Ne(string field, string value);
        QueryParamBuilder Ne(string field, int value);
        QueryParamBuilder Like(string field, string value);
        QueryParamBuilder Embed(string relation);
        QueryParamBuilder Expand(string parent);
        string Build();
    }
}