# Step 1: Configure Healthcare Bot

For a COVID-19 Return to Work solution, follow these steps to configure a healthcare bot
1. Login to [https://portal.azure.com](https://portal.azure.com/) and search for ***Microsoft Healthcare Bot*** in the Azure Marketplace
2. Enter details choosing Plan: W1-Free and click “Subscribe”
3. In Azure portal, go to **Home | Software as a Service (SaaS)**, click on the healthcare bot instance. In Overview blade, click on "Manage Account". You will be redirected to Health Bot Service admin portal 
4. Choose a channel to run this solution. Two options available using this GitHub are - Website and Microsoft Teams.

## Channel 1: To run the solution on a Website with authenticated login, follow these steps:
#### Configure Web Chat channel
1. In the left pane of Health bot admin portal, navigate to **Integration > Secrets**
2. Copy APP_SECRET and WEBCHAT_SECRET and keep it handy for Step 4 below
3. To deploy web chat to Azure, go to Github repository [link](https://github.com/Microsoft/HealthBotcontainersample) . Click “Deploy to Azure”
4. In Deploy to Azure config page, provide the desired configuration details and paste App Secret and Webchat Secret values from Step 2. Click Next -> Deploy
5. Follow the section **Creating the Web Chat Channel** from the blog [here](https://techcommunity.microsoft.com/t5/healthcare-and-life-sciences/updated-on-4-2-2020-quick-start-setting-up-your-covid-19/ba-p/1230537) for additional customization to website chat window 

#### Configure Azure AD login
1. In the left pane of Health bot admin portal, navigate to **Integration > Authentication**
2. Add a New Authentication provider. Sample values 
	- Name: AAD
	- Description: Authenticate users via Azure AD 
	- Authentication method: OAuth 2.0: End-user Authentication
For remaining details, first register your app using Steps 3,4,5 below
3. Add your client app details by registering App in Azure Active Directory as explained in App registration and API permissions section of Step 5: [Call-MicrosoftGraph](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Call-MicrosoftGraph.md)
4. Navigate to Authentication > Web > Redirect URIs, and white list the redirect URL. If you are running a US instance of Healthcare Bot whitelist: https://bot-api-us.healthbot.microsoft.com/bot/redirect/oauth2 .If you are running an EU instance of Healthcare Bot whitelist: https://bot-api-eu.healthbot.microsoft.com/bot/redirect/oauth2 and Save the settings
5. Navigate to API permissions and add the following two Microsoft.Graph permissions to enable AAD login:
	-  	profile (Delegated)
	-   User.Read (Delegated)
	For more details on End User Authentication: please refer https://docs.microsoft.com/en-us/healthbot/integrations/end_user_authentication
6. Copy values Client ID, Client secret, and paste it in Authentication provider tab of healtcare bot
7. Next set of values are - (*tenant-ID* = your organization's Azure tenant ID)
	- Authorization URL: https://login.microsoftonline.com/*tenant-ID*/oauth2/v2.0/authorize 
	- Access Token URL: https://login.microsoftonline.com/*tenant-ID*/oauth2/v2.0/token
	- scope: https://graph.microsoft.com/.default
8. Save or Update the details

## Channel 2: For using Microsoft Teams as a channel, follow these steps:
1. In the left pane of Health bot admin portal, navigate to **Integration > Channels**. Click the activate toggle of the **Microsoft Teams** and Click **Save** to create the channel
2. Click on View and copy the Bot Id for Step 2: [Integrate with Microsoft Teams](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Integrate-MicrosoftTeams.md)

Additional resource on Healthcare Bot setup for other COVID-19 related use cases using a public website can be found [here](https://techcommunity.microsoft.com/t5/healthcare-and-life-sciences/updated-on-4-2-2020-quick-start-setting-up-your-covid-19/ba-p/1230537)