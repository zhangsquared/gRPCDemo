# gRPC demo

### Requirement
.NET Core 3.1

### Structure
**GrpcSampleService**
* _Protos_: defines DTOs and API
* _APIs_: self-generated APIs, equivalent of Controllers in MVC style
* _Services_: can use Container for dependency injection
* _DAL_: in-memory entity framework core
* _Models_: POCO entity

If the business logic is simple enough, it can be written directly into _APIs_ layer (without _Services_ layer)
In development environment, the application is configured to be hosted on "https://localhost:5002"

**GrpcSampleServiceTest**
A client-side test (intergrated test)

### How to use the application

To start the gRPC app:

```
dotnet run --project GrpcSampleService
```

After starting the gRPC app in **development** environment, 
**GrpcSampleServiceTest** can be used for testing
