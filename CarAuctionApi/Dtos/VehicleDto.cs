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
    public int? SeetNumber { get; set; }
    public int? LoadCapacity { get; set; }

}
