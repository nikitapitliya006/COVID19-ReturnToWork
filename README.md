# COVID-19 Return To Work solution with Microsoft Healthcare Bot, Azure and Teams

***Hi! This is my personal repository with contributions from my peers Han Zhang & Greg Beaumont working on _*COVID-19 Return To Work Assessment Solution*_ at Microsoft. This is not production-grade code and has not been stress-tested. All instructions, code and templates are subject to review, modification and extensive testing from the individual user***

Choose a UI channel to run this solution. Two options available using this GitHub are - Website and Microsoft Teams

### Web Chat Channel 

1. [Configure Healthcare Bot](https://github.com/nikitapitliya006/ReturnToWork/blob/master/Configure-HealthcareBot.md) host using web chat channel and import 2 scenarios
2. Azure AD App Registration and Microsoft Graph API - [Configure Microsoft Graph API call](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Call-MicrosoftGraph.md). The Microsoft Graph API allows you to use Azure Active Directory details already available for all internal employees
3. [Create the backend Azure SQL Database](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Create-AzureSQLDatabase.md)
4. [Configure Data Connection calls to Azure function](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Call-AzureFunction.md). This Azure function handles write to and read from backend database Configure data connections between health bot and Sql via Azure functions
5. Configure Azure Logic App to [Trigger daily notifications for registration and daily assessments](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Send-Notifications-LogicApps.md)
6. Create reports and dashboards with [Power BI for real-time visualization](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Visualize-PowerBI.md)

List of Microsoft services required:
* Healthcare Bot
* Azure App Service
* Azure SQL Database
* Azure function apps
* Azure logic apps
* Power BI Pro or Premium


### Microsoft Teams Channel: For using Microsoft Teams as a channel, follow these steps:
Follow steps 1-6 from Web Chat channel config. Then follow these steps:
1. Integrate with [Microsoft Teams](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Integrate-MicrosoftTeams.md)
2. In the left pane of Health bot admin portal, navigate to **Integration > Channels**. Click the activate toggle of the **Microsoft Teams** and Click **Save** to create the channel
3. Click on View and copy the Bot Id from Step 1 above

List of Microsoft services required:
* Healthcare Bot
* Microsoft Teams
* Azure SQL Database
* Azure function App
* Power BI Pro or Premium

More resources to be updated regularly. ARM templates to automate configuration are being worked on and will be available soon

Additional resource on Healthcare Bot setup for other COVID-19 related use cases using a public website can be found [here](https://techcommunity.microsoft.com/t5/healthcare-and-life-sciences/updated-on-4-2-2020-quick-start-setting-up-your-covid-19/ba-p/1230537)