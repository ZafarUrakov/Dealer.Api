using Dealer.Api.Brokers.DateTimes;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Brokers.Spreadsheets;
using Dealer.Api.Brokers.Storages;
using Dealer.Api.Services.Foundations.Applicants;
using Dealer.Api.Services.Foundations.ExternalApplicants;
using Dealer.Api.Services.Foundations.Groups;
using Dealer.Api.Services.Foundations.Spreadsheets;
using Dealer.Api.Services.Orchestrations.ExternalApplicants;
using Dealer.Api.Services.Processings.Applicants;
using Dealer.Api.Services.Processings.ExternalApplicants;
using Dealer.Api.Services.Processings.Groups;
using Dealer.Api.Services.Processings.Spreadsheets;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dealer.Api", Version = "v1" });
            });
            services.AddControllers();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddDbContext<IStorageBroker, StorageBroker>();
            services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IExternalApplicantService, ExternalApplicantService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ISpreadsheetService, SpreadsheetService>();
            services.AddTransient<IOrchestrationService, OrchestrationService>();
            services.AddTransient<IApplicantProcessingService, ApplicantProcessingService>();
            services.AddTransient<IExternalApplicantProcessingService, ExternalApplicantProcessingService>();
            services.AddTransient<IGroupProcessingService, GroupProcessingService>();
            services.AddTransient<ISpreadsheetProcessingService, SpreadsheetProcessingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dealer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}