# Step 3: Use Azure functions to Read From and Write To Azure SQL database 

**ARM template to deploy required Azure function apps coming up shortly**

Manual steps are provided below:

1. Download codebase available in this repo at master/AzureFunctionsCodebase
2. Open downloaded solution in Visual Studio and open Solution Explorer
3. Right click on BackToWork project -> Publish -> Publish -> Choose an Azure function to deploy this code and all functions as serverless Azure Function Apps. 
Please find detailed steps [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#publish-to-azure)
4. In Azure portal, navigate to the Azure Function app created in previous step and go to its Settings -> Configuration -> Application settings
5. Click on +New application setting and add 
	- Name: SqlConnectionString 
	- Value: Connection String of Azure SQL database created in Step 3 from README.md in form similar to "Server=tcp:your-db-server-name;Initial Catalog=your-database-name;Persist Security Info=False;User ID=your-userID;Password=your-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
6. Enable App Insights from Settings -> App Insights. Click on "Turn on Application Insights" and create a new resource or choose an existing App Insights resource.
