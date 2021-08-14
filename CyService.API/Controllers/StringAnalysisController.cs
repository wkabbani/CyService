using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CyService.API.Models.Requests;
using CyService.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CyService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StringAnalysisController : ControllerBase
    {
        private readonly ILogger<StringAnalysisController> _logger;
        private readonly IStringAnalysisService _stringAnalysisService;

        public StringAnalysisController(ILogger<StringAnalysisController> logger, IStringAnalysisService stringAnalysisService)
        {
            _logger = logger;
            _stringAnalysisService = stringAnalysisService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult WordLengthCount(WordLengthCountRequest wordLengthCountRequest)
        {
            try
            {
                return Ok(_stringAnalysisService.GetWordLengthCount(wordLengthCountRequest.InputString));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request");
            }
        }
    }
}
