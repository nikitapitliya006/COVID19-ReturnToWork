# Step 4: Send automated notications to registered users 

Pre-requisites:
* All registered users should have provided a valid email address or mobile number to get notified with a link of the bot 
* If SMS reminders are needed: setup Twilio connection, details [here](https://docs.microsoft.com/en-us/azure/connectors/connectors-create-api-twilio)

Azure functions are used to send automated notification either based on a 
1. HTTP trigger where administrator manually triggers the send notification function
2. Recurrence based trigger to send notification at a specific pre-determined time interval

In this GitHub repo, we provide an Azure function that will send notification at a recurrence.
If you followed Step 3 - DataConnection with Azure function and created all the Azure functions, go to Azure portal -> BackToWorkFunctions -> Functions. You will see 

| Name                | Trigger  | Status     |
|---------------------|----------|------------|
|TriggerNotification  | Timer    | Disabled   |

We need to modify 2 things for this function and this can be done in the cloned Visual Studio codebase.
Open your codebase and go to TriggerNotification.cs 
1) In Line 12, there is a <[Disable] > just above FunctionName("TriggerNotification"). Remove this line
2) Modify the ncrontab expression ("0 8 0 * * *") to suit a time based on your decisions. Find more details on ncrontab expressions [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer?tabs=csharp#ncrontab-expressions)

Final code for an enabled trigger function running everyday at 8 am looks like:
```
[FunctionName("TriggerNotification")]
public static void Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
{
    SendNotificationToAllRegisteredUsers();            
}
```


