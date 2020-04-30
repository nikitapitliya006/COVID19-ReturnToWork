# Step 5: Call the Microsoft Graph REST API 

For a COVID-19 Return to Work solution, follow these steps to configure the Microsoft Graph REST API:
1. Register an Enterprise application: In the Azure portal navigate to your organizations AAD and create a new App Registration. Learn more about  [creating an app registration](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#targetText=Azure%20AD%20assigns%20a%20unique,%2C%20API%20permissions%2C%20and%20more.)
2. Take note of the Application (client) ID, Directory (tenant) ID from Overview blade
3. Enable the relevant permissions for the application and ask a Global Admin for the organization to "Grant Admin consent". For current use case of getting User properties, the following Microsoft Graph API permissions are required:
	-  	Directory.Read.All - Application Type
	-   User.Read.All - Application Type
4. Generate a client secret: Navigate to the Certificates & Secrets for the App Registration. Create a new client secret and copy the secret to your clipboard
5. Switch to **Health Bot service portal > Scenarios > Manage > Covid19 Registration** 
6. In Data Connection Call for ***OAuth Token|Graph API***, update client ID and client secret from above steps and create a **Payload (object)** similar to this: 
'grant_type=client_credentials&client_id=_your-client-id_&client_secret=_your-client-secret_&scope=https://graph.microsoft.com/.default'
7. Test the configuration by running the scenario in Teams Bot using command ***begin screen***