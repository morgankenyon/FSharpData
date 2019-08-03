using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSharpData.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FSharpData.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<FSharpDataContext>(
                options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FSharpData;Trusted_Connection=True;MultipleActiveResultSets=true",
                b => b.MigrationsAssembly("FSharpData.Migrations")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
