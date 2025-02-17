using CarAuctionApi.Dtos;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CarAuctionApi.Services.Models;

public abstract class Vehicle(int id, string model, string manufacturer, int year, decimal startingBid) : IVehicle
{
    public int Id { get; set; } = id;

    [Required]
    public string Manufacturer { get; set; } = manufacturer;

    [Required]
    public string Model { get; set; } = model;

    public int Year { get; set; } = year;

    public decimal StartingBid { get; set; } = startingBid;

    public abstract ValidationResult Validate();

    public abstract VehicleDto ToDto();
}
