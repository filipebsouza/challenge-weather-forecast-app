# Weather app 🌤️🌧️:

## Problem description:

- As an user I would like to seach some address to find the next 7 days weather forecast.
- As an user I would like to use my current location to find the next 7 days weather forecast.

## Implementation:

- The problem was solved by an Angular app to offer SPA to communicate with Backend services.
- Location and Weather services are provided by third party services. Because of that I decided to make Backend services to create an Anticorruption layer between Frontend consunmption and vendor service.
- The components are divided in: Frontend app, Backend Location Web API and Backend Weather Web API.
- The components running in Docker containers.
- Integration tests for validate communication between third party services.

## Benefits:

- Weak couple between Frontend and third party services.
- Strong Backend Location and Weather contract provide options to replace vendor services if it's necessary.
- The containarization provide a straght way to deploy in cloud.
- Integration tests offer confidency in the Backend services.

## Tradeoffs:

- Decoupling Backend services decrease velocity of evolute these solutions.
- Integration tests require more effort to maintain and evolve.

## Future implementations:

- Unit tests in Frontend app. It's really important in the service layer, because at this moment don't have complex UI behavior to validate.
- Frontend UI to improve user experience.
- Create resiliency mecanimism to avoid make request if some services goes down.
- Create self recovery mechanism for each service.

## Component diagram

![Components](/docs/images/01%20-%20components.png)
