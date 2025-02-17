using CarAuctionApi.Dtos;

namespace CarAuctionApi.Services.Models;

public interface IVehicle : IValidatable
{
    /// <summary>
    /// Converts from vehicle to vehicleDto
    /// </summary>
    /// <param name="vehicle">vehicle</param>
    /// <returns>vehicleDto</returns>
    public VehicleDto ToDto();
}
