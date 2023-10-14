using Dealer.Api.Brokers.DateTimes;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Brokers.Spreadsheets;
using Dealer.Api.Brokers.Storages;
using Dealer.Api.Services.Foundations.Applicants;
using Dealer.Api.Services.Foundations.ExternalApplicants;
using Dealer.Api.Services.Foundations.Groups;
using Dealer.Api.Services.Orchestrations.ExternalApplicants;
using Dealer.Api.Services.Processings.Applicants;
using Dealer.Api.Services.Processings.ExternalApplicants;
using Dealer.Api.Services.Processings.Groups;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Dealer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = "Dealer.Api",
                Version = "v1"
            };

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: openApiInfo);
            });

            services.AddControllers();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddDbContext<IStorageBroker, StorageBroker>();
            services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IExternalApplicantService, ExternalApplicantService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IOrchestrationService, OrchestrationService>();
            services.AddTransient<IApplicantProcessingService, ApplicantProcessingService>();
            services.AddTransient<IExternalApplicantProcessingService, ExternalApplicantProcessingService>();
            services.AddTransient<IGroupProcessingService, GroupProcessingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint(
                    url:"/swagger/v1/swagger.json",
                    name: "Dealer.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}