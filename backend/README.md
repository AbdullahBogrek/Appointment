# BACKEND

- Architectural standards, flexibility, expandability, simplicity, and security principles were all considered when designing the API.

    | Plugin | Appointment | Servive | Staff |
    | ------ | ------ | ------ | ------ |
    | **GET** | /api/v1/Appointments | /api/v1/Services | /api/v1/Staffs |
    | **POST** | /api/v1/Appointments | /api/v1/Services | /api/v1/Staffs |
    | **GET** | /api/v1/Appointments/{id} | /api/v1/Services/{id} | /api/v1/Staffs/{id} |
    | **PUT** | /api/v1/Appointments/{id} | /api/v1/Services/{id} | /api/v1/Staffs/{id} |
    | **DELETE** | /api/v1/Appointments/{id} | /api/v1/Services/{id} | /api/v1/Staffs/{id} | 

- The HTTP requests that can be made to each table in the database are validate to ensure data integrity. This validation layer is easily extensible in response to user requests. The following are some examples of error messages.

    - Logged HTTP request-response output
        ```
        [Request]  HTTP GET - /api/v1/Staffs/15
        [Error]    HTTP GET - 500 Error Message: 'Personel kaydı bulunamadı. Lütfen bilgileri kontrol ederek tekrar deneyiniz.' in 9,0255ms
        ```
    - The output of this process in swagger UI.




- A standard was followed when creating the file structure and naming for the API source codes. As a result, code confusion was avoided, and flexibility was provided. Furthermore, when designing the API, care was taken to minimize dependencies.

- All of the service, staff, and appointment tables have an endpoint defined. As a result, CRUD operations can be performed on all tables. Versioning was also given consideration.

- Every HTTP request is logged as follows by middleware. The user is shown information such as the path and status of the request, how many milliseconds the operation took, and an error message if there is an error. As a result, a structure has been created that can be easily connected to any log service.

    - An HTTP request that was successful
        ```
        [Request]  HTTP GET - /api/v1/Appointments/3
        [Response] HTTP GET - /api/v1/Appointments/3 responsed 200 in 11,7574ms
        ```
    - An HTTP request that failed
        ```
        [Request]  HTTP DELETE - /api/v1/Appointments/30
        [Error]    HTTP DELETE - 500 Error Message: 'Böyle bir randevu bulunmamaktadır.' in 6,9854ms
        ```

## Images

- Database Tables

