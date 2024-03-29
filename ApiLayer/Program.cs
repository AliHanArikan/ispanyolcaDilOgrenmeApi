using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ISpanishTopicService,SpanishTopicManager>();
builder.Services.AddScoped<ISpanishTopicDal,EfSpanishTopicDal>();

builder.Services.AddScoped<ISpanishSubTopicService,SpanishSubTopicManager>();
builder.Services.AddScoped<ISpanishSubTopicDal,EfSpanishSubTopicDal>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

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
