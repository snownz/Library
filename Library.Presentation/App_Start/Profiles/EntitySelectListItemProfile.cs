using AutoMapper;
using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Presentation.App_Start.Profiles
{
    public class EntitySelectListItemProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Author, SelectListItem>()
                   .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id))
                   .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Name));

            CreateMap<Language, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Descricao));

            CreateMap<PublishingCompany, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Name));
        }
    }
}