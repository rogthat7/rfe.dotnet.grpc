using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using rfe.dotnet.grpc.core.Interfaces.Models;
using rfe.dotnet.grpc.core.Models.Shared;
using rfe.dotnet.grpc.server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rfe.dotnet.grpc.server
{
    public class Startup
    {
        private UnitOfWork _unitOfWork;
        /// <summary>
        /// Configuration
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddHttpClient();
            services.AddScoped<IUnitOfWork, UnitOfWork>(serviceProvider =>
            {
                var connectionString = Configuration.GetConnectionString("MongoConectionURL");
               _unitOfWork =  connectionString.IsNullOrEmpty() ? new UnitOfWork(): new UnitOfWork(connectionString);        
                return _unitOfWork;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
