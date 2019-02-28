﻿using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Types;

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
        }
    }
}
