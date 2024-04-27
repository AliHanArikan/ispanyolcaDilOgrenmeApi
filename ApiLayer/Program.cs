using ApiLayer.Extensions;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<ISpanishTopicService,SpanishTopicManager>();
//builder.Services.AddScoped<ISpanishTopicDal,EfSpanishTopicDal>();

//builder.Services.AddScoped<ISpanishSubTopicService,SpanishSubTopicManager>();
//builder.Services.AddScoped<ISpanishSubTopicDal,EfSpanishSubTopicDal>();

//builder.Services.AddScoped<ISpanishLectureDal,EfSpanishLectureDal>();
//builder.Services.AddScoped<ISpanishLectureService, SpanishLectureManager>();

//builder.Services.AddScoped<ISpanishExamDal,EfSpanishExamDal>();
//builder.Services.AddScoped<ISpanishExamService,SpanishExamManager>();

//builder.Services.AddScoped<ISpanishShortDescriptionDal, EfSpanishShortDescription>();
//builder.Services.AddScoped<ISpanishShortDescriptionService, SpanishShortDescriptionManager>();

builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
