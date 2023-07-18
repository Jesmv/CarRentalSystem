# Car Rental System

This application is a technical exercise that implements a car rental system.

## Running the Application

**Requirements**: This application requires .NET Core 7.

1. Clone this repository.
2. Open the solution with Microsoft Visual Studio.
3. Compile and run the solution.
After you run the application, a new browser tab opens, displaying the Swagger UI, which allows you to explore the API.

## Implementation Details

The application exposes an HTTP API to interact with the car rental system:

* `GET /Cars`: lists all cars in the inventory.
* `GET /AvailableCars`: lists all cars that are not rented at the moment.
* `POST /Reservation`: rents a list of cars.
* `POST /ReturnCar`: returs a list of cars.

The following comments about the implementation should be considered:
* The POST endpoints require a list of cars objects in JSON.
This could be implemented more easily by passing a list of car IDs.
* The API is implemented with the minimal API features of .NET 7.
* Unit tests only cover the price calculation.
* An in-memory database was used, in combination with entity framework.
* The code is organized following DDD guidelines and the onion architecture.
* For the sake of simplicity and time, the HTTP endpoints do not exactly follow RESTful rules.

