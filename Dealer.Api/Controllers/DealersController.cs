using Dealer.Api.Services.Foundations.Applicants;
using Dealer.Api.Services.Orchestrations.ExternalApplicants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dealer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealersController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        private readonly IApplicantService applicantService;

        public DealersController(
            IOrchestrationService orchestrationService,
            IApplicantService applicantService)
        {
            this.orchestrationService = orchestrationService;
            this.applicantService = applicantService;
        }
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx";

        [HttpPost("Start")]
        public async Task<IActionResult> PostApplicants()
        {
            try
            {
                await this.orchestrationService.ProcessImportRequest(filePath);
                return Ok("Import request processed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetAllApplicants")]

        public IActionResult GetAllApplicants()
        {
            var applicants = this.applicantService.RetrieveAllApplicants();

            return Ok(applicants);
        }
    }
}