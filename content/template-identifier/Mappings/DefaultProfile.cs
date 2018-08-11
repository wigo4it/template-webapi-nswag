
using System;
using AutoMapper;
using static template_identifier.Models.DTO.SampleModelDTO;
using static template_identifier.Models.SampleEfModel;

namespace template_identifier.Mappings
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.ISBN, m => m.MapFrom(src => src.ISBN.Replace("-","")))
                .ForMember(dest => dest.PriceDisplay, m => m.MapFrom(p=> "$"+ p.Price.ToString()))
                .ForMember(p=>p.LastQuery,m=>m.UseValue(DateTime.Now));
        }
    }
}