#Execution:

##API REST:
Once downloaded the repository it can be run from Visual Studio 2017.
Or by command line: Change to folder WebApplicationEntityFramework. Execute command: dotnet run
Once executed, the following endpoints can be accessed by Postman or another RestAPI client (GET endpoints can be accessed from a browser):


// GET
localhost:5001/api/users  (Gets all users)

// GET + Parametros Querystring
Ejemplo: localhost:5001/api/users?pageSize=1&page=3  (Get all users with pagination)

/// GET api/users/{id}
Ejemplo: localhost:5001/api/users/1 (Get user by IdValue)

// DELETE: api/users/{id}
Ejemplo: localhost:5001/api/users/44 (Deletes user where IdValue=44)

// PUT: api/users/{id} 
Ejemplo: localhost:5001/api/users/3 (Updates user with IdValue=3, must provide a the user payload)


##Unit Test:
Once downloaded the repository can be run from Visual Studio 2017.
Or by command line entering in the XUnitTest folder. Executing the command: dotnet test

