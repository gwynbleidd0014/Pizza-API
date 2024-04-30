using FluentValidation;
using FluentValidation.AspNetCore;
using Pizza.Api.Infrastructure.Exstensions;
using Pizza.Api.Infrastructure.GlobalErrorHander;
using Pizza.Api.Infrastructure.Mapping;
using Pizza.Persistence;
using Serilog;
using Serilog.Events;
using System.Reflection;



Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();


try
{
    Log.Information("Starting web app");
    var builder = WebApplication.CreateBuilder(args);
    //Configure Serilog
    builder.Logging.ClearProviders();
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
    // Add services to the container.
    builder.Services.AddConfiguredSwagger();
    builder.Services.AddCustomVersioning();
    builder.Services.AddCustomServices();
    builder.Services.ConfigureMapster();
    builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    builder.Services.AddControllers();
    builder.Services.Configure<ConnectionStrings>(
        builder.Configuration.GetSection(nameof(ConnectionStrings)));
    builder.Services.Configure<ErrorLogging>(
        builder.Configuration.GetSection(nameof(ErrorLogging)));



    var app = builder.Build();
    app.UseCustomGlobalErrorHandling();
    app.UseCustomLocalization();
    app.RegisterCustomLoggingParameters();
    app.UseSerilogRequestLogging(configure =>
    {
        configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} {ClientIp} responded {StatusCode} in {Elapsed:0.0000}ms";
    });



    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(opts =>
        {
            opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            opts.RoutePrefix = string.Empty;
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    await Log.CloseAndFlushAsync();
}

return 0;