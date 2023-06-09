# latvia-populated-places-map

## BackEnd

The ASP.NET API is responsible for downloading a data file from a remote server, extracting a CSV file from the downloaded archive, parsing the CSV file, and exposing an API endpoint to retrieve the parsed data.

## Prerequisites

Before running the project, make sure you have the following installed on your machine:

- .NET 7 SDK: [Download .NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Getting Started

To get started with the Populated Places API, follow these steps:

1. Clone the repository:

    ```bash
    git clone https://github.com/thisisrocee/populated-places-api.git
    
2. Open Solution

        PopulatedPlacesAPI.sln
  
Configure the project:

Open the appsettings.json file and update the configuration settings as needed, such as the download directory (because it could be different from mine).
Build and run the project:

      press run and start debug
      
The API should now be running locally at http://localhost:5038 (or https://localhost:7042 with HTTPS).

## FrontEnd

The React frontend communicates with the API provided by the Backend and displays the parsed populated places data on a map with search functionality.

## Setup and Run

1. Navigate to the frontend project directory:

        cd /ClientSide
        
2. Install the dependencies:

        npm install
        
3. Set the API URL:

Open the .env file and set the VITE_API_URL variable to the URL of the backend API:

        VITE_API_URL=https://localhost:5038/api
        
4. Build

To build the production-ready optimized version of the React application, run the following command:

        npm run dev
