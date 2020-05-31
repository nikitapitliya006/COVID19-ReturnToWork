# Advanced Customization to logic of Back to Work solution in Healthcare Bot, Azure functions and Azure SQL Database

To customize a COVID-19 Back to Work solution writing to SQL, follow these steps :
## Step 1: Change flow in healthcare bot scenario

## Step 2: If necessary, modify Azure SQL database schema

## Step 3: Update Azure function accordingly

1. Change Settings -> Configuration. Click on SqlConnectionString, edit Value to the new connection string ---???? 

To update Azure functions, follow these steps:
1. Download/clone code from /AzureFunctionsCodebase folder
2. BackToWorkFunctions -> Model -> {relevant table name}.cs, add the exact column name
3. Make changes in BackToWorkFunctions -> Helper -> DBHelper.cs class. Functions PostDataAsync and GetDataAsync will need modification
4. Build and test the VS solution. Then right click on BackToWorkFunctions and Publish it to the same Azure function as before. For more details on publishing Azure function from local repo, refer [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#publish-to-azure)





