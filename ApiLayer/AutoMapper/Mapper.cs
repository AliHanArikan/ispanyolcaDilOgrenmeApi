using AutoMapper;
using DtoLayer.Dtos.SpanishTopicDtos;
using EntityLayer;
using System.Runtime;

namespace ApiLayer.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<EntityClass, DTOClass>(); // EntityClass'tan DTOClass'a eşleme
            //CreateMap<DTOClass, EntityClass>(); // DTOClass'tan EntityClass'a eşleme

            CreateMap<SpanishTopic,AddSpanishTopicDto>();
            CreateMap<AddSpanishTopicDto, SpanishTopic>();

            CreateMap<SpanishTopic, UpdateSpanishTopicDto>();
            CreateMap<UpdateSpanishTopicDto, SpanishTopic>();
        }
    }
}
