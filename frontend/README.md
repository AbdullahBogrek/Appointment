# FRONTEND

- Bootstrap, an open source css framework, was used in this process. During the project design, it was important to pay attention to the interface's dynamics, responsiveness, and modularity. Unnecessary code definitions and naming conventions are avoided.

- As soon as the project is mount, the table data is retrieved via an API GET request. If the table is empty, the placeholder informs the user of the situation. Otherwise, the data is displayed to the user in the table.

- The vue-router is used for page routing. Making dynamic transitions between pages prevents unnecessary rendering. Requests to an unavailable endpoint are also managed and the user is directed.

- The user who wants to create a new record must fill out the form's required fields. When incorrect information, such as a missing or past date, is entered, the user is notified and asked to correct the error. If all checks pass, the appointment information is written to the database using the POST method. Errors that occur during this process are recorded.

- This project can be easily extended thanks to the designed API. Furthermore, these processes can be managed by adding pages like staff or service information screens.

## Images

- Form Validation and Past Date Control
![Form validation](https://user-images.githubusercontent.com/49994631/200799223-d2c0ca6b-2faf-40e7-91a2-4e15b1a051f2.PNG)

- ![past date controll](https://user-images.githubusercontent.com/49994631/200799318-0865ce0e-4779-4d8b-9641-ccb08047a2d1.PNG)

- Delete Modal
![delete modal](https://user-images.githubusercontent.com/49994631/200799529-a2b57aed-7fbb-4477-98cd-16f755a2b60f.PNG)

- Home Page
![Appointment Page](https://user-images.githubusercontent.com/49994631/200800649-52e7b558-7955-4335-9900-88b4c65588b5.PNG)

- New Appointment Page
![New Appointment Page](https://user-images.githubusercontent.com/49994631/200800687-c8dce397-b7c4-4d5f-bbf1-9c615696a964.PNG)


## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```
