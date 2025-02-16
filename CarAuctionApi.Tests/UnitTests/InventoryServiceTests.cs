using CarAuctionApi.Dtos;
using CarAuctionApi.Services;
using CarAuctionApi.Services.Models;

namespace CarAuctionApi.Tests.UnitTests;

public class InventoryServiceTests
{
    private readonly InventoryService seededInventoryService;

    public InventoryServiceTests()
    {
        seededInventoryService = new InventoryService();
        seededInventoryService.AddVehicle(new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        });
        seededInventoryService.AddVehicle(new VehicleDto
        {
            Id = 2,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturerSedan",
            Model = "modelSedan",
            Year = 2019,
            StartingBid = 20000,
            DoorNumber = 5,
        });
        seededInventoryService.AddVehicle(new VehicleDto
        {
            Id = 3,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturerSUV",
            Model = "modelSUV",
            Year = 2020,
            StartingBid = 20000,
            SeetNumber = 5,
        });
        seededInventoryService.AddVehicle(new VehicleDto
        {
            Id = 4,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "manufacturerTruck",
            Model = "modelTruck",
            Year = 2020,
            StartingBid = 20000,
            LoadCapacity = 5,
        });
    }

    [Fact]
    public void Should_Successed_WhenValidHatchback()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.NotNull(result.Result);
        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
        Assert.True(result.Result is Hatchback);
    }

    [Fact]
    public void Should_Fail_WhenHatchbackDoorNumberNull()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Invalid door number", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenHatchbackInvalidInputs()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "",
            Model = "",
            Year = -1,
            StartingBid = -1,
            DoorNumber = -1,
            SeetNumber = -1,
            LoadCapacity = -1,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Model bust not be empty", result.Errors);
        Assert.Contains("Manufacturer bust not be empty", result.Errors);
        Assert.Contains("Invalid year", result.Errors);
        Assert.Contains("Invalid stating bid", result.Errors);
        Assert.Contains("Invalid door number", result.Errors);
    }

    [Fact]
    public void Should_Successed_WhenValidSedan()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.NotNull(result.Result);
        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
        Assert.True(result.Result is Sedan);
    }

    [Fact]
    public void Should_Fail_WhenSedanDoorNumberNull()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Invalid door number", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenSedanInvalidInputs()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "",
            Model = "",
            Year = -1,
            StartingBid = -1,
            DoorNumber = -1,
            SeetNumber = -1,
            LoadCapacity = -1,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Model bust not be empty", result.Errors);
        Assert.Contains("Manufacturer bust not be empty", result.Errors);
        Assert.Contains("Invalid year", result.Errors);
        Assert.Contains("Invalid stating bid", result.Errors);
        Assert.Contains("Invalid door number", result.Errors);
    }

    [Fact]
    public void Should_Successed_WhenValidTruck()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.NotNull(result.Result);
        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
        Assert.True(result.Result is Truck);
    }

    [Fact]
    public void Should_Fail_WhenTruckLoadCapacityNull()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Invalid load capacity", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenTruckInvalidInputs()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "",
            Model = "",
            Year = -1,
            StartingBid = -1,
            DoorNumber = -1,
            SeetNumber = -1,
            LoadCapacity = -1,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Model bust not be empty", result.Errors);
        Assert.Contains("Manufacturer bust not be empty", result.Errors);
        Assert.Contains("Invalid year", result.Errors);
        Assert.Contains("Invalid stating bid", result.Errors);
        Assert.Contains("Invalid load capacity", result.Errors);
    }

    [Fact]
    public void Should_Successed_WhenValidSuv()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.NotNull(result.Result);
        Assert.Empty(result.Errors);
        Assert.True(result.IsValid);
        Assert.True(result.Result is Suv);
    }

    [Fact]
    public void Should_Fail_WhenTruckSeetNumberNull()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Invalid seet number", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenSuvInvalidInputs()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "",
            Model = "",
            Year = -1,
            StartingBid = -1,
            DoorNumber = -1,
            SeetNumber = -1,
            LoadCapacity = -1,
        };

        var service = new InventoryService();

        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains("Model bust not be empty", result.Errors);
        Assert.Contains("Manufacturer bust not be empty", result.Errors);
        Assert.Contains("Invalid year", result.Errors);
        Assert.Contains("Invalid stating bid", result.Errors);
        Assert.Contains("Invalid seet number", result.Errors);
    }

    [Fact]
    public void Should_Fail_WhenVehicleAlreadyExtists()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        service.AddVehicle(input);
        var result = service.AddVehicle(input);

        Assert.Null(result.Result);
        Assert.NotEmpty(result.Errors);
        Assert.True(!result.IsValid);
        Assert.Contains($"Vehicle with id {input.Id} already exists", result.Errors);
    }

    [Fact]
    public void Should_ReturnVehicle_WhenVehicleExists()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturer",
            Model = "model",
            Year = 2020,
            StartingBid = 20000,
            DoorNumber = 5,
            SeetNumber = 6,
            LoadCapacity = 7,
        };

        var service = new InventoryService();

        service.AddVehicle(input);

        var vehicle = service.GetVehicle(input.Id);

        Assert.NotNull(vehicle);
    }

    [Fact]
    public void Should_NotReturnVehicle_WhenVehicleNotExists()
    {
        var service = new InventoryService();

        var vehicle = service.GetVehicle(1);

        Assert.Null(vehicle);
    }

    [Fact]
    public void Should_ReturnVehicles_WhenSearchByType()
    {
        var vehicles = seededInventoryService.GetVehicles(VehicleTypeDto.Hatchback);

        Assert.NotNull(vehicles.Result);
        Assert.True(vehicles.Result.Count == 1);
    }

    [Fact]
    public void Should_ReturnVehicles_WhenSearchByModel()
    {
        var vehicles = seededInventoryService.GetVehicles(model: "modelHatchback");

        Assert.NotNull(vehicles.Result);
        Assert.True(vehicles.Result.Count == 1);
    }

    [Fact]
    public void Should_NotReturnVehicles_WhenSearchByInvalidModel()
    {
        var vehicles = seededInventoryService.GetVehicles(model: "invalidModel");

        Assert.NotNull(vehicles.Result);
        Assert.True(vehicles.Result.Count == 0);
    }

    [Fact]
    public void Should_ReturnVehicles_WhenSearchByYear()
    {
        var vehicles = seededInventoryService.GetVehicles(year: 2020);

        Assert.NotNull(vehicles.Result);
        Assert.True(vehicles.Result.Count == 2);
    }

    [Fact]
    public void Should_NotReturnVehicles_WhenSearchByInvalidYear()
    {
        var vehicles = seededInventoryService.GetVehicles(year: 2000);

        Assert.NotNull(vehicles.Result);
        Assert.True(vehicles.Result.Count == 0);
    }
}
