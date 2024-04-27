using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;

namespace ApiLayer.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<ISpanishTopicService, SpanishTopicManager>();
            services.AddScoped<ISpanishTopicDal, EfSpanishTopicDal>();

            services.AddScoped<ISpanishSubTopicService, SpanishSubTopicManager>();
            services.AddScoped<ISpanishSubTopicDal, EfSpanishSubTopicDal>();

            services.AddScoped<ISpanishLectureDal, EfSpanishLectureDal>();
            services.AddScoped<ISpanishLectureService, SpanishLectureManager>();

            services.AddScoped<ISpanishExamDal, EfSpanishExamDal>();
            services.AddScoped<ISpanishExamService, SpanishExamManager>();

            services.AddScoped<ISpanishShortDescriptionDal, EfSpanishShortDescription>();
            services.AddScoped<ISpanishShortDescriptionService, SpanishShortDescriptionManager>();

        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService,LoggerManager>();  
        }
    }
}
