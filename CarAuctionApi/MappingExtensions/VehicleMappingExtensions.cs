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
            VehicleTypeDto.SUV => new Suv(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.SeetNumber ?? 0),
            VehicleTypeDto.Truck => new Truck(dto.Id, dto.Model, dto.Manufacturer, dto.Year, dto.StartingBid, dto.LoadCapacity ?? 0),
            _ => throw new ArgumentException("Invalid vehicle type"),
        };

    /// <summary>
    /// Converts from vehicle to vehicleDto
    /// </summary>
    /// <param name="vehicle">vehicle</param>
    /// <returns>vehicleDto</returns>
    /// <exception cref="ArgumentException">Invalid vehicle type</exception>
    public static VehicleDto ToDto(this Vehicle vehicle) =>
        vehicle switch
        {
            Hatchback hatchback => new VehicleDto 
            {
                Id = hatchback.Id,
                Manufacturer = hatchback.Manufacturer,
                Model = hatchback.Model,
                Year = hatchback.Year,
                Type = VehicleTypeDto.Hatchback,
                StartingBid = hatchback.StartingBid,
                DoorNumber = hatchback.DoorNumber
            },
            Sedan sedan => new VehicleDto
            {
                Id = sedan.Id,
                Manufacturer = sedan.Manufacturer,
                Model = sedan.Model,
                Year = sedan.Year,
                Type = VehicleTypeDto.Hatchback,
                StartingBid = sedan.StartingBid,
                DoorNumber = sedan.DoorNumber
            },
            Suv suv => new VehicleDto
            {
                Id = suv.Id,
                Manufacturer = suv.Manufacturer,
                Model = suv.Model,
                Year = suv.Year,
                Type = VehicleTypeDto.Hatchback,
                StartingBid = suv.StartingBid,
                SeetNumber = suv.SeetNumber
            },
            Truck truck => new VehicleDto
            {
                Id = truck.Id,
                Manufacturer = truck.Manufacturer,
                Model = truck.Model,
                Year = truck.Year,
                Type = VehicleTypeDto.Hatchback,
                StartingBid = truck.StartingBid,
                LoadCapacity = truck.LoadCapacity
            },
            _ => throw new ArgumentException("Invalid vehicle type"),
        };

    /// <summary>
    /// Converts from list of vehicles to list of vehicleDtos
    /// </summary>
    /// <param name="vehicles">list of vehicles</param>
    /// <returns>list of vehicleDtos</returns>
    public static List<VehicleDto> ToDtos(this List<Vehicle> vehicles) => vehicles.Select(ToDto).ToList();
}
