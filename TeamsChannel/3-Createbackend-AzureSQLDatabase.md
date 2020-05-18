# Step 3: Create the backend Azure SQL Database

For a COVID-19 Return to Work solution, follow these steps to configure the backend on an Azure SQL database instance:

## Step 3.1 Create an Azure SQL database in ReturnToWork-rg

1. Sign in to the [portal](https://portal.azure.com/).
2. From the Search bar, search for and select Azure SQL.
3. On the Azure SQL page, select Add.
4. On the Select SQL deployment option page, select the SQL databases tile, with Single database under Resource type. You can view more information about the different databases by selecting Show details.
5. Select Create.
6. On the Basics tab of the Create SQL database form, under Project details, select the correct Azure Subscription if it isn't already selected.
7. Under Resource group, select Create new, enter YOUR_RESOURCE_GROUP_NAME, and select OK.
8. Under Database details, for Database name enter YOUR_DATABASE_NAME.
9. For Server, select Create new, and fill out the New server form as follows:
   1.  Server name: Enter YOUR_SQL_SERVER_NAME
   2.  Server admin login: Enter YOUR_ADMIN_LOGIN
   3.  Password: Enter a password that meets requirements, and enter it again in the Confirm password field.
   4.  Location: Drop down and choose a location
   5.  *Notes: Record the server admin login and password so you can log in to the server and databases. If you forget your login or password, you can get the login name or reset the password on the SQL server page after database creation. To open the SQL server page, select the server name on the database Overview page.*
10. Under Compute + storage, if you want to reconfigure the defaults, select Configure database. Use the following option:
    1.  Change the Compute tier from Provisioned to Serverless
    2.  Review and change the settings for vCores to be MAX 4 or 6 and MIN 2
    3.  Enable auto-pause and change the Data max size to be 50 GB
    4.  After making any changes, select Apply.
11. Select Next: Networking at the bottom of the page.
12. On the Networking tab, under Connectivity method, select Public endpoint.
13. Under Firewall rules, set Add current client IP address to Yes.
14. Select Next: Additional settings at the bottom of the page.
    1.  *For more information about firewall settings, see [Allow Azure services and resources to access this server](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-networkaccess-overview) and [Add a private endpoint](https://docs.microsoft.com/en-us/azure/private-link/private-endpoint-overview).*
15. On the Additional settings tab, in the Data source section, for Use existing data, select None.
16. Select Review + create at the bottom of the page.
17. After reviewing settings, select Create.

## Step 3.2 Download SSMS if not already setup

1. [Download SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)
2. For more information, [see here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

## Step 3.3 Connect to your instance

1. [Sign in to the Azure portal](https://portal.azure.com/).
2. Navigate to the SQL database or SQL managed instance you want to query.
3. On the Overview page, copy the fully qualified server name. It's next to Server name for a single database, or the fully qualified server name next to Host for a managed instance. The fully qualified name looks like: servername.database.windows.net, except it has your actual server name.
4. Open SSMS.
5. The Connect to Server dialog box appears. Enter the following information:
   
    | Setting        | Suggested value                 | Description                                                           |
    |----------------|---------------------------------|-----------------------------------------------------------------------|
    | Server type    | Database engine                 | Required value.                                                       |
    | Server name    | The fully qualified server name | Something like: servername.database.windows.net.                      |
    | Authentication | SQL Server Authentication       | Uses SQL Authentication.                                              |
    | Login          | Server admin account user ID    | The user ID from the server admin account used to create the server.  |
    | Password       | Server admin account password   | The password from the server admin account used to create the server. |
1. Select Connect. The Object Explorer window opens.
2. To view the database's objects, expand Databases and then expand your database node.

## Step 3.4 Set Context to use the appropriate database. Execute the create-tables-script.sql in scripts folder to create the required tables.


