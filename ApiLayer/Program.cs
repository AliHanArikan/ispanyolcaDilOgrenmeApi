using ApiLayer.Extensions;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;

HangFireManager hangFireManager = new HangFireManager();
var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("10mins", new CacheProfile() { Duration = 300});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage("");
});
builder.Services.AddHangfireServer();




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

builder.Services.ConfigureResponseCaching();



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts(); 
}

app.UseHangfireDashboard();


RecurringJob.AddOrUpdate("reminder-job",()=> hangFireManager.SpanishLessonReminder(),Cron.Daily);


app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
