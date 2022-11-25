# MacroCompanyServices

A website whose topic is employees and products that are created by them.

## How do it works

The user can register or log in as an administrator or as a normal user. There are several different permissions and restrictions for these roles. For example, if a user is logged in as an administrator, he can create, read, update and delete the data about all employees and other entities in the application. If user logs in as usual person, he only can create or update the data about employees and products, but he can add to his cart any product he wants. Anonymous users can only look through the data about employees and products.

An application can have only one administrator account. Administrator credentials, such as login or password, are defined in the code.
There can be as many regular user accounts as you like. A regular user logs into the application.

## Used tools
* C# 10 and .NET 6
* ASP.NET Core MVC 6
* Entity Framework Core 6
* Identity
* MS SQL Server
