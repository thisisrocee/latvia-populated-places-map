# latvia-populated-places-map

This is a web API project for retrieving and parsing data about populated places. The project is built with ASP.NET and follows a layered architecture for better separation of concerns.

## Prerequisites

Before running the project, make sure you have the following installed on your machine:

- .NET 5 SDK: [Download .NET 5 SDK](https://dotnet.microsoft.com/download)

## Getting Started

To get started with the Populated Places API, follow these steps:

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/populated-places-api.git
    
Navigate to the project directory:

    cd populated-places-api
  
Configure the project:

Open the appsettings.json file and update the configuration settings as needed, such as the download URL and directory.
Build and run the project:

      dotnet run --project PopulatedPlacesAPI.Web
      
The API should now be running locally at http://localhost:5038 (or https://localhost:7042 with HTTPS).

## API Endpoints

The following API endpoint is available:

GET /api: Retrieves the parsed data of populated places.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.
