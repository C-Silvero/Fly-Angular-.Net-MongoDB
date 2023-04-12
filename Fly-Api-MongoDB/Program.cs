using fly_API.Services;
using Fly_Api_MongoDB.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FlySettings>(builder.Configuration.GetSection(nameof(FlySettings)));

builder.Services.AddSingleton<IFlySettings>(d =>
d.GetRequiredService<IOptions<FlySettings>>().Value);

builder.Services.AddSingleton<FlyService>();

builder.Services.AddCors();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//services.AddControllersWithViews();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyCorsPolicy");

app.MapControllers();

app.Run();
