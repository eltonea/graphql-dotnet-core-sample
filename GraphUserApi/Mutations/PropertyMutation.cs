using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Mutations.Inputs;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations
{
    public class PropertyMutation : ObjectGraphType
    {
        public PropertyMutation(PropertyData propertyData)
        {
            Field<PropertyType>(
                "createType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" }
                ),
                resolve: context =>
                {
                    var property = context.GetArgument<Property>("property");
                    return propertyData.Add(property);
                });
        }
    }
}
