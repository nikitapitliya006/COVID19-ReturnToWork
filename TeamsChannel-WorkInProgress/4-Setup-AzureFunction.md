# Step 4: Use Azure functions to Read From and Write To Azure SQL database and send daily reminders to Teams client

**ARM template to deploy required Azure function apps coming up shortly**
Manual steps are provided below:

1. Download codebase available in this repo at master/AzureFunctionsCodebase
2. Open downloaded solution in Visual Studio and open Solution Explorer
3. Right click on SelfMonitoring project -> Publish -> Publish -> Choose an Azure function to deploy this code and all functions as serverless Azure Function Apps 
***Please find detailed steps [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#publish-to-azure)
4. In Azure portal, navigate to the Azure Function app created in previous step and go to its Settings -> Configuration -> Application settings
5. Click on +New application setting and add Name-Value pairs. You need to add a bunch of settings to ensure automated notifications are sent to all registered users on their Teams client, please find each setting with details below:

|Name  |Value/Details
|--|--|--
|AzureADAppTenantId | Registered App's Tenant ID in Azure Active Directory
|AzureADAppClientId|Registered App's Client ID in Azure Active Directory
|AzureADAppClientSecret|Registered App's Client Secret in Azure Active Directory
|AzureADAppRedirectUri|api://_AzureADAppClientId_
|GroupId|Azure AD Group IDs, comma separated list if multiple groups
|Healthbot_Tenant_Name|tenantName from Healthcare Bot admin portal > Integration > Secrets
|Healthbot_API_JWT_SECRET|API_JWT_SECRET from Healthcare Bot admin portal > Integration > Secrets
|Healthbot_Trigger_Call|https://bot-us.healthbot.microsoft.com/api/tenants/*Healthbot_Tenant_Name*/beginScenario
|Healthbot_ScenarioId_Screening|Scenario_ID of daily screening assessment
|Healthbot_ScenarioId_Monitoring|Scenario_ID of post-exposure tracking assessment
|SqlConnectionString|Connection String of Azure SQL database created in Step 3 from README.md



6. Enable App Insights from Settings -> App Insights
