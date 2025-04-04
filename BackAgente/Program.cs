using BackAgente.Repositorios;
using BackAgente.Services;
var builder = WebApplication.CreateBuilder(args);
// Agregar servicios al contenedor
builder.Services.AddSingleton<SQLservice>(new SQLservice(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<NinjaOneRepo>();
builder.Services.AddScoped<OrganizationsRepo>();
builder.Services.AddScoped<GetLocationsRepo>();
builder.Services.AddScoped<AgenteRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});
builder.Logging.AddConsole();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{

}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();