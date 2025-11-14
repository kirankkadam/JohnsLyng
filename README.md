# Johns Lyng TODO app
## Overview
This repository contains a full-stack application built using Angular 20.3, TypeScript, ASP.NET Web API, and C#.
The project demonstrates a simple TODO app, including listing, adding and deleting items through a RESTful API.

## Technologies
### Frontend
1. Angular 20.3
2. TypeScript
3. HTML5 & CSS
4. Angular CLI
### Backend
1. ASP.NET Web API
2. C# (.NET)

## How to Run the Application
1. Running the Angular Frontend
Prerequisites
Node.js (LTS version recommended)
Angular CLI installed globally

### Steps
* Angular App
  1. Navigate to the Johns-Lyng-Todo-App folder
  2. Install all the dependencies using - `npm install`
  3. Start the Angular development server using - `ng serve`
  4. The app will be available at `http://localhost:4200`

* Web API
  1. Open the solution in Visual studio
  2. Make sure the application runs using the `IIS Express` option
  3. Hit F5 or click the play button

> [!WARNING]
Please make sure the Web Api is running for the angular app functionality to work fine
 
## Known Issues
Some parts of the application are currently not functioning as expected:
Add Item Functionality — Not Working
When attempting to add a new item to the TODO list, the item is added to the list in memory but not through the API.
This may be due to an API endpoint issue, form binding issue, or request model mismatch.

