using System;
using System.Collections.Generic;
using GraphQL.Types;
using GraphUserApi.Data;

namespace GraphUserApi.Types
{
    public class UserType : ObjectGraphType<User>, IGraphType
    {
        public UserType(UserData data)
        {
            Field<UserType>(
                "users",
                resolve: context => data.GetAll()
            );

            Name = "UserType";

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.LastName);
            Field(x => x.Age);

            Field<JobType>(
                "job",
                resolve: context => context.Source.Job
                //resolve: context => data.GetJob(context.Source.Id) //TODO: get from another source
            );
        }
    }

    public class User
    {
        public User() { }


        public User(string id, string name, string lastName, int age)
        {
            Id = id;
            Age = age;
            Name = name;
            LastName = lastName;
        }

        public User(string id, string name, string lastName, int age, Job job)
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
