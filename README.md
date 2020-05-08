# COVID-19 Return To Work solution with Microsoft Healthcare Bot & Teams

**Hi! This is my personal repository with contributions from many peers working on _*COVID-19 Return To Work Assessment Solution*_ at Microsoft. This is not production-grade code and has not been stress-tested. All instructions, code and templates are subject to review, modification and extensive testing from the individual user. **
 

## Contents

1. [Configure Healthcare Bot](https://github.com/nikitapitliya006/ReturnToWork/blob/master/Configure-HealthcareBot.md)
2. [Integrate with Microsoft Teams](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Integrate-MicrosoftTeams.md)
3. [Create the backend Azure SQL Database](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Create-AzureSQLDatabase.md)
4. [Import 3 scenarios](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Import-Scenarios.md)      required for this solution into Healthcare Bot instance
5. [Configure Microsoft Graph API call](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Call-MicrosoftGraph.md). The Microsoft Graph API allows you to use Azure Active Directory details already available for all internal employees
6. [Configure Data Connection calls to Azure function](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Call-AzureFunction.md). This Azure function handles write to and read from backend database
7. Configure Azure Logic App to [Trigger email notifications for registration and daily assessments](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Send-Notifications-LogicApps.md)
8. Integrate Azure SQL Database with  [Power BI for real-time visualization](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Visualize-PowerBI.md)

List of Microsoft services required:
* Microsoft Healthcare Bot service from Azure Marketplace
* Microsoft Teams or Azure App Service + Azure Logic App (based on channel selection)
* In Azure portal, create a Resource Group _(for example: returntowork-rg)_ and provide "Owner" role access to the project lead. Additional resources: [Organize your Azure resources](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-setup-guide/organize-resources?tabs=AzureManagementGroupsAndHierarchy) , 	[Role assignments using Azure portal](https://docs.microsoft.com/en-us/azure/role-based-access-control/role-assignments-portal)
* Azure Function app
* Azure SQL Database 
* Microsoft Graph API




More resources to be updated regularly.
