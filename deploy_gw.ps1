$configPrefix = "crm-api-config"
$timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
$configName = "$configPrefix-$timestamp"

Write-Host "Creating new API config: $configName"
gcloud api-gateway api-configs create $configName `
  --api=crm-api-v1 `
  --openapi-spec=openapi.yaml `
  --backend-auth-service-account=204573236312-compute@developer.gserviceaccount.com `
  --project=zapcrm-492101

Write-Host "Updating gateway to use: $configName"
gcloud api-gateway gateways update zap-ecosystem-gateway `
  --api=crm-api-v1 `
  --api-config=$configName `
  --location=us-central1 `
  --project=zapcrm-492101

Write-Host "API Gateway deployment complete!"
