# Step 1: Configure Healthcare Bot

For a COVID-19 Return to Work solution, follow these steps to configure a healthcare bot
1. Login to [https://portal.azure.com](https://portal.azure.com/) and search for ***Microsoft Healthcare Bot*** in the Azure Marketplace
2. Enter details choosing Plan: W1-Free and click “Subscribe”
3. In Azure portal, go to **Home | Software as a Service (SaaS)**, click on the healthcare bot instance. In Overview blade, click on "Manage Account". You will be redirected to Health Bot Service admin portal 
4. Import scenarios "RTW Registration" and "RTW Daily Assessment" shared by your account team


## To run the solution on a Website with authenticated login, follow these steps:
#### Configure Web Chat channel
1. In the left pane of Health bot admin portal, navigate to **Integration > Secrets**
2. Copy APP_SECRET and WEBCHAT_SECRET and keep it handy for Step 4 below
3. To deploy web chat to Azure, go to Github repository [link](https://github.com/Microsoft/HealthBotcontainersample) . Click “Deploy to Azure”
4. In Deploy to Azure config page, provide the desired configuration details and paste App Secret and Webchat Secret values from Step 2. Click Next -> Deploy
5. Follow the section **Creating the Web Chat Channel** from the blog [here](https://techcommunity.microsoft.com/t5/healthcare-and-life-sciences/updated-on-4-2-2020-quick-start-setting-up-your-covid-19/ba-p/1230537) for additional customization to website chat window 
6. In public/index.js file, change triggered_scenario: { trigger:"RTW_register"} to begin the solution

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

#### Some UI changes to scenarios:
1. To edit scenarios, click on each scenario and make necessary changes in Visual Designer or Code part
2. To add images for _Cleared to Work_ or _Not Cleared to Work_, please use the respective adaptive cards and paste image URL. One example to store image could be as a blob in Azure storage -
```
{
	"type": "Image",
	"url": "https://<storage-account>.blob.core.windows.net/images/green-check-mark.png"
}
```

**Note:**
* Adaptive cards for Screening scenario are available in **COVID19-ReturnToWork\AdaptiveCards\Screening** for quick use. Make sure to add images from **COVID19-ReturnToWork\images** to an Azure storage account, make the image Read Anonymous and provide its URL in the code above.
* There is an Azure storage account created during configuring the Azure Function app, you can use the same storage accoutn to store these images to be used in adaptive cards.



