# Employee Management System

### Project Description

A RESTful API built with ASP.NET Core and Entity Framework Core to manage Employees and Departments. Supports full CRUD operations on both entities, with each Department containing a list of its associated Employees.

### Technologies Used

- C#
- ASP.NET
- EntityFramework Core
- MS SQL Server

# Endpoints

## Employees

### GET /api/employees

Get all employees

**Response** `200 Ok`

```json
[
    {
        "id": number,
        "firstName": "string",
        "lastName": "string",
        "startDate": "yyyy-mm-dd",
        "endDate": "yyyy-mm-dd",
        "departmentId": number
    },
    ...
]
```

### GET /api/employees/{id}

Gets a single employee from the database

**Response** `200 Ok`

```json
{
    "id": number,
    "firstName": "string",
    "lastName": "string",
    "startDate": "yyyy-mm-dd",
    "endDate": "yyyy-mm-dd",
    "departmentId": number
}
```

### POST /api/employees

Add a new employee

**Request Body**

```json
{
    "id": number,
    "firstName": "string",
    "lastName": "string",
    "startDate": "yyyy-mm-dd",
    "departmentId": number
}
```

**Response** `201 Created`

```json
{
    "id": number,
    "firstName": "string",
    "lastName": "string",
    "startDate": "yyyy-mm-dd",
    "endDate": "yyyy-mm-dd",
    "departmentId": number
}
```

### PUT /api/employees/{id}

Update an existing employee's information

**Request Body**

```json
{
    "firstName": "string",
    "lastName": "string",
    "startDate": "yyyy-mm-dd",
    "endDate": "yyyy-mm-dd",
    "departmentId": number
}
```

**Response** `200 Ok`

```json
{
    "id": number,
    "firstName": "string",
    "lastName": "string",
    "startDate": "yyyy-mm-dd",
    "endDate": "yyyy-mm-dd",
    "departmentId": number
}
```

### DELETE /api/employees/{id}

Delete an existing employee

**Response** `204 No Content`

## Departments

### GET /api/departments

Gets all departments from the database

**Response** `200 Ok`

```json
[
    {
        "id": number,
        "name": "string",
        "employees": [
            {
                "id": number,
                "firstName": "string",
                "lastName": "string",
                "startDate": "yyyy-mm-dd",
                "endDate": "yyyy-mm-dd",
                "departmentId": number
            },
            ...
        ]
    },
    ...
]
```

### GET /api/departments/{id}

Gets a single department from the database

**Response** `200 Ok`

```json
{
    "id": number,
    "name": "string",
    "employees": [
           {
            "id": number,
            "firstName": "string",
            "lastName": "string",
            "startDate": "yyyy-mm-dd",
            "endDate": "yyyy-mm-dd",
            "departmentId": number
        },
        ...
    ]
}
```

### POST /api/departments

Add a new department

**Request Body**

```json
{
  "name": "string"
}
```

**Response** `201 Created`

```json

{
    "id": number,
    "name": "string",
    "employees": [
        {
            "id": number,
            "firstName": "string",
            "lastName": "string",
            "startDate": "yyyy-mm-dd",
            "endDate": "yyyy-mm-dd",
            "departmentId": number
        },
        ...
    ]
}
```

### PUT /api/departments/{id}

Update an existing department's information

**Request Body**

```json

{
    "id": number,
    "name": "string",
}
```

**Response** `200 Ok`

```json
{
    "id": number,
    "name": "string",
    "employees": [
        {
            "id": number,
            "firstName": "string",
            "lastName": "string",
            "startDate": "yyyy-mm-dd",
            "endDate": "yyyy-mm-dd",
            "departmentId": number
        },
        ...
    ]
}
```

### DELETE /api/departments/id

Delete an existing department

**Response** `204 No Content`
