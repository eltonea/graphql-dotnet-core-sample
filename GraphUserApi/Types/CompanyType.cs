using GraphQL.Types;

namespace GraphUserApi.Types
{
    public class CompanyType: ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Field(x => x.Name);
        }
    }

    public class Company
    {
        public string Name { get; set; }
    }
}
