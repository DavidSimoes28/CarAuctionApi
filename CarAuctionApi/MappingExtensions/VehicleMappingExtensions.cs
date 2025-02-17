using CarAuctionApi.Dtos;
using CarAuctionApi.Services.Models;

namespace CarAuctionApi.MappingExtensions;

/// <summary>
/// Contains the mapping extensions for vehicle
/// </summary>
public static class VehicleMappingExtensions
{

    /// <summary>
    /// Converts from list of vehicles to list of vehicleDtos
    /// </summary>
    /// <param name="vehicles">list of vehicles</param>
    /// <returns>list of vehicleDtos</returns>
    public static List<VehicleDto> ToDtos(this List<Vehicle> vehicles) => vehicles.Select(x => x.ToDto()).ToList();
}
