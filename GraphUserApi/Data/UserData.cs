using GraphUserApi.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphUserApi.Data
{
    public class UserData
    {
        static List<User> data = new List<User>();

        readonly JobData jobData;

        public UserData(JobData jobData)
            => this.jobData = jobData;

        public User Update(User user)
        {
            var userStatic = data.First(x => x.Id == user.Id);
            userStatic.Name = user.Name;
            userStatic.LastName = user.LastName;
            userStatic.Age = user.Age;
            userStatic.Job = user.Job;
            return userStatic;
        }

        public IEnumerable<User> GetAll(string v = null)
        {
            var jobs = jobData.GetAll().ToList();

            if (string.IsNullOrWhiteSpace(v))
                return data;

            return data.Where(c => c.Id == v);
        }

        public User Add(User property)
        {
            property.Id = Guid.NewGuid().ToString();
            data.Add(property);
            return property;
        }

        public Job GetJob(string id)
            => data.First(x => x.Id == id).Job;
    }
}
