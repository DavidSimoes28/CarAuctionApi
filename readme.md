# Api structure

```bash
CarAuctionApi
├─── Dtos # Contains all the dto models used by/in the api
│    ├─── AuctionDto
│    ├─── AuctionPlaceBidDto
│    ├─── VehicleDto
│    └─── VehicleTypeDto
├──── Infrastructure # Contains some models and utils to be used between endpoint and business logic
│    ├─── EndpointExtensions 
│    └─── EndpointResult
├─── MappingExtensions # Mappings beetwen servie models and dtos
│    └─── VehicleMappingExtensions
├─── Services # Constains all the bussiness logic
│    ├─── Models # All the models of bussiness logic
│    │    ├─── Auction
│    │    ├─── AuctionStatus
│    │    ├─── Hatchback
│    │    ├─── Sedan
│    │    ├─── Suv
│    │    ├─── Truck
│    │    ├─── Vehicle
│    │    └─── VehicleWithDoors
│    ├─── Validators # Constains all the validation logic
│    │    ├─── SuvValidator
│    │    ├─── TruckValidator
│    │    └─── VehicleWithDoorsValidator
│    ├─── AuctionService
│    └─── InventoryService
└─── Program.cs # where all endpoints are registered
```

## Dtos
- VehicleDto contains all the properties that a vehicle of any type can have (id, manufacturer, model, year, starting bid, house number, vehicle number, payload) and a type that identifies the type of vehicle it represents (Hatchback = 0, Sedan = 1, SUV = 2, Truck = 3). This way this model can represent any type of vehicle
- AuctionDto contains the vehicle ID
- AuctionPlaceBidDto contains the vehicle ID and bid amount
- AuctionPlaceBidDto extends from AuctionDto

## Models
### Vehicle
```bash
Vehicle
├─── VehicleWithDoors
│    ├─── Hatchback
│    └─── Sedan
├─── Suv
└─── Truck
```
- Vehicle contains all common properties of a vehicle (id, manufacturer, model, year, starting bid)
- VehicleWithDoors contains all common properties of a vehicle and a number of doors property
- Hatchback and Sedan extends from VehicleWithDoors without additional properties
- Suv extends from Vehicle with a additional number of seats property
- Truck extends from Vehicle with a additional load capacity property

### Auction
- Action contains a vehicleId, bid and AuctionStatus
- The AuctionStatus contains 2 values (Started = 0 and Closed = 1)

# Endpoints
## POST api/vehicles
- This endpoint will create any type of vehicle
- This endpoint receives a VehicleDto
## GET api/vehicles
- This endpoint contain 3 optional query parameters (type, model year)
- This endpoint will retrieve a list of vehicleDto.
## POST api/auctions/start
- This endpoint will create an auction for a given vehicle
- This endpoint receives an AuctionDto
- It will not return any additional information about the auction, only whether the operation was successful or not (OK or BadRequest status)
## PATCH api/auctions/place-bid
- This endpoint will set a new value for bid in a ongoing auction
- This endpoint receives a AuctionDto
- It will not return any additional information about the auction, only whether the operation was successful or not (OK or BadRequest status)
## PATCH api/auctions/close
- This endpoint will close a ongoing auction
- This endpoint receives a AuctionDto
- It will not return any additional information about the auction, only whether the operation was successful or not (OK or BadRequest status)