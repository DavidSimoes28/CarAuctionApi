using System.ComponentModel.DataAnnotations;

namespace CarAuctionApi.Services.Models;

public abstract class Vehicle(int id, string model, string manufacturer, int year, decimal startingBid)
{
    public int Id { get; set; } = id;

    [Required]
    public string Manufacturer { get; set; } = manufacturer;

    [Required]
    public string Model { get; set; } = model;

    public int Year { get; set; } = year;

    public decimal StartingBid { get; set; } = startingBid;
}
