using GraphQL.Types;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations.Inputs
{
    public class JobInputType : InputObjectGraphType<Job>
    {
        public JobInputType()
        {
            Name = "JobInput";
            Field(x => x.Name);
        }
    }
}
