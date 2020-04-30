# Step 3: Create the backend Azure SQL Database

For a COVID-19 Return to Work solution, follow these steps to configure the backend on an Azure SQL database instance:

1. Create an Azure SQL database in ReturnToWork-rg using the steps described [here
](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-single-database-get-started?tabs=azure-portal)

2. Download SSMS if not already setup. More information can be found [here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
3. Connect to your instance using the steps described [here](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-connect-query-ssms)

4. Set Context to use the appropriate database. Execute the create-tables-script.sql in scripts folder to create the required tables.
