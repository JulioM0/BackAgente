using BackAgente.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<NinjaOneRepo>();
builder.Services.AddScoped<OrganizacionesRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Logging.AddConsole();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Puedes activar Swagger si lo necesitas temporalmente para pruebas
     //app.UseSwagger();
     //app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
