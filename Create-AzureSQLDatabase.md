# Step 3: Create the backend Azure SQL Database

For a COVID-19 Return to Work solution, follow these steps to configure the backend on an Azure SQL database instance:

1. Create an Azure SQL database in ReturnToWork-rg using the steps described [here
](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-single-database-get-started?tabs=azure-portal)
2. Configure the database with right settings based on your needs. As a sample configuration you can start with: create a single instance database with the following config:
*Serverless, Max vCores = 6, Min vCores = 2, Enable auto-pause, Data max size = 50 GB*. Based on CPU & Memory utilization, you can scale up the number of vCores on-the-go
3. Setup appropriate firewall settings etc.
4. Download SSMS if not already setup. More information can be found [here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
5. Connect to your instance using the steps described [here](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-connect-query-ssms)

6. Set Context to use the appropriate database. Execute the [script](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/scripts/create-tables-script.sql)  create-tables-script.sql in scripts folder to create required tables for this solution
