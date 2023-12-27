# Geolocalion API - Sample
## Technical Test for Fogata Group

This is a simple Geolocation API for Geolocation APP.

## Features
- Users CRUD with Authentication User by JWT Authenticator.
- Locations CRUD by Users.
- Places CRUD with a searcher for Places of Interests by User.

## Technical Specifications

- It's create with .NET 8 and EntityFramework as ORM.
- Code First way to create tables in the database with FluentMigrator.
- PostgreSQL as Database.
- HTTPRestful API.
- JWT Authenticator.
- Visual Studio 2022 as IDE.
- Git as Version Control system. 
- Swagger for Documentation and test API and Postman for testing the API.

## Installation

Ensure that .NET 8 and Visual Studio 2022 (v17.8) for .NET 8 are installed. Also, PostgreSQL should be installed.

## STEP 1: Clone the project.
## STEP 2: Run the Project:

The project has an initializer class that executes the creation of the database, tables, and a small data seed for initial testing. This class is located at the root of the project and is called:
```sh
InitializerSeed.cs
```
It is executed from Program.cs:
```sh
#Program.cs
app.Seed();
```
Once the project is initialized, you can perform tests using Swagger. Additionally, there is a Postman Collection for testing with Postman (check the root of the cloned project).

STEP 3: Create User.
For testing, it's better to use the users already inserted into the database. However, to start testing the endpoints from scratch, create a user using the following endpoint:
```sh
#METHOD POST
https://localhost:[insert port]/api/Users

Use the JSON Body:
{
  "username": "string",
  "password": "string",
  "email": "string"
}
```

## PASO 4: Generar Token.

STEP 4: Generate Token.
To use other endpoints, generate an Authorization token. To do this, access the following endpoint with the username and password created in STEP 3:

```sh
#METHOD POST
https://localhost:[insert port]/api/Users/Login

And pass as Query String or Parameters:

username: value
password: value

```

You should receive a response indicating the success of the login and a token.

## STEP 5: Test the endpoints.

Once you have the token, whenever you want to test an endpoint for Users, Locations, or PlacesOfInterest, add the following to the Postman Header:
```sh
Key: Authorization - Value: Bearer [token generado]

```
And that's it.
