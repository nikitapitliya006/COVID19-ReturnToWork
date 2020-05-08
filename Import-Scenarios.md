# Step 4: Import scenarios in Healthcare Bot

For a COVID-19 Return to Work solution, follow these steps to import and test scenarios:
1. Download 3 .json files from scripts folder to your computer
2. Switch to **Health Bot service portal > Scenarios > Manage**. Import the 3 scenarios
3. Please note these scenarios are currently built to run as a bot in Teams, so all properties are not applicable for debug mode in health bot
4. To edit scenarios, click on each scenario and make necessary changes in Visual Designer or Code part
5. To add images for _Cleared to Work_ or _Not Cleared to Work_, please use the respective adaptive cards and paste image URL. One example to store image could be as a blob in Azure storage -
```
{
	"type": "Image",
	"url": "https://<storage-account>.blob.core.windows.net/images/green-check-mark.png"
}
```
Adaptive cards for Screening scenario are available in **COVID19-ReturnToWork\adaptive cards\Screening** for quick use. Make sure to add images from **COVID19-ReturnToWork\images** to an Azure storage account, make the image Read Anonymous and provide its URL in the code above.
