using AutoMapper;
using Library.Domain.Data;
using Library.Presentation.Models;
using System;

namespace Library.Presentation.App_Start.Profiles
{
    public class ViewModelToEntityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<AuthorViewModel, Author>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<LanguageViewModel, Language>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Descricao, opt => opt.MapFrom(x => x.Description));

            CreateMap<CompanyViewModel, PublishingCompany>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<BookViewModel, Book>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.SpecialEdition, opt => opt.MapFrom(x => x.Special))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => Convert.FromBase64String(x.Image)))
                .ForMember(x => x.Company, opt => opt.MapFrom(x => x.Company))
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author))
                .ForMember(x => x.PagesNumber, opt => opt.MapFrom(x => x.PagesNumber))
                .ForMember(x => x.Number, opt => opt.MapFrom(x => x.Number))
                .ForMember(x => x.Year, opt => opt.MapFrom(x => x.Year))
                .ForMember(x => x.Language, opt => opt.MapFrom(x => x.Language));
        }
    }
}