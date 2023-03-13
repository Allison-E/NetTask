var builder = WebApplication.CreateBuilder(args);

#region Configure Services
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
builder.Services.AddControllers();
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
app.UseHealthChecks("/health");
app.MapControllers();
await dbCreating;
app.Run();
#endregion