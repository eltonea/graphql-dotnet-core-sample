using GraphQL.Types;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations.Inputs
{
    public class CompanyInputType : InputObjectGraphType<Company>
    {
        public CompanyInputType()
        {
            Name = "CompanyInput";
            Field(x => x.Name);
        }
    }
}
