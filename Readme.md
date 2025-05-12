# TaskAPI - Todo Management REST API

A simple .NET Core API for managing tasks and authors, built with ASP.NET Core.

## Overview

TaskAPI is a RESTful web service that allows you to manage authors and their associated todo tasks. The API provides endpoints for creating, reading, updating, and deleting both authors and todos.

## API Endpoints

### Authors

#### Get All Authors

```
GET /api/authors
```

**Query Parameters:**
- `job` (optional): Filter authors by job role
- `search` (optional): Search for authors by name or other attributes

**Response:**
```json
[
  {
    "id": 1,
    "fullName": "John Doe",
    "address": "123, Main Street, New York",
    "jobRole": "Developer"
  },
  {
    "id": 2,
    "fullName": "Jane Smith",
    "address": "456, Park Avenue, Boston",
    "jobRole": "Designer"
  }
]
```

#### Get Author by ID

```
GET /api/authors/{id}
```

**Response:**
```json
{
  "id": 1,
  "fullName": "John Doe",
  "address": "123, Main Street, New York",
  "jobRole": "Developer"
}
```

#### Create Author

```
POST /api/authors
```

**Request Body:**
```json
{
  "fullName": "John Doe",
  "addressNo": "123",
  "street": "Main Street",
  "city": "New York",
  "jobRole": "Developer",
  "todos": []
}
```

**Response:**
```json
{
  "id": 1,
  "fullName": "John Doe",
  "address": "123, Main Street, New York",
  "jobRole": "Developer"
}
```

### Todos

#### Get All Todos for an Author

```
GET /api/authors/{authorId}/todos
```

**Response:**
```json
[
  {
    "id": 1,
    "title": "Complete Project",
    "description": "Finish the TaskAPI project",
    "created": "2023-05-01T10:00:00",
    "due": "2023-05-15T18:00:00",
    "status": "InProgress",
    "authorId": 1
  },
  {
    "id": 2,
    "title": "Review Code",
    "description": "Review the TaskAPI code",
    "created": "2023-05-02T09:00:00",
    "due": "2023-05-10T17:00:00",
    "status": "New",
    "authorId": 1
  }
]
```

#### Get Todo by ID

```
GET /api/authors/{authorId}/todos/{id}
```

**Response:**
```json
{
  "id": 1,
  "title": "Complete Project",
  "description": "Finish the TaskAPI project",
  "created": "2023-05-01T10:00:00",
  "due": "2023-05-15T18:00:00",
  "status": "InProgress",
  "authorId": 1
}
```

#### Create Todo

```
POST /api/authors/{authorId}/todos
```

**Request Body:**
```json
{
  "title": "Complete Project",
  "description": "Finish the TaskAPI project",
  "created": "2023-05-01T10:00:00",
  "due": "2023-05-15T18:00:00",
  "status": 1
}
```

**Response:**
```json
{
  "id": 1,
  "title": "Complete Project",
  "description": "Finish the TaskAPI project",
  "created": "2023-05-01T10:00:00",
  "due": "2023-05-15T18:00:00",
  "status": "InProgress",
  "authorId": 1
}
```

#### Update Todo

```
PUT /api/authors/{authorId}/todos/{todoId}
```

**Request Body:**
```json
{
  "title": "Complete Project",
  "description": "Finish the TaskAPI project with documentation",
  "created": "2023-05-01T10:00:00",
  "due": "2023-05-20T18:00:00",
  "status": 2
}
```

**Response:**
```
200 OK
```

#### Delete Todo

```
DELETE /api/authors/{authorId}/todos/{todoId}
```

**Response:**
```
204 No Content
```

## Data Models

### Author

```csharp
public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string AddressNo { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string JobRole { get; set; }
    public ICollection<Todo> Todos { get; set; }
}
```

### Todo

```csharp
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Due { get; set; }
    public TodoStatus Status { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
```

### TodoStatus

```csharp
public enum TodoStatus
{
    New,
    InProgress,
    Completed
}
```

## API Features

- **RESTful Design**: Follows REST principles for intuitive API design
- **Content Negotiation**: Supports both JSON and XML formats
- **Swagger Documentation**: Interactive API documentation available at the root URL
- **Error Handling**: Proper HTTP status codes and error messages
- **Filtering and Searching**: Filter authors by job role and search functionality
- **Dependency Injection**: Uses ASP.NET Core's built-in DI container
- **AutoMapper**: Automatically maps between domain models and DTOs

## Getting Started

1. Clone the repository
2. Restore dependencies: `dotnet restore`
3. Add Your MySQL database name, username and password to "/TaskAPI.DataAccess/TodoDBContext.cs" file.
5. Run the application: `dotnet run`
6. Access the Swagger UI at: `https://localhost:5001/`

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swagger/OpenAPI
