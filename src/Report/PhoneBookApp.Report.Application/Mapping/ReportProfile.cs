using AutoMapper;
using PhoneBookApp.Report.Domain.Concrete;
using PhoneBookApp.Report.Domain.DataTransferObjects.Request;
using PhoneBookApp.Report.Domain.DataTransferObjects.Response;

namespace PhoneBookApp.Report.Application.Mapping
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Domain.Concrete.Report, ReportResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<ReportCreateRequest, Domain.Concrete.Report>();
            
            CreateMap<ReportDetail, ReportDetailResponse>();
        }
    }
}
