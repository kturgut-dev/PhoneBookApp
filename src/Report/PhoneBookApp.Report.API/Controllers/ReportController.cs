using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Shared.Application.API;

namespace PhoneBookApp.Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController(IReportService _service) : BaseController<Domain.Concrete.Report>
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name, CancellationToken cancellationToken)
        {
            var result = await _service.StartReportAsync(name, cancellationToken);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Accepted(new { ReportId = result.Data });
        }

        [HttpGet("{id:guid}/status")]
        public async Task<IActionResult> GetStatus(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetStatusAsync(id, cancellationToken);
            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return ReturnResult(await _service.GetAllAsync(cancellationToken));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return ReturnResult(await _service.GetByIdAsync(id, cancellationToken));
        }
    }
}