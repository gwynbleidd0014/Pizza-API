using HashidsNet;
using Mapster;
using Pizza.Application.Services.AddressSM;
using Pizza.Application.Services.OrderSM;
using Pizza.Application.Services.PizzaSM;
using Pizza.Application.Services.RankHistory;
using Pizza.Application.Services.UserSM;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Pizza;

namespace Pizza.Api.Infrastructure.Mapping;

public static class MapsterConfiguration
{
    private static readonly IHashids _hashId;

    static MapsterConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _hashId = new Hashids(configuration["Salt:DefaultSalt"], int.Parse(configuration["Salt:Length"]));
    }
    public static void ConfigureMapster(this IServiceCollection _)
    {
        //Pizza Mapping
        TypeAdapterConfig<PizzaM, PizzaResponseModel>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Encode(src.Id));

        TypeAdapterConfig<PizzaUpdateModel, PizzaM>
            .NewConfig()
            .Map(des => des.Id, src => Decode(src.Id));

        //User Mapping
        TypeAdapterConfig<UserM, UserResponseModel>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Encode(src.Id))
            .Map(des => des.Address, src => src.Address.Select(x => _hashId.Encode(x.Id)).ToList())
            .Map(des => des.Orders, src => src.Orders.Select(x => _hashId.Encode(x.Id)).ToList());

        TypeAdapterConfig<UserUpdateModel, UserM>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Decode(src.Id).Length != 0 ? _hashId.Decode(src.Id)[0] : -1);
            
        //Address Mapping
        TypeAdapterConfig<AddressM, AddressResponseModel>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Encode(src.Id))
            .Map(des => des.UserId, src => _hashId.Encode(src.UserId))
            .Map(des => des.Orders, src => src.Orders.Select(x => _hashId.Encode(x.Id)).ToList());

        TypeAdapterConfig<AddressRequestModel, AddressM>
            .NewConfig()
            .Map(des => des.UserId, src => Decode(src.UserId));

        TypeAdapterConfig<AddressUpdateModel, AddressM>
            .NewConfig()
            .Map(des => des.UserId, src => Decode(src.UserId))
            .Map(des => des.Id, src => Decode(src.Id));

        //Order Mapping
        TypeAdapterConfig<OrderM, OrderResponseModel>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Encode(src.Id))
            .Map(des => des.UserId, src => _hashId.Encode(src.UserId))
            .Map(des => des.AddressId, src => _hashId.Encode(src.AddressId))
            .Map(des => des.PizzaIds, src => src.Pizzas.Select(x => _hashId.Encode(x.Id)));

        TypeAdapterConfig<OrderRequestModel, OrderM>
            .NewConfig()
            .Map(des => des.UserId, src => Decode(src.UserId))
            .Map(des => des.AddressId, src => Decode(src.AddressId))
            .Map(des => des.Pizzas, src => src.PizzaIds.Select(x => new PizzaM { Id = Decode(x)}));



        //RankHistory Mapping

        TypeAdapterConfig<RankHistoryM, RankHistoryResponseModel>
            .NewConfig()
            .Map(des => des.Id, src => _hashId.Encode(src.Id))
            .Map(des => des.UserId, src => _hashId.Encode(src.UserId))
            .Map(des => des.PizzaId, src => _hashId.Encode(src.PizzaId));

        TypeAdapterConfig<RankHistoryRequestModel, RankHistoryM>
            .NewConfig()
            .Map(des => des.UserId, src => Decode(src.UserId))
            .Map(des => des.PizzaId, src => Decode(src.PizzaId));
    }

    static int Decode(string str)
    {
        var rawId = _hashId.Decode(str);

        if (rawId.Length == 0)
            return -1;

        return rawId[0];
    }
}