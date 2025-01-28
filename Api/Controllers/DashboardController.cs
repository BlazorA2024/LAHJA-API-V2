
using Api.Repositories;
using Api.Repositories.DachRepository;
using Api.ServiceLayer.LayerModel;
using ASG.Api2.Results;
using AutoMapper;
using Dto;
using Dto.DachBoard;
using Dto.ModelAi;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace ASG.Api2.Controllers
{



    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IPlanVisualizationRepository _planRepository;
        private readonly IRequestVisualizationRepository _serviceDataRepository;
        private readonly IServiceVisualizationRepository _visualizationRepository;
        private readonly  ISpaceRepository _spaceRepository;

        public DashboardController(IPlanVisualizationRepository planRepository, 
            IRequestVisualizationRepository serviceDataRepository,
            IServiceVisualizationRepository visualizationRepository, ISpaceRepository spaceRepository)
        {
            _planRepository = planRepository;
            _serviceDataRepository = serviceDataRepository;
            _visualizationRepository = visualizationRepository;
            _spaceRepository = spaceRepository;
        }

        [HttpGet("PlotPlanDataServices")]

        public async Task<ActionResult<List<ServiceUsageData>>> GetServiceUsageData()
        {
            var plot = _planRepository.GetServiceUsageData();
            return Ok(plot); // Convert Plotly object to JSON

        }

        [HttpGet("PlotPlanData")]
        public async Task<ActionResult<List<ServiceUsageData>>> GetPlanDataPlot()
        {
            var plot = _serviceDataRepository.GetServiceUsageData();
            return Ok(plot);
        }


        [HttpGet("GetErrorsByTime")]
        public async Task<ActionResult<List<ServiceDataTod>>> GetErrorsByTime()
        {
            var plot = _visualizationRepository.GetErrorsByTime();
            return Ok(plot);
        }
        [HttpGet("GetRequestsByTime")]
        public async Task<ActionResult<List<RequestData>>> GetRequestsByTime()
        {
            var plot = _visualizationRepository.GetRequestsByTime();
            return Ok(plot);
        }


        [HttpGet("FilterFService")]
        public async Task<ActionResult<List<RequestData>>> FilterServiceData([FromQuery] string serviceType = "ALL")
        {
            var data = _visualizationRepository.FilterServiceData(serviceType);
            return Ok(data);
        }
        [HttpGet("GetByToken/{token}")]
        public async Task<IActionResult> GetByTokenAsync(string token)
        {
            var space = await _spaceRepository.GetByTokenAsync(token);
            if (space == null)
            {
                return NotFound(new { message = "Space not found." });
            }
            return Ok(space);
        }

        // Get spaces by subscription ID
        [HttpGet("GetBySubscriptionId/{subscriptionId}")]
        public async Task<IActionResult> GetBySubscriptionIdAsync(string subscriptionId)
        {
            var spaces = await _spaceRepository.GetBySubscriptionIdAsync(subscriptionId);
            if (spaces == null || !spaces.Any())
            {
                return NotFound(new { message = "No spaces found for the given subscription ID." });
            }
            return Ok(spaces);
        }

        // Get spaces by RAM size
        [HttpGet("GetSpacesByRamAsync/{ram}")]
        public async Task<IActionResult> GetSpacesByRamAsync(int ram)
        {
            var spaces = await _spaceRepository.GetSpacesByRamAsync(ram);
            if (spaces == null || !spaces.Any())
            {
                return NotFound(new { message = "No spaces found with the specified RAM size." });
            }
            return Ok(spaces);
        }
 
    }
}

 
