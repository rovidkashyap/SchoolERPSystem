# SchoolERPSystem
SMS (School Management System)

This is School Management System which includes all the School Features (including classes, subjects, teachers, attendance, reports etc)

Project Technologies-
1 - .Net Framework 4.6
2 - ASP.Net MVC
3 - Backend - C#
4 - Database - Sql Server 2016
5 - Entity Framework 6

Project Design Patterns is using Repository Pattern. It contains 5 Projects in single Solution. Description of each Project is define below:

1 - Models Project - This containts all the Model Classes(Entity Classes) used in the application and also contains Database Context class beckause we 
are using Entity Framework in the application

2 - Repository Project - This is the Main Layer of the application as it contains the Repository classes of the application and in the repository it holds the Interfaces
and Repositories classes which implements those interfaces.

3 - Service Project - This is another Layers of the application which contains all the service layers classes which means this layer communicates with the Repository layers
and those layers will access in the service layer, all the logics and validation will be implemented in this layer.

4 - Web Application Project - This is the Presentation layer of the application as it design in the MVC Framework so this Layer will communicates with the service layer and data
will be displayed in this layer.


For User Authentication and Authorization we are using ASP.Net Identity.
