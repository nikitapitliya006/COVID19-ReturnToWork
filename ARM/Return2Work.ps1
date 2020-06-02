$subscriptionId = Read-Host -Prompt "Enter your subscription ID (look for it in the portal)"
$projectName = Read-Host -Prompt "Enter a project name that is used for generating resource names"
$location = Read-Host -Prompt "Enter an Azure location (i.e. centralus)"
$adminUser = Read-Host -Prompt "Enter the SQL server administrator username"
$adminPassword = Read-Host -Prompt "Enter the SQl server administrator password" -AsSecureString
Connect-AzAccount
Set-AzContext -subscriptionId $subscriptionId
$resourceGroupName = "${projectName}rg"

New-AzResourceGroup -Name $resourceGroupName -Location $location

#New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateUri "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-sql-logical-server/azuredeploy.json" -administratorLogin $adminUser -administratorLoginPassword $adminPassword
New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile "CreateSQL.json" -administratorLogin $adminUser -administratorLoginPassword $adminPassword
#New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateUri "https://github.com/nikitapitliya006/COVID19-ReturnToWork/blob/Julian-codereview/ARM/CreateSQL.json" -administratorLogin $adminUser -administratorLoginPassword $adminPassword
Read-Host -Prompt "Press [ENTER] to continue ..."