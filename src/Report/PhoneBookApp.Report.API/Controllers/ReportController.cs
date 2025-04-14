using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Shared.Application.API;

namespace PhoneBookApp.Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController(IReportService service)
    {
    }
}
