using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Types;

namespace GraphUserApi.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(UserData propertyData, JobData jobData)
        {
            Name = "UserQuery";

            Field<ListGraphType<UserType>>(
                "properties",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of the property" }
                ),
                resolve: content => propertyData.GetAll(content.GetArgument<string>("id")));

            Field<JobType>(
                "job",
                resolve: content => propertyData.GetJob(content.GetArgument<string>("id"))
            );
        }
    }
}
