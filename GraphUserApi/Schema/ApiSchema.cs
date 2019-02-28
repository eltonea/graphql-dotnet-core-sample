using GraphQL;
using GraphUserApi.Mutations;
using GraphUserApi.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphUserApi.Schema
{
    public class ApiSchema : GraphQL.Types.Schema
    {
        public ApiSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
