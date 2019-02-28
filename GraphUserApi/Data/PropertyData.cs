using GraphUserApi.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphUserApi.Data
{
    public class PropertyData
    {
        static List<Property> data = new List<Property>();

        readonly JobData jobData;

        public PropertyData(JobData jobData)
            => this.jobData = jobData;

        public IEnumerable<Property> GetAll(string v = null)
        {
            var jobs = jobData.GetAll().ToList();

            if (string.IsNullOrWhiteSpace(v))
                return data;

            return data.Where(c => c.Id == v);
        }

        public Property Add(Property property)
        {
            data.Add(property);
            return property;
        }

        public Job GetJob(string id)
            => data.First(x => x.Id == id).Job;
    }
}
