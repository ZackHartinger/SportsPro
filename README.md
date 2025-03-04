<h1>SportsPro</h1>
<h3>An ASP.NET Core MVC app</h3>
<p>Features:</p>
<ul>
  <li>Authentication</li>
  <li>Validation</li>
  <li>SQL Server Database</li>
  <li>Dependency Injection</li>
  <li>Repository Service</li>
</ul>
<h2>About this project</h2>
<p>SportsPro is a data driven app that uses Razor views for the UI, ASP.NET Core for functionality and authentication, SQL Server for the database and leverages EntityFramework for interacting with the database. SportsPro is a fictitous company that manages sports software. SportsPro has collections of products and customers, as well as technicians and incidents associated with customers' products. Anonymous users are only able to view the home, about, login and register pages. Anonymous users are granted access to the update incident page used by technicians. Users of the admin role have full access to the suite of features this app provides.</p>

<p>Users with admin permissions are able to:</p>
<ul>
  <li>Add, edit and delete products, technicians, customers and incidents to the database</li>
  <li>Assign incidents to technicians</li>
  <li>Register products to customers</li>
</ul>

<div align="center">
  <img src="READMEImages/sportspro_screenshot_1.png">
</div>

<div align="center">
  <img src="READMEImages/sportspro_screenshot_2.png">
</div>

<div align="center">
  <img src="READMEImages/sportspro_screenshot_3.png">
</div>

<h2>How to run the program locally</h2>

<p>Software needed:</p>
<ul>
  <li>Visual Studio</li>
  <li>SQL Server Management Studio or another SQL database provider</li>
  <ul>
    <li>Please note that if using a different database, you will have to change the connection string found in appsetting.json to use your database and may need to add appropriate NuGet packages if using MySQL, Postrges, or a NoSQL database.</li>
  </ul>
</ul>

<h3>Step 1: Cloning the project repository</h3>
<p>Clone the repository by clicking the Code button in the top right corner. Select the HTTPS button and copy the link provided.</p>

<div align="center">
  <img src="READMEImages/clone_instructions_1.png"> 
</div>

<p>Open Visual Studio and choose "continue without code" from the new project options.</p>
<p>Select Git in Visual Studio's toolbar and select the option to Clone a Repository. This will open a dialogue where you can paste the repositorie's url you copied earlier. Then, click the clone button in the bottom right corner.</p>
<div align="center" >
  <img src="READMEImages/clone_instructions_2.png">
</div>

<h3>Step 2: Creating the database</h3>
<p>First, make changes to the connection string if not using SQL Server. The connection string can be found in appsettings.json. By default the connection string is set to a local instance of a SQL Server database.</p>
<p>While still in Visual Studio, navigate to the Package Manager console.</p>

<img src="READMEImages/database_instructions.png" height= "300">

<p>Run the following commmand:</p>


```
  update database
```
<p>If the database does not exist one will be created and Entity Framework will create all of the tables and add any records added in the configuration files.</p>

<h3>Step 3: Running the application</h3>
<p>Now that the database is set up, you can click run in Visual Studio and the app will launch in your default browser.</p>

> [!NOTE]
><p>By default there is only one user in the database. This user has admin permissions and you will need to log in using it's credentials to use all of the features of the application. The admin user's credentials are:</p>
><ul>
>  <li>Username: admin</li>
>  <li>Password: P@ssw0rd</li>
></ul>

