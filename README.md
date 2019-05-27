# Backend C# developer project

## Background

Here at Lodgify it is important to us that holiday-goers can keep in contact with the host of the vacation rental they're enjoying should anything not go according to plan. For this reason we provide our users with the ability to update their contact information to display on the website we create for them.

## The API

This project includes an API that can be consumed in order to update the aforementioned information about the host of a vacation rental. It contains a single controller (`ContactController`) and the following endpoints are provided

- `GET /api/v1/vacationrental/{id}/contact` - to retrieve the contact information for the given vacation rental id
- `PUT /api/v1/vacationrental/{id}/contact` - to update the contact information for the given vacation rental id
- `GET /swagger` - The swagger documentation for the API (will open on process run)

As it is presented the information for the contacts is only stored in memory and therefore we lose all information when the service restarts.

## The task

- There are two failing tests making HTTP calls to the API that need to be fixed
  - The first expects a 404 Not Found response when retrieving the contact for a vacation rental does not exist
  - The other expects a 400 Bad Request response when trying to update a contact without a phone number
- Once these bugs are fixed we need to incorporate some persistence. Please make sure that a host's contact information can be persisted between deployments of this service.
- **Optional** - We would like this service to be deployed as a Docker container. Please include a Dockerfile that will create the container image

### What we are looking for

- How you define a basic architecture for this feature (and hypothetical next ones)
- How you test the correctness of your solution
- How you model these operations in the code

### Restrictions

- Please do not modify the API contract
  - Do not rename the model's properties
  - Do not modify the API path - it must remain `/api/v1/vacationrental/{rentalId}/contact`
  - Removing/changing the injected dependencies is allowed
- Only use MSSQL/PostgreSQL for persistence (using Entity Framework or Dapper)
- If there is something that you want us to notice in your approach please add a text file describing it

### Observations on the solution
- After I changed the Api to a live database, all of the tests broke. I managed to change one to pass, using a mock service to call the controller method.
I didn't have enought time to fix the other ones. But if the original state is mantained (no persistence), to pass all tests you just have to change the return from 
the controllers to IActionResult and perform the parameter and return check needed.
I used the Repository pattern for this, implemented by the ContactViewModelManager class.
I managed to create the docker files for both projects, but I couldn't create an image of them because of windows version incompatibility.
I originally intended to use Migrations to create the database when the application ran, but there also wasn't time for that, so I hope that the database is created
by EF on the first run. In case it isn't, I apologize.