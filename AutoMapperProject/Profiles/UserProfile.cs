using AutoMapper;
using Entities;

namespace AutoMapperProject.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Dtos.PlanTypeDto, Entities.Plan>()
                .ForMember(
                dest => dest.Name,
                src => src.MapFrom(x => x.PlanName))
                .ForMember(
                dest => dest.Description,
                src => src.MapFrom(x => x.PlanDescription))
                .ForMember(
                dest => dest.Duration,
                src => src.MapFrom(x => (DateTime.Parse((x.PlanTime ?? "").ToString()) - DateTime.Now).TotalSeconds))
                .ForMember(
                dest => dest.CreatedAt,
                src => src.MapFrom(x => DateTime.Now));
            //.ForMember(
            //dest => dest.PlanTags,
            //src => src.MapFrom(x => x.Tags.Select(s => new Entities.Tag
            //{
            //    Name = s.Text
            //}
            //)));
        }
    }
}
