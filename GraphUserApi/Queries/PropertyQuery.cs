using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Types;
using System;

namespace GraphUserApi.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(PropertyData propertyData, JobData jobData)
        {
            Name = "PropertyQuery";

            Field<ListGraphType<PropertyType>>(
                "properties",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of the property" }
                ),
                resolve: content => propertyData.GetAll(content.GetArgument<string>("id")));

            Field<JobType>(
                "job",
                resolve: content => propertyData.GetJob(content.GetArgument<string>("id"))
            );

            //Func<ResolveFieldContext, string, Job> func = (content, id) => propertyData.GetJob(id);

            //FieldDelegate<JobType>(
            //    "job",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the job" }
            //    ),
            //    resolve: func
            //);
        }
    }
}
