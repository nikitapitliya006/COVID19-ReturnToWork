# Step 2: Create the backend Azure SQL Database

For a COVID-19 Return to Work solution, follow these steps to configure the backend on an Azure SQL database instance:

## Step 2.1 Create an Azure SQL database

1. Sign in to Azure [portal](https://portal.azure.com/). From the Search bar, search for and select Azure SQL 
2. Click Add. On the Select SQL deployment option page, select the SQL databases tile, and Resource type = Single database. Click Create
3. In **Create SQL database** form under Basics, fill out the necessary details of subscription, resource group, database name 
4. Select pre-existing database Server. Or Create new and provide the necessary admin login details.
5. Select No for "Want to use SQL elastic pool"
6. Under "Compute + storage", if you want to change the defaults, select Configure database. For Back To Work solution, you can use the following option:
    1.  Change the Compute tier from Provisioned to Serverless
    2.  Review and change the settings for vCores to be MAX 4 and MIN 1
    3.  Enable auto-pause and change the Data max size to be 32 GB
    4.  After making any changes, select Apply
7. Click "Next: Networking >" at the bottom of the page
8. On the Networking tab, under Connectivity method, select Public endpoint
9. Under Firewall rules, set Add current client IP address to Yes
10. Select Next: Additional settings at the bottom of the page. *For more information about firewall settings, see [Allow Azure services and resources to access this server](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-networkaccess-overview) and [Add a private endpoint](https://docs.microsoft.com/en-us/azure/private-link/private-endpoint-overview).*
11. On the Additional settings tab, in the Data source section, for Use existing data, select None
12. Select Review + create at the bottom of the page
13. After reviewing settings, select Create

## Step 2.2 Download SSMS if not already setup

1. Download [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup). *For more information, click [ here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)*

## Step 2.3 Connect to your instance

1. Sign in to Azure [portal](https://portal.azure.com/)
2. Navigate to the SQL database or SQL managed instance you want to query
3. On the Overview page, copy the fully qualified server name. It's next to Server name for a single database, or the fully qualified server name next to Host for a managed instance. The fully qualified name looks like: servername.database.windows.net, except it has your actual server name
4. Open SSMS.
5. The Connect to Server dialog box appears. Enter the following information:
   
    | Setting        | Suggested value                 | Description                                                           |
    |----------------|---------------------------------|-----------------------------------------------------------------------|
    | Server type    | Database engine                 | Required value                                                       |
    | Server name    | The fully qualified server name | Something like: servername.database.windows.net                      |
    | Authentication | SQL Server Authentication       | Uses SQL Authentication                                              |
    | Login          | Server admin account user ID    | The user ID from the server admin account used to create the server  |
    | Password       | Server admin account password   | The password from the server admin account used to create the server |
6. Select Connect. The Object Explorer window opens
7. To view the database's objects, expand Databases and then expand your database node

## Step 2.4 Create tables

1. Set Context to use the appropriate database out of all available databases on this SQL Server
2. Execute the BackToWork-CreateTablesScript.sql in master/Scripts folder to create the required tables


