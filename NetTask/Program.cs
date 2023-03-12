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
builder.Services.AddHealthChecks();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer();
#endregion

#region Configure Pipeline
var app = builder.Build();

app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/health");
app.MapControllers();
app.Run();
#endregion