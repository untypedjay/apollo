# Frontend Documentation
The application is written using React and TypeScript. The styling is done using plain CSS and the [BEM](http://getbem.com/introduction/) methodology.
It is written in modern React using functional components and hooks. State management is done using the React [Context API](https://reactjs.org/docs/context.html).
The authentication is done using [Auth0](https://auth0.com/#!).
The components are structured using the [Atomic Design](https://atomicdesign.bradfrost.com/) methodology.

## Directory Structure
* `public`: static files such as `index.html`
* `src/components`: components of the application, structured in atoms, molecules, organisms, templates and pages
* `src/context`: state management using the context API
* `src/helpers`: helper functionality for the application
* `src/images`: images used in the application
* `src/services`: REST API using JavaScript's built in `fetch`


## Important Dependencies
* `@auth0/auth0-react`: handles the authentication with Auth0
* `react-icons`: renders icons used in the application
* `react-router-dom`: routing functionality for react
