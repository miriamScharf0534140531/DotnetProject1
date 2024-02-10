using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Subscriber.core.Interfaces.BL;
using Subscriber.core.Interfaces.DAL;
using Subscriber.DAL;
using Subscriber.Data;
using Subscriber.Services_BL;
using WeightWatchers.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ISubsciberRepository, SubscriberRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new WeightWatdherProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<WeightWatcherContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("WeightWatchersConnectionString"));
}
 );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
