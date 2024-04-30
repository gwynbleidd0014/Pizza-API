using HashidsNet;
using Pizza.Api.Infrastructure.Middlewares;
using Pizza.Application.Services.AddressSM;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.OrderSM;
using Pizza.Application.Services.PizzaSM;
using Pizza.Application.Services.RankHistory;
using Pizza.Application.Services.UserSM;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using Pizza.Infrastructure.Repositories;
using PizzaSM.Application.Services.Pizza;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Api.Infrastructure.Exstensions;

public static class CustomServiceExtensions
{
    private static  readonly IConfigurationRoot _configuration;

     static CustomServiceExtensions()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ICrudService<PizzaRequestModel, PizzaResponseModel, PizzaUpdateModel>, PizzaService>();
        services.AddScoped<IRepository<PizzaM>, PizzaRepository>();
        services.AddScoped<ErrorHandlerMiddleware>();
        services.AddScoped<RequestResponseLogginHelper>();
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<CultureMiddleware>();
        services.AddSingleton<IHashids>(_ => new Hashids(_configuration["Salt:DefaultSalt"], int.Parse(_configuration["Salt:Length"])));
        services.AddScoped<ICrudService<UserRequestModel, UserResponseModel, UserUpdateModel>, UserService>();
        services.AddScoped<IRepository<UserM>, UserRepository>();
        services.AddScoped<ICrudService<AddressRequestModel, AddressResponseModel, AddressUpdateModel>, AddressService>();
        services.AddScoped<IRepository<AddressM>, AddressRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRepository<OrderM>, OrderRepository>();
        services.AddScoped<IRankHistoryService, RankHistoryService>();
        services.AddScoped<IRepository<RankHistoryM>, RankHistoryRepository>();

    }

    public static void UseCustomGlobalErrorHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }

    public static void RegisterCustomLoggingParameters(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestResponseLogginHelper>();
    }

    public static void UseCustomLocalization(this IApplicationBuilder app)
    {
        app.UseMiddleware<CultureMiddleware>();
    }
}
