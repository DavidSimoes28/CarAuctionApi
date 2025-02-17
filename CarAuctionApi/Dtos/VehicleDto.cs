using CarAuctionApi.Services.Models;

namespace CarAuctionApi.Dtos;

public class VehicleDto
{
    public int Id { get; set; }
    public VehicleTypeDto Type { get; set; }
    public required string Manufacturer { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public decimal StartingBid { get; set; }
    public int? DoorNumber { get; set; }
    public int? SeatNumber { get; set; }
    public int? LoadCapacity { get; set; }

    /// <summary>
    /// Converts from vehicleDto to vehicle
    /// </summary>
    /// <param name="dto">vehicleDto</param>
    /// <returns>Vehicle</returns>
    /// <exception cref="ArgumentException">Invalid vehicle type</exception>
    public Vehicle ToModel() =>
        Type switch
        {
            VehicleTypeDto.Hatchback => new Hatchback(Id, Model, Manufacturer, Year, StartingBid, DoorNumber ?? 0),
            VehicleTypeDto.Sedan => new Sedan(Id, Model, Manufacturer, Year, StartingBid, DoorNumber ?? 0),
            VehicleTypeDto.SUV => new Suv(Id, Model, Manufacturer, Year, StartingBid, SeatNumber ?? 0),
            VehicleTypeDto.Truck => new Truck(Id, Model, Manufacturer, Year, StartingBid, LoadCapacity ?? 0),
            _ => throw new ArgumentException("Invalid vehicle type"),
        };

}
