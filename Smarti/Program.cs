using Microsoft.Extensions.Caching.Memory;
using Smarti.Common;
using Smarti.Services;
using Smarti.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ID2Service, D2Service>();
builder.Services.AddScoped<IWebIntService, WebIntService>();
builder.Services.AddScoped<IGeneralServices, GeneralServices>();


// Add memory cache service
builder.Services.AddMemoryCache();

var app = builder.Build();
var cache = app.Services.GetRequiredService<IMemoryCache>();
Cache cacheClass = new Cache(cache);
var prioritiesResult= cacheClass.GetPriorities();



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


