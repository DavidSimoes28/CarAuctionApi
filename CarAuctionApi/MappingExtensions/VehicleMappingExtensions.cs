using CarAuctionApi.Dtos;
using CarAuctionApi.Services.Models;

namespace CarAuctionApi.MappingExtensions;

/// <summary>
/// Contains the mapping extensions for vehicle
/// </summary>
public static class VehicleMappingExtensions
{
    /// <summary>
    /// Converts from vehicleDto to vehicle
    /// </summary>
    /// <param name="dto">vehicleDto</param>
    /// <returns>Vehicle</returns>
    /// <exception cref="ArgumentException">Invalid vehicle type</exception>
    public static Vehicle ToModel(this VehicleDto dto) =>
        dto.Type switch
        {
            VehicleTypeDto.Hatchback => new Hatchback(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.DoorNumber ?? 0),
            VehicleTypeDto.Sedan => new Sedan(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.DoorNumber ?? 0),
            VehicleTypeDto.SUV => new Suv(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.SeatNumber ?? 0),
            VehicleTypeDto.Truck => new Truck(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.LoadCapacity ?? 0),
            _ => throw new ArgumentException("Invalid vehicle type"),
        };

    /// <summary>
    /// Converts from vehicle to vehicleDto
    /// </summary>
    /// <param name="vehicle">vehicle</param>
    /// <returns>vehicleDto</returns>
    /// <exception cref="ArgumentException">Invalid vehicle type</exception>
    public static VehicleDto ToDto(this Vehicle vehicle)
    {
        var dto = new VehicleDto
        {
            Id = vehicle.Id,
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            Year = vehicle.Year,
            Type = VehicleTypeDto.Hatchback,
            StartingBid = vehicle.StartingBid
        };

        switch (vehicle)
        {
            case Hatchback hatchback:
                dto.DoorNumber = hatchback.DoorNumber;
                dto.Type = VehicleTypeDto.Hatchback;
                break;
            case Sedan sedan:
                dto.DoorNumber = sedan.DoorNumber;
                dto.Type = VehicleTypeDto.Sedan;
                break;
            case Suv suv:
                dto.SeatNumber = suv.SeatNumber;
                dto.Type = VehicleTypeDto.SUV;
                break;
            case Truck truck:
                dto.LoadCapacity = truck.LoadCapacity;
                dto.Type = VehicleTypeDto.Truck;
                break;
        }

        return dto;
    }

    /// <summary>
    /// Converts from list of vehicles to list of vehicleDtos
    /// </summary>
    /// <param name="vehicles">list of vehicles</param>
    /// <returns>list of vehicleDtos</returns>
    public static List<VehicleDto> ToDtos(this List<Vehicle> vehicles) => vehicles.Select(ToDto).ToList();
}
