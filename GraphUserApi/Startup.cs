using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphUserApi.Data;
using GraphUserApi.Mutations;
using GraphUserApi.Mutations.Inputs;
using GraphUserApi.Queries;
using GraphUserApi.Schema;
using GraphUserApi.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphUserApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<JobData>();
            services.AddSingleton<JobType>();
            services.AddSingleton<JobInputType>();

            services.AddSingleton<CompanyType>();
            services.AddSingleton<CompanyInputType>();

            services.AddSingleton<UserData>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserMutation>();
            services.AddSingleton<UserInputType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ApiSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseGraphiQl();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
