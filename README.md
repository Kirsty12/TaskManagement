# TaskManagement Application
This is a simple task management application that allows users to add, update and delete tasks on a task list. Includes features like search and filter to improve usability and provide a quick and easy way to view your tasks.  The App also utilises the full calendar api to display the tasks on a calendar view, based on their due date. 

#Database Info
Application uses mssql database - to install and configure sql db using docker, please follow instructions below:  

--- Lets get it started ---
To install SQL Server in Docker, you can follow these general steps. These instructions assume you have Docker installed on your machine. If you do not, please download from https://www.docker.com/

1. Pull the SQL Server Docker Image:
Open a terminal or command prompt and run the following command to pull the SQL Server Docker image from the official Microsoft repository:

	docker pull mcr.microsoft.com/mssql/server


2. Run a SQL Server Container:
Use the following command to run a SQL Server container. Replace [PASSWORD] with a strong password for the SA (System Administrator) account. You can also customise other parameters like the container name, port, and environment variables:

	docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=[Password]" -p 1433:1433 --name 			sql_server_container -d mcr.microsoft.com/mssql/server

Explanation of the parameters:
	-e 'ACCEPT_EULA=Y': Accept the End-User Licensing Agreement.
	-e 'SA_PASSWORD': Set the SA password.
	-p 1433:1433: Map the host port 1433 to the container port 1433.
	--name sql_server_container: Give the container a name (you can choose any name).
	-d: Run the container in the background.


3. Connect to SQL Server:
Once the container is running, you can connect to SQL Server using a SQL Server client or tools like SQL Server Management Studio (SSMS), Azure Data Studio, VS Code etc. 
Connect to the server using the following details:

	Server: localhost,1433
	Username: sa
	Password: Use the password you specified in the SA_PASSWORD environment variable.

Once you have your database set up and connected, please amend the Connection String in the appsettings.json file using the server name and password from the steps above, in order to connect to a local db instance and run the application. 
 
