# Step 2: Integrate Healthcare Bot with Microsoft Teams

For a COVID-19 Return to Work solution, follow these steps to integrate healthcare bot with Microsoft Teams:
### Test bot as an admin
Conduct a quick test to ensure your bot is available and responding in Teams: 
* Click on the **Test** option from within the Channel setting page in **Health Bot Admin portal > Integration > Channels**
* Alternatively, you can directly reference your bot's ID from within Microsoft Teams:
	1.  Paste Bot Id _(Copied in Step 1)_ in the search box in the top left in Microsoft Teams. In the search results page, navigate to the People tab to see your bot and start chatting with it.
	2.  You can also open the Chat pane, select the  **Add chat**  icon. In **To:**  paste Bot ID _(Copied in Step 1)_


### Create bot as a Teams App: Admin settings

1. Install App Studio: App Studio is a Teams app which can be found in the Teams store. Follow this link for direct download:  [App Studio](https://aka.ms/InstallTeamsAppStudio)  (you can also find the app in the app store). In the store, search for App Studio and Install.
![](screenshots/AppStudio.png)

2. Create a new app: In App Studio, click on the ***Manifest editor*** tab where you can either import an existing app or create a new app. We will create a new app in this tutorial
![](screenshots/ManifestEditor.png)

3. Complete **Details** step by providing setup details similar to as seen in the screenshots 
![](screenshots/AppDetails-Part1.png)

![](screenshots/AppDetails-Part2.png)

4. In **Capabilities**, select _Bots_. Click on Setup, choose required features in **Set up a bot** dialog and Save. Click on Edit and paste Bot ID as seen in the screenshot below and **Save**. 
![](screenshots/Step2-BotsCapabilities.png)

![](screenshots/EnterBotID.png)

5. In **Finish**, select _Test and distribute_. Click on "Install" and "Add"
![](screenshots/Test&Distribute.png)

6. On the left pane, you will see a ***RTW*** icon, right click on it and pin it to the left pane for easy access

### Publish bot for your organization as a Teams App
1. Go to ***Manifest editor*** tab of the above RTW app in Teams. In **Finish**, select _Test and distribute_. Click on "Download", this will download a compressed package of your app 
2. In the lower left corner of Teams, choose the **Apps** icon. On the Store page, choose "Upload a custom app"
3. In the Open dialog, navigate to the package you downloaded to upload and choose Open and click Add
![](screenshots/UploadCustomApp.png)