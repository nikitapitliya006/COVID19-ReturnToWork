# Add other types of login mechanisms  

The default login mechanism is to provide a Unique ID and Year of Birth. If you wish to use other types, there is support provided in the SQL database to handle the following:
1. Login using Azure Active Directory 
2. Login using UserId + Password OR Email Address + Password 

## Method 1: Login using Azure Active Directory
#### Register an Enterprise application & Grant appropriate API permissions
Before you begin the next step of Configuring Azure AD login for authenticated access to internal employees only, app registration is required. Follow the steps 
in [Register App & API permissions](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebsiteChannel/2-RegisterApp-APIpermissions.md)
	
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