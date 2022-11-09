# Appointment

https://user-images.githubusercontent.com/49994631/200789639-f2efc3b7-8d25-4621-b9ba-514b6a60afe4.mp4

## Description 

**Appointment is a .Net Web API and Vue.js based appointment application**. [Softage](http://www.estesoft.com.tr/) determined the project's requirements. There are two folders in the project. The first is the ``backend`` folder, which contains the API created with ``.Net Web API``. The second is the ``frontend`` folder containing the interface codes that created with ``Vue.js``. The developed API enables frontend and database communication. Therefore, it is possible to do all CRUD activities. In the project, ``MSSQL`` was used as the database.

## Table of Contents

* [General Information](#general-information)   
* [Technologies](#technologies)
    * [Frontend](#frontend)
    * [Backend](#backend--api)
    * [Database](#database)
* [Setup](#setup)
* [Features](#features)
* [Acknowledgements](#acknowledgements)
* [Images](#images)
* [Contact](#contact)
* [License](#license)

## General Information

- While designing the interface, ``Bootstrap``, an open source CSS framework, was used instead of dealing with unnecessary CSS definitions. Using the "Appointment" interface, the user can make new appointments, delete existing ones, and track the ones they've already made. In addition, the frontend was designed with **simplicity** and **usability** in mind. Controls have also been added to prevent users from making mistakes such as leaving data cells blank or selecting the past date as the appointment date when creating a new record.

- The API was designed with the principles of **flexibility**, **security**, and **simplicity** in mind. Although measures for data consistency on the frontend have been taken, validations for errors that may occur during **CRUD** operations have been added. The API was designed with the goal of minimizing dependencies and standardizing them so that they could scale. As a result, this rule has been applied everywhere, from file names to file structure. Every API request or error is **logged** by the middleware that was created.

- ``MSSQL`` was used as the database. Three different tables were created while designing the database based on the project's requirements. These tables contain information about personnel, services, and appointments. The process was managed by relating them together.

## Technologies

### Frontend
- Vue.js-----------v3.2.13
- Bootstrap-------v5.2.2
- Vue-router------v4.1.6

### Backend | API
- .Net Web API---v6.0

### Database
- MSSQL----------v15.0.2000.5

## Setup

In order for the project to run in your local, both the frontend and backend packages must be installed. Many configurations, such as database connection string, must be made. To run this project, install it locally using npm:

## Features

- You can create new appointments.
- You can go through and delete appointments.
- When adding an appointment, check for missing or incorrect data.
- Handling requests to a different endpoint or when the table is empty. Please see the examples [below](#images).
- You can use the API to perform CRUD operations on all tables in the database.
- Ensuring data consistency by validating the data to be added to the database.
- Logging every API transaction using the middleware
- Designing the API in accordance with standards
 
## Images

- API Design
![Api Endpoints](https://user-images.githubusercontent.com/49994631/200665497-8e648291-b832-474f-a360-dcfefd27828a.PNG)

- Frontend incorrect routing handling
![Sayfa bulunamadı](https://user-images.githubusercontent.com/49994631/200665988-545c66cb-f495-48f7-b37f-ecd5f72abea2.PNG)

- If the appointment table is empty
![Randevu kaydı yok](https://user-images.githubusercontent.com/49994631/200666249-0b78f616-e22b-4124-bff1-2a225ef1ec90.PNG)

- Example Request: GET /api/v1/Appointments
![Appointment Get Request](https://user-images.githubusercontent.com/49994631/200668527-34cbc9a8-4b35-4706-bd8a-7ea0a44e3f12.PNG)

- Example Incorrect Request: DELETE /api/v1/Services/50
![Hatalı Delete Service Request](https://user-images.githubusercontent.com/49994631/200668967-0967742b-ef9a-4f1a-ad8a-6eb256e09804.PNG)

## Contact

Created by [@Abdullah Böğrek](https://tr.linkedin.com/in/abdullahbogrek)

Mail: asbogrek@gmail.com

## License

This project is open source and available under the [MIT](https://opensource.org/licenses/MIT).
