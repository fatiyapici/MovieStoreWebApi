# MovieStoreWebApi

MovieStoreWebApi is a RESTful web API for managing movie-related operations.

## Introduction

MovieStoreWebApi is a web API developed for managing movies in a movie store. It provides various endpoints to perform operations such as retrieving movies, adding new movies, updating movie information, and deleting movies. The API aims to simplify the process of managing movie data and provide an efficient solution for movie store management.
## Features

- Retrieve a list of movies
- Get details of a specific movie
- Add a new movie to the store
- Update movie information
- Delete a movie from the store

  
## Technologies

- ASP.NET Web API
- Entity Framework Core
- Microsoft SQL Server (database)
- AutoMapper
- FluentValidation
- Swagger (API documentation)

  
## Getting Started 

Follow the steps below to run the project on your local machine.

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/en-us/download) (3.1 or later)

### Clone the Project
Clone this repository to your local machine or download it as a ZIP.

### Configuring the Database
- Update the database connection string in the appsettings.json file (Microsoft SQL Server is used by default).
- To create your database, run the following command:

```bash 
  dotnet ef database update
```

To install and run the MovieStoreWebApi, follow these steps:

1. Clone the repository: `git clone https://github.com/fatiyapici/MovieStoreWebApi.git`
2. Navigate to the project directory: `cd MovieStoreWebApi`
3. Build the project: `dotnet build`
4. Run the project: `dotnet run`
5. The API will be accessible at: `http://localhost:5000`

You can view the Swagger interface and test the API by navigating to https://localhost:5001/swagger in your browser.
## Usage

To use the MovieStoreWebApi, you can send HTTP requests to the available endpoints using tools like Postman or cURL. Here are some example requests:

- Retrieve a list of movies: `GET /api/movies`
- Get details of a specific movie: `GET /api/movies/{id}`
- Add a new movie to the store: `POST /api/movies`
- Update movie information: `PUT /api/movies/{id}`
- Delete a movie from the store: `DELETE /api/movies/{id}`
## Contribution

Contributions to the MovieStoreWebApi project are welcome. If you encounter any issues, have suggestions for improvement, or would like to contribute new features, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix: `git checkout -b feature-name`
3. Make your changes and commit them: `git commit -m "Description of your changes"`
4. Push your changes to the branch: `git push origin feature-name`
5. Create a new pull request on GitHub.

  
## Acknowledgements

We would like to thank the following individuals for their contributions and support:

- Baran Taylan [@bataylan](https://github.com/bataylan)