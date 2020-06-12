# COVID-19 Return To Work solution with Microsoft Healthcare Bot and Azure platform 

***NOTE: Hi! This is my personal repository with contributions from Han Zhang & Greg Beaumont working on _*COVID-19 Back To Work Solution*_ at Microsoft. This is not production-grade code and has not been stress-tested. All instructions, code and templates are subject to review, modification and extensive testing from the individual user***

**Note:**
- The Healthcare bot Back To Work template comes with built-in support for FHIR persistence. Using Azure API for FHIR is our primary recommendation for healthcare organizations to provide data interoperability from different health systems.
- This section of the repo provides custom options for organizations who prefer to use Azure SQL Database as their backend data store for this solution
- This is an **ACCELERATOR KIT** to help you quickly build, test and deploy a custom solution for your organization. Microsoft’s platform provides the necessary capabilities by combining our Healthcare Bot service with the Azure platform as shown below:  

![](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/Screenshots/RefArchSQLWeb.png)



## Method 1: Use ARM templates to deploy required Azure services
1. [Configure Healthcare Bot](https://github.com/nikitapitliya006/ReturnToWork/blob/master/WebchatChannel/1-Configure-HealthcareBot.md) host using web chat channel
2. Use [ARM template](https://github.com/nikitapitliya006/ReturnToWork/blob/master/WebchatChannel/ARM-Deployment.md) to deploy required Azure SQL database and Azure Functions
3. Create reports and dashboards with [Power BI for real-time visualization](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/5-Visualize-PowerBI.md)

## Method 2: Manual steps to help you understand all underlying details

1. [Configure Healthcare Bot](https://github.com/nikitapitliya006/ReturnToWork/blob/master/WebchatChannel/1-Configure-HealthcareBot.md) host using web chat channel 
2. [Create the backend Azure SQL Database](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/2-Createbackend-AzureSQLDatabase.md)
3. [Configure Data Connection calls to Azure function](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/3-DataConnection-AzureFunction.md) . This Azure function handles write to and read from backend database 
4. Configure Azure function to [Send automated notifications for taking assessment](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/4-SendNotifications-AzureFunction.md) 
5. Create reports and dashboards with [Power BI for real-time visualization](https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/master/WebchatChannel/5-Visualize-PowerBI.md)

## Additional Resources
* Step-by-step instructions on getting started are available [here](https://techcommunity.microsoft.com/t5/healthcare-and-life-sciences/updated-on-5-24-2020-quick-start-setting-up-your-covid-19/ba-p/1230537)

More resources to be updated regularly. ARM templates to automate configuration are being worked on and will be available soon