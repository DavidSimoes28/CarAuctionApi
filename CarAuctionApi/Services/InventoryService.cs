using CarAuctionApi.Dtos;
using CarAuctionApi.Infrastructure;
using CarAuctionApi.MappingExtensions;
using CarAuctionApi.Services.Models;
using CarAuctionApi.Services.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace CarAuctionApi.Services;

public class InventoryService
{
    private readonly List<Vehicle> vehicles = [];

    /// <summary>
    /// Returns a list of filtered vehicles
    /// </summary>
    /// <param name="type">vehicle type</param>
    /// <param name="model">model</param>
    /// <param name="year">year</param>
    public EndpointResult<List<Vehicle>> GetVehicles(VehicleTypeDto? type = null, string? model = null, int? year = null)
    {
        var filteredVehicles = vehicles.AsEnumerable();
        
        if(model is not null)
            filteredVehicles = filteredVehicles.Where(x => x.Model == model);
        if(year is not null)
            filteredVehicles = filteredVehicles.Where(x => x.Year == year);
        if (type is not null)
            filteredVehicles = GetVehiclesByType(filteredVehicles, type.Value);

        return new EndpointResult<List<Vehicle>>(filteredVehicles.ToList());
    }

    /// <summary>
    /// Returns a vehicle
    /// </summary>
    /// <param name="vehicleId">vehicle id</param>
    /// <returns>vehicle</returns>
    public Vehicle? GetVehicle(int vehicleId)
    {
        return vehicles.FirstOrDefault(x => x.Id == vehicleId);
    }

    /// <summary>
    /// Inserts a new vehicle
    /// </summary>
    /// <param name="dto">vehicle dto</param>
    public EndpointResult<Vehicle> AddVehicle(VehicleDto dto)
    {
        if (vehicles.Any(x => x.Id == dto.Id))
            return new EndpointResult<Vehicle>($"Vehicle with id {dto.Id} already exists");

        var vehicle = dto.ToModel();
        
        var validationResult = ValidateVehicle(vehicle);
        
        if(!validationResult.IsValid)
            return new EndpointResult<Vehicle>(validationResult.Errors);

        vehicles.Add(vehicle);

        return new EndpointResult<Vehicle>(vehicle);
    }

    /// <summary>
    /// Returns a vehicle by type
    /// </summary>
    /// <param name="vehicles">vehicles</param>
    /// <param name="type">vhicle type</param>
    /// <exception cref="ArgumentException">invalid vehicle type</exception>
    private static IEnumerable<Vehicle> GetVehiclesByType(IEnumerable<Vehicle> vehicles, VehicleTypeDto type)
    {
        return type switch
        {
            VehicleTypeDto.Hatchback => vehicles.OfType<Hatchback>(),
            VehicleTypeDto.Sedan => vehicles.OfType<Sedan>(),
            VehicleTypeDto.SUV => vehicles.OfType<Suv>(),
            VehicleTypeDto.Truck => vehicles.OfType<Truck>(),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }

    /// <summary>
    /// Validate vehicle
    /// </summary>
    /// <param name="vehicle">vehicle</param>
    /// <exception cref="ArgumentException">invalid vehicle type</exception>
    private static ValidationResult ValidateVehicle(Vehicle vehicle)
    {
        return vehicle switch
        {
            Hatchback hatchback => new VehicleWithDoorsValidator().Validate(hatchback),
            Sedan sedan => new VehicleWithDoorsValidator().Validate(sedan),
            Suv suv => new SuvValidator().Validate(suv),
            Truck truck => new TruckValidator().Validate(truck),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}
