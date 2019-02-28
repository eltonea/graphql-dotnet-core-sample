using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Mutations.Inputs;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(UserData propertyData)
        {
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: context =>
                {
                    var property = context.GetArgument<User>("user");
                    return propertyData.Add(property);
                });

            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return propertyData.Update(user);
                });


        }
    }
}
