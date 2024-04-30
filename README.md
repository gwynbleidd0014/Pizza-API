# Pizza Restaurant Web API

This is a .NET 6 web API project for a pizza restaurant, designed to provide CRUD functionalities for managing pizzas and users. The project follows a layered architecture with separate projects for different concerns, such as presentation, core logic, and data access. The application also includes middleware for culture, global exception handling, and request-response logging. Additionally, it supports Swagger documentation for easy API exploration.

## Table of Contents
- [Architecture](#architecture)
- [Features](#features)
- [Data Structures](#data-structures)
- [Validations](#validations)
- [Acceptance Criteria](#acceptance-criteria)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Architecture

The project is structured into three main projects:

1. **Web/Presentation Layer**: This layer contains controllers, DTOs, and application setup. Controllers handle incoming requests and delegate business logic to the service layer.
   
2. **Core/Service Layer**: This layer contains the main business logic of the application. It includes services responsible for processing data and implementing business rules.

3. **Persistence/DataAccess Layer**: This layer manages data storage and access. It includes in-memory collections of data structures, entities, and a custom `DbContext`. Repositories can also be implemented here for interacting with the data.

## Features

- CRUD operations for managing pizzas and users.
- Middleware for culture, global exception handling, and request-response logging.
- Swagger documentation with examples for easy API exploration.
- Support for creating orders and associating pizzas with addresses.
- User ranking system for pizzas on a 1-10 scale.
- Optional feature for uploading and managing pizza images.

## Data Structures

- **Pizza**: Represents a pizza item with properties like name, price, description, and calorie count.
- **User**: Represents a user with properties like first name, last name, email, phone number, and addresses.
- **Address**: Represents a user's address with properties like city, country, region, and description.
- **Order**: Represents an order placed by a user, including the list of pizzas ordered.
- **RankHistory**: Represents the ranking history of pizzas by users.
- **Image**: Optional entity representing an image associated with a pizza.

## Validations

Various validations are implemented to ensure data integrity and consistency, including:

- Validations for mandatory fields and field lengths.
- Regex validation for email and phone number formats.
- Validations for existing IDs in the database.
- Validations for order details and rank values.

## Acceptance Criteria

The project fulfills the following acceptance criteria:

- CRUD operations for pizzas and users.
- Proper handling of delete operations and marking associated addresses as deleted.
- Forbidden operations for ranks and orders.
- Handling of requests for deleted items and invalid requests.
- Ability for users to create orders and rank pizzas.
- Display of average rankings for pizzas.

## Getting Started

To run the project locally, follow these steps:

1. Clone this repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution.
4. Run the application.

## Usage

Once the application is running, you can explore the API endpoints using Swagger documentation available at `/swagger`.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use and modify it according to your needs.
