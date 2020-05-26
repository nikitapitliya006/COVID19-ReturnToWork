# Add other types of login mechanisms  

The default login mechanism is to provide a Unique ID and Year of Birth. If you wish to use other types, there is support provided in the SQL database to handle the following:
1. Login using Azure Active Directory 
2. Login using UserId + Password OR Email Address + Password 

## Method 1: Login using Azure Active Directory
#### Register an Enterprise application & Grant appropriate API permissions
Before you begin the next step of Configuring Azure AD login for authenticated access to internal employees only, app registration is required. 
1. Register an Enterprise application: In the Azure portal navigate to your organizations AAD and create a new App Registration. Learn more about  [creating an app registration](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#targetText=Azure%20AD%20assigns%20a%20unique,%2C%20API%20permissions%2C%20and%20more.)
2. Take note of the Application (client) ID, Directory (tenant) ID from Overview blade
3. Enable the relevant permissions for the application and if required ask a Global Admin for the organization to "Grant Admin consent". To enable login, the following Microsoft Graph API permissions need to be added:
	-  	profile (Delegated)
	-   User.Read (Delegated)
	Note:Since these are Delegated type, you do not need Admin consent
4. Generate a client secret: Navigate to the Certificates & Secrets for the App Registration. Create a new client secret and copy the secret to your clipboard
5. Navigate to Authentication > Web > Redirect URIs, and white list redirect URL. Healthcare Bot redirect URL for 
	- US intance: https://bot-api-us.healthbot.microsoft.com/bot/redirect/oauth2 
	- EU instance: https://bot-api-eu.healthbot.microsoft.com/bot/redirect/oauth2 
	Save the settings

*For more details on End User Authentication: please refer https://docs.microsoft.com/en-us/healthbot/integrations/end_user_authentication*

#### Configure Azure AD login in Healthcare Bot
1. In the left pane of Healthcare bot admin portal, navigate to **Integration > Authentication**
2. Add a New Authentication provider. Sample values 
	- Name: Azure AD
	- Description: Authenticate users via Azure AD login
	- Authentication method: OAuth 2.0: End-user Authentication
3. Paste values of Client ID and Client secret obtained during registering the app in previous section
4. Next set of values are - (*tenant-ID* = your organization's Azure tenant ID)
	- Authorization URL: https://login.microsoftonline.com/*tenant-ID*/oauth2/v2.0/authorize 
	- Access Token URL: https://login.microsoftonline.com/*tenant-ID*/oauth2/v2.0/token
	- scope: https://graph.microsoft.com/.default
5. Save or Update the details

## Method 2: Login using UserId + Password OR Email Address + Password

The SQL database created in Step 3 of the Website Channel solution has a UserInfo table with a column "Password" to allow you store encrypted passwords. Please make necessary changes in the client application side (Healthcare bot scenario in this case) to implement the required functionality.