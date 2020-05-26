# Step 5: Send automated notications to registered users 

Pre-requisites:
* All registered users should have provided a valid email address to get notified with a link of the bot 
* If SMS reminders are needed: setup Twilio connection, details [here](https://docs.microsoft.com/en-us/azure/connectors/connectors-create-api-twilio)

Azure functions are used to send automated notification either based on a 
1. HTTP trigger where administrator manually triggers the send notification function
2. Recurrence based trigger to send notification at a specific pre-determined time interval

In this GitHub repo, we provide an Azure function that will send notification at a recurrence.



