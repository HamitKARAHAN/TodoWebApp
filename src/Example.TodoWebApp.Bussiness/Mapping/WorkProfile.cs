using AutoMapper;
using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Data.Domains;

namespace Example.TodoWebApp.Bussiness.Mapping
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}
