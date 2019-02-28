using GraphQL.Types;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations.Inputs
{
    public class UserInputType : InputObjectGraphType<User>
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field(x => x.Id, nullable: true);
            Field(x => x.Name);
            Field(x => x.LastName, nullable: true);
            Field(x => x.Age, nullable: true);

            Field<JobInputType>("job");
        }
    }
}
