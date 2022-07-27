using FluentValidation.AspNetCore;
using found_church_api.Models;
using found_church_api.Services;
using found_church_api.Validatores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<FoundChurchDatabaseSettings>(
builder.Configuration.GetSection("FoundChurchDatabase"));
builder.Services.AddSingleton<ChurchesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddMvc()
  .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ChurchValidator>());
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSwagger();

app.UseCors("corsapp");
// Check the really usefull of the 39th line
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
