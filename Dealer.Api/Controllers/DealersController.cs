using Dealer.Api.Models.Applicants;
using Dealer.Api.Services.Orchestrations.ExternalApplicants;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class DealersController : Controller
    {
        private readonly OrchestrationService orchestrationService;

        public DealersController(OrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
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

    }
}