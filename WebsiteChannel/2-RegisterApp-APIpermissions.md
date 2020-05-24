# Step 2: Register Healthcare bot as an Enterprise App and provide appropriate API permissions

For a COVID-19 Return to Work solution, follow these steps to register your bot app and use the Microsoft Graph REST API:

## App registration and API permissions:
1. Register an Enterprise application: In the Azure portal navigate to your organizations AAD and create a new App Registration. Learn more about  [creating an app registration](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#targetText=Azure%20AD%20assigns%20a%20unique,%2C%20API%20permissions%2C%20and%20more.)
2. Take note of the Application (client) ID, Directory (tenant) ID from Overview blade
3. Enable the relevant permissions for the application and if required ask a Global Admin for the organization to "Grant Admin consent". For example, if the requirement is to read user properties, the following Microsoft Graph API permissions to be added is:
	-   User.Read.All - Application Type
4. Generate a client secret: Navigate to the Certificates & Secrets for the App Registration. Create a new client secret and copy the secret to your clipboard

### To enable Azure AD login using Web Chat channel:
1. Navigate to API permissions and add the following two Microsoft.Graph permissions:
	-  	profile (Delegated)
	-   User.Read (Delegated)
	Note:Since these are Delegated type, you do not need Admin consent

2. Navigate to Authentication > Web > Redirect URIs, and white list the redirect URL. Healthcare Bot redirect URL for 
	- US intance: https://bot-api-us.healthbot.microsoft.com/bot/redirect/oauth2 
	- EU instance: https://bot-api-eu.healthbot.microsoft.com/bot/redirect/oauth2 
	Save the settings
