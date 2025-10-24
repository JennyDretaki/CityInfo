using CityInfo.API.DbContexts;
using CityInfo.API.GetCategories;
using CityInfo.API.Strategies;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container


builder.Services.AddDbContext<CityInfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CityInfoDbConnectionString")));
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler
    = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles)
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




builder.Services.AddDbContext<CityInfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CityInfoDbConnectionString")));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles)
    .AddNewtonsoftJson();
//Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
//use SSerilog for logging
builder.Host.UseSerilog();


#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IMailService, LocalMailService>();
}
else
{
    builder.Services.AddSingleton<IMailService, CloudMailService>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
