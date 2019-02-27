using System;
using System.Collections.Generic;
using GraphQL.Types;
using GraphUserApi.Data;

namespace GraphUserApi.Types
{
    public class PropertyType : ObjectGraphType<Property>, IGraphType
    {
        public PropertyType(PropertyData data)
        {
            Field<PropertyType>(
                "properties",
                resolve: context => data.GetAll()
            );

            Name = "PropertyType";

            Field(x => x.Name);
            Field(x => x.LastName);
            Field(x => x.Age);

            Field<JobType>(
                "job",
                resolve: context => data.GetJob(context.Source.Id)
            );
        }
    }

    public class Property
    {
        public Property() { }


        public Property(string id, string name, string lastName, int age)
        {
            Id = id;
            Age = age;
            Name = name;
            LastName = lastName;
        }

        public Property(string id, string name, string lastName, int age, Job job)
        {
            Id = id;
            Age = age;
            Name = name;
            LastName = lastName;

            Job = job;
        }

        public string Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Job Job { get; set; }
    }
}
