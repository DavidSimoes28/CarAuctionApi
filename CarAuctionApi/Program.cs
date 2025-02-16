using CarAuctionApi.Dtos;
using CarAuctionApi.Infrastructure;
using CarAuctionApi.MappingExtensions;
using CarAuctionApi.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AuctionService>();
builder.Services.AddSingleton<InventoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var vehicleGroup = app.MapGroup("api/vehicles");

vehicleGroup.MapPost("", ([FromBody] VehicleDto dto, InventoryService service) =>
{
    var result = service.AddVehicle(dto);
    
    if (!result.IsValid)
        return Results.Problem(result.ToProblemDetails());

    return Results.Created();
});

vehicleGroup.MapGet("", (VehicleTypeDto? type, string? model, int? year, InventoryService service) =>
{
    var result = service.GetVehicles(type, model, year);

    if (!result.IsValid)
        return Results.Problem(result.ToProblemDetails());

    return Results.Ok(result.Result?.ToDtos());
});

var auctionGroup = app.MapGroup("api/auctions");

auctionGroup.MapPost("start", ([FromBody] AuctionDto dto, AuctionService service) =>
{
    var result = service.StartAuction(dto.VehicleId);

    if (!result.IsValid)
        return Results.Problem(result.ToProblemDetails());

    return Results.Ok();
});

auctionGroup.MapPatch("place-bid", ([FromBody] AuctionPlaceBidDto dto, AuctionService service) =>
{
    var result = service.PlaceBid(dto.VehicleId, dto.Bid);

    if (!result.IsValid)
        return Results.Problem(result.ToProblemDetails());

    return Results.Ok();
});

auctionGroup.MapPatch("close", ([FromBody] AuctionDto dto, AuctionService service) =>
{
    var result = service.CloseAuction(dto.VehicleId);

    if (!result.IsValid)
        return Results.Problem(result.ToProblemDetails());

    return Results.Ok();
});

await app.RunAsync();

public partial class Program
{
    protected Program() { }
}