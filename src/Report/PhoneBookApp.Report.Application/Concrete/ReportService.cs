using AutoMapper;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Report.Infrastructure.Abstract;

namespace PhoneBookApp.Report.Application.Concrete
{
    public class ReportService(IReportRepository _reportRepository, IMapper _mapper) : IReportService
    {

    }
}
