﻿using System.Text.Json;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.AllowTrailingCommas = true;
        opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerExtension();
builder.Services.AddHealthChecks();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
#endregion

#region Configure Pipeline
var app = builder.Build();

var dbCreating = app.CreateDatabaseAsync();
app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapControllers();
await dbCreating;
app.Run();
#endregion