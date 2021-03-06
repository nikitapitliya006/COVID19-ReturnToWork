# Step 2: Register Healthcare bot as an Enterprise App and provide appropriate API permissions

For a COVID-19 Return to Work solution, follow these steps to register your bot app and use the Microsoft Graph REST API:

## App registration and API permissions:
1. Register an Enterprise application: In the Azure portal navigate to your organizations AAD and create a new App Registration. Learn more about  [creating an app registration](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#targetText=Azure%20AD%20assigns%20a%20unique,%2C%20API%20permissions%2C%20and%20more.)
2. Take note of the Application (client) ID, Directory (tenant) ID from Overview blade
3. Enable the relevant permissions for the application and if required ask a Global Admin for the organization to "Grant Admin consent". For example, if the requirement is to read user properties, the following Microsoft Graph API permissions to be added is:
	-   User.Read.All - Application Type
4. Generate a client secret: Navigate to the Certificates & Secrets for the App Registration. Create a new client secret and copy the secret to your clipboard

## Required API permissions:
1. Fetch user details in healthcare bot scenarios using Teams channel for the logged in user
The following Microsoft Graph API permissions are required:	
	-   User.Read.All - Application Type
	-  	Directory.Read.All - Application Type 
Switch to Health Bot service portal > Scenarios > Manage > RTW Registration
In Data Connection Call for OAuth Token|Graph API, update client ID and client secret from above steps and create a Payload (object) similar to this: 'grant_type=client_credentials&client_id=your-client-id&client_secret=your-client-secret&scope=https://graph.microsoft.com/.default'

2. For Azure functions to trigger daily notifications to Teams client
Azure AD groups used to identify all users to get a Teams notification for daily assessment have to be either "Office 365 groups" or "Security groups"
The following Microsoft Graph API permissions are required:	
	-   User.Read.All - Application Type
	-  	GroupMember.Read.All - Application Type 
	-   Group.Read.All - Application Type
	-  	Directory.Read.All - Application Type 



