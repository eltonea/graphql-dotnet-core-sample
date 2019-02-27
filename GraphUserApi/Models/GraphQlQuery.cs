using Newtonsoft.Json.Linq;

namespace GraphUserApi.Models
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
