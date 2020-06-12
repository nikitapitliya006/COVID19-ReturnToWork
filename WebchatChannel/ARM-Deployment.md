# Step 2: Create the backend Azure SQL Database and Azure functions using ARM Template

## Step 2.1: Run ARM template
1. Download or clone the repo to your local drive
2. Navigate to ARM folder, you will see 5 files
3. Sign in to Azure [portal](https://portal.azure.com/). Start Cloud Shell (right next to the Search bar)
4. Follow this document to [Persist files in cloudshell storage](https://docs.microsoft.com/en-us/azure/cloud-shell/persisting-shell-storage) and upload the 5 files from ARM-Template folder of the cloned GitHub repo
5. Run the command >./BackToWork.ps1 based on the clouddrive folder you chose to upload 5 files
6. The cloudshell will prompt you for user inputs to create database, please provide the necessary details:
- Subscription ID
- (new) Resource Group name
- Azure location
- SQL server administrator username
- SQL server administrator password
- Name for Back to work database
- Sign in using the instructions provided in the prompt
![](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Screenshots/ARMTemplate-Cloudshell.png)

7. Once you provide appropriate inputs, the script will kick off creation of necessary resources. In a few minutes you will see the completion prompt asking you to acknowledge by hitting Enter
![](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Screenshots/ARMTemplate-CloudShellComplete.png)

8. Navigate to the Resource group created, you will find 7 resources created - 
![](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Screenshots/ARMTemplate-Resources.png)

9. Click on the SQL database resource. On the left pane, go to Settings -> Connection strings and copy the ADO.NET (SQL authentication) string that looks like - 
*Server=tcp:{your-db-server-name};Initial Catalog={your-database-name};Persist Security Info=False;User ID={your-userID};Password={your-password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

10. You will need an non-SA account to connect to Azure Function in the next Step [Step 3](https://github.com/microsoft/covid19-BackToWork/blob/master/WebchatChannel/3-DataConnection-AzureFunction.md). Create a user with least privileges to execute stored procedures. For more information on Database Users, please refer [here](https://docs.microsoft.com/en-us/sql/t-sql/statements/create-user-transact-sql?view=sql-server-ver15)

11. Replace the UserId and Password of the SQL Connection String with this new user's credentials

## Step 2.2: Integrate Azure services with Healthcare bot 

1. After importing the healthcare bot scenario available in [Scripts folder](https://github.com/microsoft/covid19-BackToWork/tree/master/Scripts) , you will notice Data Connection calls denoted by orange ovals. These elements serve in calling Rest API endpoints (in our case - Azure functions) to read from and write to Azure SQL database
2. For each data connection, the right name of the Azure function from Step 3.1.7 above has to be replaced with the dummy value provided for guidance. For example:
In Get Patient|Read SQL, Base URL = 'https://{azurefunctionsname}.azurewebsites.net/api/GetUserInfo/' + scenario.uniqueId + '?code={code}'
	- Replace **{azurefunctionsname}** with the right function name you provided in previous step 2.1
	- Replace **{code}** with the authentication code generated while creation and can be obtained in "Get Function Url" step

### Azure SQL Server administration and security guidelines:
- SQL database created has a default configuration of General Purpose: Gen5 Provisioned tier, 2 vCores 
- For information on Azure SQL Single Database instance, it is highly recommended to go through these links and make necessary configuration changes: 
	- [Overview documentation](https://docs.microsoft.com/en-us/azure/azure-sql/database/single-database-overview)
	- [Security documentation](https://docs.microsoft.com/en-us/azure/azure-sql/database/security-overview)
	- [Firewall settings](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-networkaccess-overview) 
	- [Add a private endpoint](https://docs.microsoft.com/en-us/azure/private-link/private-endpoint-overview)
	- [Server-level IP firewall rules](https://docs.microsoft.com/en-us/azure/azure-sql/database/firewall-create-server-level-portal-quickstart)

- Additional resources for using SSMS:
	- If you do not have SSMS, Download [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup). *For more information, click [ here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)*
	- Learn how to connect to [Azure SQL using SSMS](https://docs.microsoft.com/en-us/azure/azure-sql/database/connect-query-ssms)
	
### Azure Function security and networking guidelines:
- For securing Azure Function in your environment, take a thorough look at the following links:
	- [Securing Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/security-concepts)
	- [Networking concepts](https://docs.microsoft.com/en-us/azure/azure-functions/security-baseline)





