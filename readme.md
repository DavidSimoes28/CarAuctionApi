
To provide a simple documentation on the developed project and different topics (api structure, decisions, others), I've created this readme. Please find below the different topics informations.

# API structure

```bash
CarAuctionApi
├─── Dtos # Contains all the API dto models
│    ├─── AuctionDto
│    ├─── AuctionPlaceBidDto
│    ├─── VehicleDto
│    └─── VehicleTypeDto
├──── Infrastructure # Contains some models and utils to be used between endpoints and business logic
│    ├─── EndpointExtensions 
│    └─── EndpointResult
├─── MappingExtensions # Mappings beetwen service models and dtos
│    └─── VehicleMappingExtensions
├─── Services # Service Layer - Contains the business logic
│    ├─── Models # All the models of business logic
│    │    ├─── Auction
│    │    ├─── AuctionStatus
│    │    ├─── Hatchback
│    │    ├─── IValidatable
│    │    ├─── IVehicle
│    │    ├─── Sedan
│    │    ├─── Suv
│    │    ├─── Truck
│    │    ├─── Vehicle
│    │    └─── VehicleWithDoors
│    ├─── Validators # Contains all the validation logic
│    │    ├─── SuvValidator
│    │    ├─── TruckValidator
│    │    └─── VehicleWithDoorsValidator
│    ├─── AuctionService
│    └─── InventoryService
└─── Program.cs # Endpoint's registration
```

## Dtos
- VehicleDto contains all the properties that a vehicle of any type can have (id, manufacturer, model, year, starting bid, house number, vehicle number, payload) and a type that identifies the type of vehicle it represents (Hatchback = 0, Sedan = 1, SUV = 2, Truck = 3). This way this model can represent any type of vehicle
- AuctionDto contains the vehicle ID
- AuctionPlaceBidDto contains the vehicle ID and bid amount, extends from AuctionDto

## Models
For the object models the inheritance concept was used, with the base class Vehicle.

### Vehicle
```bash
Vehicle
├─── VehicleWithDoors
│    ├─── Hatchback
│    └─── Sedan
├─── Suv
└─── Truck
```
- Vehicle is a class that contains all common properties of a vehicle (id, manufacturer, model, year, starting bid) and implements IVehicle and IValidatable interfaces
- VehicleWithDoors contains all common properties of a vehicle and a number of doors property
- Hatchback and Sedan extends from VehicleWithDoors without additional properties
- Suv extends from Vehicle with a additional number of seats property
- Truck extends from Vehicle with a additional load capacity property

### Auction
- Action contains a vehicleId, bid and AuctionStatus
- The AuctionStatus contains two values (Started = 0 and Closed = 1)

# Endpoints
## POST api/vehicles
- This endpoint will create any type of vehicle
- This endpoint receives a VehicleDto
## GET api/vehicles
- This endpoint contains three optional query parameters (type, model and year)
- This endpoint will retrieve a list of vehicleDto.
## POST api/auctions/start
- This endpoint will create an auction for a given vehicle
- This endpoint receives an AuctionDto
- It will return whether the operation was successful or not (OK or BadRequest status)
## PATCH api/auctions/place-bid
- This endpoint will set a new value for bid in a ongoing auction
- This endpoint receives a AuctionDto
- It will return whether the operation was successful or not (OK or BadRequest status)
## PATCH api/auctions/close
- This endpoint will close a ongoing auction
- This endpoint receives a AuctionDto
- It will return whether the operation was successful or not (OK or BadRequest status)
