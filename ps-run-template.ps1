#region Variables
$ResourceGroupName = 'demo'
$Location = 'WestEurope'
#endregion

#region Connect to Azure
Add-AzureRmAccount
 
#Select Azure Subscription
$subscription = 
(Get-AzureRmSubscription |
        Out-GridView `
        -Title 'Select an Azure Subscription ...' `
        -PassThru)
 
Set-AzureRmContext -SubscriptionId $subscription.Id -TenantId $subscription.TenantID

#endregion

#New-AzureRmResourceGroupDeployment -ResourceGroupName 'demo' -TemplateUri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/functions/listkeys.json -storageAccountName 'didagogibstorageaccount'

# region Example for if condition
$template = @'
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": { 
    },
    "variables": {
		"sbVersion": "[providers('Microsoft.ServiceBus', 'namespaces').apiVersions[0]]",
		"defaultSASKeyName": "RootManageSharedAccessKey",
		"authRuleResourceId": "[resourceId('Microsoft.ServiceBus/namespaces/authorizationRules', 'didago-gib', variables('defaultSASKeyName'))]"
    },
    "resources": [ ],
    "outputs": {
        "ifOutput": {
            "value": "[listkeys(resourceId('Microsoft.ServiceBus/namespaces/authorizationRules', 'didago-gib', 'RootManageSharedAccessKey'), providers('Microsoft.ServiceBus', 'namespaces').apiVersions[0]).primaryConnectionString]",
            "type": "string"
        }
    }
}
'@
#endregion

$template | Out-File -File d:\tmp\template.json -Force

#region Test ARM Template
Test-AzureRmResourceGroupDeployment -ResourceGroupName $ResourceGroupName -TemplateFile d:\tmp\template.json -OutVariable testarmtemplate
#endregion

#region Deploy ARM Template with local Parameter file
$result = (New-AzureRmResourceGroupDeployment -ResourceGroupName $ResourceGroupName -TemplateFile d:\tmp\template.json)
$result
#endregion
