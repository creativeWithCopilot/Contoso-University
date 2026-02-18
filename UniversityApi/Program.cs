using Microsoft.EntityFrameworkCore; 
using UniversityApi.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext with SQLite 
builder.Services.AddDbContext<UniversityContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("UniversityDatabase")));
// Add controllers
builder.Services.AddControllers();
// Add CORS policy 
builder.Services.AddCors(options => 
{ 
    options.AddPolicy("AllowFrontend", 
        policy => 
        { 
            policy.WithOrigins("https://localhost:7091") // Blazor WASM port 
            .AllowAnyHeader() 
            .AllowAnyMethod(); 
        }); 
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS 
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
