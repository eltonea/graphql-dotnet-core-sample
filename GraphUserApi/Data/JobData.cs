using GraphUserApi.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphUserApi.Data
{
    public class JobData
    {
        public IEnumerable<Job> GetAll(string v = null)
        {
            var data = new List<Job>
            {
                new Job("1", "Software Engineer"),
                new Job("2", "Software Engineer"),
                new Job("3", "Data Engineer")
            };

            if (string.IsNullOrWhiteSpace(v))
                return data;

            return data.Where(c => c.Id == v);
        }
    }
}
