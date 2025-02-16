using System.Net;
using System.Net.Http.Json;
using CarAuctionApi.Dtos;
using CarAuctionApi.Tests.IntegrationTests.Abstractions;

namespace CarAuctionApi.Tests.IntegrationTests;

public class VehicleEndpointsTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : BaseIntegrationTest(integrationTestWebAppFactory)
{
    [Fact]
    public async Task Shoud_ReturnCreated_WhenCreateValidHatchback()
    {
        var input = new VehicleDto
        {
            Id = 1,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };

        var response = await httpClient.PostAsJsonAsync("api/vehicles", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnCreated_WhenCreateValidSedan()
    {
        var input = new VehicleDto
        {
            Id = 2,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturerSedan",
            Model = "modelSedan",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };

        var response = await httpClient.PostAsJsonAsync("api/vehicles", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnCreated_WhenCreateValidSUV()
    {
        var input = new VehicleDto
        {
            Id = 3,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturerSUV",
            Model = "modelSUV",
            Year = 2018,
            StartingBid = 20000,
            SeatNumber = 5,
        };

        var response = await httpClient.PostAsJsonAsync("api/vehicles", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnCreated_WhenCreateValidTruck()
    {
        var input = new VehicleDto
        {
            Id = 4,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "manufacturerTruck",
            Model = "modelTruck",
            Year = 2018,
            StartingBid = 20000,
            LoadCapacity = 5,
        };

        var response = await httpClient.PostAsJsonAsync("api/vehicles", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnBadRequest_WhenCreateIsInvalid()
    {
        var input = new VehicleDto
        {
            Id = 5,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000
        };

        var response = await httpClient.PostAsJsonAsync("api/vehicles", input);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Shoud_ReturnOk_WhenFilteredGetIsValid()
    {
        var input = new VehicleDto
        {
            Id = 6,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturerSedan",
            Model = "modelSedan",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        await httpClient.PostAsJsonAsync("api/vehicles", input);

        var response = await httpClient.GetAsync($"api/vehicles?type={VehicleTypeDto.Sedan}");
        var responseRecord = await response.Content.ReadFromJsonAsync<List<VehicleDto>>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseRecord);
        Assert.True(responseRecord.Count != 0);
        Assert.Contains(responseRecord, x => x.Id == input.Id);
    }

    [Fact]
    public async Task Shoud_ReturnOk_WhenNoFilters()
    {
        var hatchback = new VehicleDto
        {
            Id = 7,
            Type = VehicleTypeDto.Hatchback,
            Manufacturer = "manufacturerHatchback",
            Model = "modelHatchback",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        var sedan = new VehicleDto
        {
            Id = 8,
            Type = VehicleTypeDto.Sedan,
            Manufacturer = "manufacturerSedan",
            Model = "modelSedan",
            Year = 2018,
            StartingBid = 20000,
            DoorNumber = 5,
        };
        var suv = new VehicleDto
        {
            Id = 9,
            Type = VehicleTypeDto.SUV,
            Manufacturer = "manufacturerSUV",
            Model = "modelSUV",
            Year = 2018,
            StartingBid = 20000,
            SeatNumber = 5,
        };
        var truck = new VehicleDto
        {
            Id = 10,
            Type = VehicleTypeDto.Truck,
            Manufacturer = "manufacturerTruck",
            Model = "modelTruck",
            Year = 2018,
            StartingBid = 20000,
            LoadCapacity = 5,
        };
        await httpClient.PostAsJsonAsync("api/vehicles", hatchback);
        await httpClient.PostAsJsonAsync("api/vehicles", sedan);
        await httpClient.PostAsJsonAsync("api/vehicles", suv);
        await httpClient.PostAsJsonAsync("api/vehicles", truck);

        var response = await httpClient.GetAsync($"api/vehicles");
        var responseRecord = await response.Content.ReadFromJsonAsync<List<VehicleDto>>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseRecord);
        Assert.Contains(responseRecord, x => x.Id == hatchback.Id);
        Assert.Contains(responseRecord, x => x.Id == sedan.Id);
        Assert.Contains(responseRecord, x => x.Id == suv.Id);
        Assert.Contains(responseRecord, x => x.Id == truck.Id);
    }

    [Fact]
    public async Task Shoud_ReturnOk_WhenNoVehiclesFound()
    {
        var response = await httpClient.GetAsync("api/vehicles?year=2000");
        var responseRecord = await response.Content.ReadFromJsonAsync<List<VehicleDto>>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseRecord);
        Assert.True(responseRecord.Count == 0);
    }
}
