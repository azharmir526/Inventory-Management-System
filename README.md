# Inventory-Management-System

I have developed an inventory management system with Angular frontend, .NET 7 backend, and SQL Server database. Here is the code I have generated for you:

Frontend(Angular):

=>  I have created an Angular project using the Angular CLI. You can find the source code in the Angular folder of the GitHub repository.

=>  I have created two modules: products and sales. The products component displays the list of products with add, edit, view, and delete features. The view page is used to sale product also with buy product button  The sales component records a sale transaction. 

=> I have used the HttpClient module to communicate with the backend APIs. You can find the service classes in the services folder.

Backend:

=>  I have created a .NET 7 Web API project using Visual Studio. You can find the source code in the backend folder of the GitHub repository.

=>  I have used Entity Framework Core for the data access layer. You can find the models, contexts, and migrations in the Models folder.

=>  I have created three controllers: ProductsController, SalesController, and PurchasesController. The ProductsController handles the CRUD operations for products. The SalesController handles the API for recording a sale transaction. The PurchasesController handles the API for tracking a purchase order.

Database:

=>  I have assumed that you have SQL Server installed on your machine. You can find the connection string in the appsettings.json file in the backend folder.

=>  I have created three tables: Products, Sales, and Purchases. The Products table has the following columns: Id, Name, Description, and Quantity. The Sales table has the following columns: Id, ProductId, Quantity, and Date. The Purchases table has the following columns: Id, ProductId, Quantity, OrderDate, and ReceiptDate.

=>  I have used Entity Framework Core migrations to create and update the database schema. You can find the migration scripts in the Migrations folder.
Instructions:

To run the frontend, you need to have Node.js and Angular CLI installed on your machine. You can follow the steps below:
Navigate to the frontend folder in the terminal.
Run npm install to install the dependencies.
Run ng serve to start the development server.
Open http://localhost:4200 in your browser to see the frontend.

To run the backend, you need to have Visual Studio and .NET 7 SDK installed on your machine. You can follow the steps below:
Navigate to the backend folder in the file explorer.
Double-click on the InventoryManagement.sln file to open the solution in Visual Studio.
Update the connection string in the appsettings.json file if needed.
Run Update-Database or entityframework/Update-Database in the Package Manager Console to apply the migrations to the database.
Press F5 to run the backend project.
The backend API will be available at http://localhost:15489/.
To test the functionality, you can use the frontend UI or a tool like Postman to send requests to the backend API.
I hope this helps you with your scenario. Please let me know if you have any questions or feedback. 😊
