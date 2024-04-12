using ExcelComparer.Domain.Commands;
using ExcelComparer.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExcelComparerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompareController : ControllerBase
    {
        private readonly ILogger<CompareController> _logger;
        private readonly IMediator _mediator;

        public CompareController(ILogger<CompareController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CompareFiles")]
        public async Task<ExcelCompareResponse> CompareFilesAsync([FromBody] string[] files)
        {
            var command = new ExcelCompareCommand()
            {
                fileA = files.First(),
                fileB = files.Last()
            };

            var t = await _mediator.Send(command);
            return t;
        }
    }
}