using Housing;
using Housing.Configuration;
using Housing.Data;
using Housing.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);


//Using Serilog
Log.Logger = new LoggerConfiguration().WriteTo.File("C:\\Users\\Ben\\Desktop\\C# webapi\\Housing\\Housing\\log",
    outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff zzz}} [{Level:u3}] {Message:ij}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information).CreateLogger();

builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("AllowAll",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


//setting up database
builder.Services.AddDbContext<DatabaseContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//Adding Identity
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1",new OpenApiInfo{Title = "Housing",Version = "v1"}));

builder.Services.AddControllers().AddNewtonsoftJson(op =>
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



try
{
    Log.Information("Application has Started.");


    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Housing v1"));
    }

    // Adding Cors
    app.UseCors("AllowAll");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch(Exception ex)
{
    Log.Fatal(ex,"Application Failed to Start.");
}
finally
{
    Log.CloseAndFlush();
}
