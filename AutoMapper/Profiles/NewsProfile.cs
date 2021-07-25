using AutoMapper;
using InteractiveWebsite.Common.Classes.Information;
using InteractiveWebsite.Database.Entities;

namespace InteractiveWebsite.AutoMapper.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, WebNews>()
                .ForMember(w => w.Author, opt => opt.MapFrom(n => n.Author.UserName));
        }
    }
}
