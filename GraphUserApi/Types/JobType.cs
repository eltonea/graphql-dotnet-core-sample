﻿using GraphQL.Types;
using GraphUserApi.Data;

namespace GraphUserApi.Types
{
    public class JobType : ObjectGraphType<Job>
    {
        public JobType(JobData data)
        {
            Field<UserType>(
                "jobs",
                resolve: context => data.GetAll()
            );

            Name = "JobType";

            Field(x => x.Name);
            Field(x => x.Since);
            Field<CompanyType>("company");
        }
    }

    public class Job
    {
        public Job() { }

        public Job(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Since { get; set; }
        public Company Company { get; set; }
    }
}
