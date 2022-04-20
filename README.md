# Weather app 🌤️🌧️:

## Problem description (as a User Stories):

- As a User, I would like to search some addresses to find the next seven days' weather forecast.
- As a User, I would like to use my current location to find the next seven days' weather forecast.

## Implementation:

- The problem was solved by an Angular app to offer a SPA to communicate with Backend services.
- Location and Weather services are provided by third-party services. Because of that, I decided to make Backend services to create an **Anti-Corruption layer** between Frontend consumption and vendor service.
- The components are divided into Frontend app, Backend Location Web API, and Backend Weather Web API.
- The components are running in Docker containers.
- Integration tests were made for validating communication between third-party services.
- **Observer pattern** was used for communication between Angular services and components.

## Benefits:

- Weak coupling between Frontend and third-party services.
- Strong Backend Location and Weather contract provide options to replace third-party services if it's necessary.
- The containerization provides an opportunity to deploy in the cloud soon.
- Integration tests increase the confidence in the Backend services.

## Trade-offs:

- Decoupling Backend services decrease the velocity of evolute these solutions because the complexity has increased.
- Integration tests require more effort to maintain and evolve.

## Future implementations:

- Implement fault tolerance in Frontend (eg if any Backend service goes down, what should be done?).
- Creating unit tests in the Frontend app. This is important in the service layer because this moment doesn't have complex UI behavior to validate.
- Improve Frontend UI to create a better user experience.
- To create a resiliency mechanism to avoid requesting something for down services (for instance: Circuit Breaker).
- To create a self-recovery mechanism for each service.

## Component diagram:

![Components](/docs/images/01%20-%20components.png)

## Techstack:

- Frontend: Angular 13.
- Backend: C# and ASP.NET 6 with minimal APIs.
- CI: GitHub actions.
- Containers: Docker and Docker compose.

## How to start the App:

- In the app root directory, run this command:

````batch
docker-compose up
````

- Put on the browser address http://localhost:8080

## Addresses for test:

[Valid US addresses](https://gist.github.com/HeroicEric/1102788)
