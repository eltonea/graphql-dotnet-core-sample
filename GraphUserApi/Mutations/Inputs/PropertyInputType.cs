using GraphQL.Types;
using GraphUserApi.Types;

namespace GraphUserApi.Mutations.Inputs
{
    public class PropertyInputType : InputObjectGraphType<Property>
    {
        public PropertyInputType()
        {
            Name = "PropertyInput";
            Field(x => x.Name);
            Field(x => x.LastName, nullable: true);
            Field(x => x.Age, nullable: true);

            Field(x => x.Job);
        }
    }
}
