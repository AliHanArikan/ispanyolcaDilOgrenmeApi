using AutoMapper;
using DtoLayer.Dtos.SpanishExamDtos;
using DtoLayer.Dtos.SpanishLectureDtos;
using DtoLayer.Dtos.SpanishSubTopicDtos;
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

            //SpanishTopic
            CreateMap<SpanishTopic,AddSpanishTopicDto>();
            CreateMap<AddSpanishTopicDto, SpanishTopic>();

            CreateMap<SpanishTopic, UpdateSpanishTopicDto>();
            CreateMap<UpdateSpanishTopicDto, SpanishTopic>();

            //SpanishSubTopic
            CreateMap<SpanishSubTopic, AddSpanishSubTopicDto>();
            CreateMap<AddSpanishSubTopicDto,SpanishSubTopic>();

            CreateMap<SpanishSubTopic, UpdateSpanishSubTopicDto>();
            CreateMap<UpdateSpanishSubTopicDto, SpanishSubTopic>();

            //SpanishLecture
            CreateMap<SpanishLecture,AddSpanishLectureDto>();
            CreateMap<AddSpanishLectureDto, SpanishLecture>();


            //SpanishExam
            CreateMap<SpanishExam, AddSpanishExamDto>();
            CreateMap<AddSpanishExamDto, SpanishExam>();

        }
    }
}
