using AutoMapper;
using Library.Domain.Data;
using Library.Presentation.Models;
using System;
using System.Linq;

namespace Library.Presentation.App_Start.Profiles
{
    public class EntityToModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Author, AuthorViewModel>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<Language, LanguageViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Descricao));

            CreateMap<PublishingCompany, CompanyViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.ID, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Special, opt => opt.MapFrom(x => x.SpecialEdition))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => Convert.ToBase64String(x.Image)))
                .ForMember(x => x.Rate, opt => opt.MapFrom(x => x.Rating.Average(y=>y.Rate)))
                .ForMember(x => x.Company, opt => opt.MapFrom(x => x.Company))
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author))
                .ForMember(x => x.PagesNumber, opt => opt.MapFrom(x => x.PagesNumber))
                .ForMember(x => x.Number, opt => opt.MapFrom(x => x.Number))
                .ForMember(x => x.Year, opt => opt.MapFrom(x => x.Year))
                .ForMember(x => x.Language, opt => opt.MapFrom(x => x.Language));

        }
    }
}