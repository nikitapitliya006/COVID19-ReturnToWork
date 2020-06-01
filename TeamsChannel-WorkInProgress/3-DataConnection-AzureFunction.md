# Step 3: Use Azure functions to Read From and Write To Azure SQL database 

**ARM template to deploy required Azure function apps coming up shortly**

## Step 3.1: Manual steps to create Azure functions are provided below:

1. Download codebase available in this repo at [AzureFunctionsCodebase](https://github.com/nikitapitliya006/COVID19-ReturnToWork/tree/master/AzureFunctionsCodebase)
2. Open downloaded solution in Visual Studio and open Solution Explorer
3. Right click on BackToWork project -> Publish -> Publish -> Choose an Azure function to deploy this code and all functions as serverless Azure Function Apps. 
Please find detailed steps [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#publish-to-azure)
4. In Azure portal, navigate to the Azure Function app created in previous step and go to its Settings -> Configuration -> Application settings
5. Click on +New application setting and add 
	- Name: SqlConnectionString 
	- Value: Connection String of Azure SQL database created in [Step 2](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/2-Createbackend-AzureSQLDatabase.md) in form similar to "Server=tcp:your-db-server-name;Initial Catalog=your-database-name;Persist Security Info=False;User ID=your-userID;Password=your-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
6. Enable App Insights from Settings -> App Insights. Click on "Turn on Application Insights" and create a new resource or choose an existing App Insights resource
7. On the left pane under Functions, click on Functions to get list of all deployed functions. **Get Function Url** of each function and paste it for use in Step 3.2 below.

## Step 3.2: Integrating with Healthcare bot scenario

1. After importing the healthcare bot scenario available in [Scripts folder](https://github.com/nikitapitliya006/COVID19-ReturnToWork/tree/master/Scripts) , you will notice Data Connection calls denoted by orange ovals. These elements serve in calling Rest API endpoints (in our case - Azure functions) to read from and write to Azure SQL database
2. For each data connection, the right name of the Azure function from Step 3.1.7 above has to be replaced with the dummy value provided for guidance. For example:
In Get Patient|Read SQL, Base URL = 'https://{azurefunctionsname}.azurewebsites.net/api/GetUserInfo/' + scenario.uniqueId + '?code={code}'
* Replace {azurefunctionsname} with the right function name you provided in previous step 
* Replace {code} with the authentication code generated while creation and can be obtained in "Get Function Url" step


