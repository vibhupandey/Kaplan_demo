using Kaplan.Business.Contracts;
using Kaplan.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Kaplan.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    
    public class TrainningController : ControllerBase
    { 
        private readonly ITrainningService _TrainningService;
        private readonly ILogger _logger;
        public TrainningController(ITrainningService iTrainningService, ILogger<TrainningController> logger)
        {
            _TrainningService = iTrainningService;
            _logger = logger;
        }

        /// <summary>
        /// Provides  upcoming online lessons for the coming 7 days
        /// </summary>
        /// <returns> List of Tainning details</returns>
        [HttpGet, Route("TrainningDetails")]
        public ActionResult TrainningDetails()
        {
            try
            {
                return Ok(_TrainningService.TrainningDetails());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EXCEPTION ");
                return StatusCode(StatusCodes.Status500InternalServerError, Massage.Exception_code);
            }
        }

    }
}