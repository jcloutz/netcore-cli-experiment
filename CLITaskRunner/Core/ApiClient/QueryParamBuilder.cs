using System.Collections.Generic;
using System.Text;

namespace CLITaskRunner.Core.ApiClient
{
    public class QueryParamBuilder : IQueryParamBuilder
    {
        private IDictionary<string, string> _params { get; }
        
        public QueryParamBuilder()
        {
            _params = new Dictionary<string, string>();
        }

        public QueryParamBuilder Filter(string key, string value)
        {
            _params.Add(key, value);

            return this;
        }

        public QueryParamBuilder Page(int page)
        {
            _params.Add("_page", page.ToString());

            return this;
        }
        
        public QueryParamBuilder Limit(int limit)
        {
            _params.Add("_limit", limit.ToString());

            return this;
        }
        
        public QueryParamBuilder Sort(string sort)
        {
            _params.Add("_sort", sort);

            return this;
        }
        
        public QueryParamBuilder Order(string order)
        {
            _params.Add("_order", order);

            return this;
        }
        
        public QueryParamBuilder Start(int start)
        {
            _params.Add("_start", start.ToString());

            return this;
        }
        
        public QueryParamBuilder End(int end)
        {
            _params.Add("_end", end.ToString());

            return this;
        }
        
        public QueryParamBuilder Gte(string field, int lowerBound)
        {
            _params.Add($"{field}_gte", lowerBound.ToString());

            return this;
        }
        
        public QueryParamBuilder Lte(string field, int upperBound)
        {
            _params.Add($"{field}_lte", upperBound.ToString());

            return this;
        }
        
        public QueryParamBuilder Ne(string field, string value)
        {
            _params.Add($"{field}_ne", value.ToString());

            return this;
        }
        
        public QueryParamBuilder Ne(string field, int value)
        {
            return Ne(field, value.ToString());
        }
       
        public QueryParamBuilder Like(string field, string value)
        {
            _params.Add($"{field}_like", value);

            return this;
        }
        
        public QueryParamBuilder Embed(string relation)
        {
            _params.Add("_embed", relation);

            return this;
        }
        
        public QueryParamBuilder Expand(string parent)
        {
            _params.Add("_expand", parent);

            return this;
        }

        public override string ToString()
        {
            var queryString = "";
            
            if (_params.Count > 0)
            {
                var builder = new StringBuilder();
                builder.Append("?");
            
                foreach(var param in _params)
                {
                    builder.Append($"&{param.Key}={param.Value}");
                }

                queryString = builder.ToString();
            }

            return queryString;
        }

        public string Build()
        {
            return ToString();
        }
    }
}