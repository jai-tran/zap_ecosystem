# Start all ZAP Ecosystem services in separate windows for local Postman testing

Write-Host "Starting ZAP Ecosystem Services..." -ForegroundColor Cyan

$services = @(
    @{ Name = "Gateway"; Path = "src/Gateway/ZAP.Gateway" },
    @{ Name = "Identity"; Path = "src/Services/Identity/ZAP.Identity.API" },
    @{ Name = "CRM"; Path = "src/Services/Ecosystem/CRM/ZAP.Ecosystem.API.CRM" },
    @{ Name = "App"; Path = "src/Services/Ecosystem/App/ZAP.Ecosystem.API.App" }
)

foreach ($service in $services) {
    Write-Host "Launching $($service.Name)..." -ForegroundColor Yellow
    Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $($service.Path); dotnet run --launch-profile http"
}

Write-Host "All services are launching. Gateway is available at http://localhost:5120" -ForegroundColor Green
Write-Host "Please use 'ZAP - Local' environment in Postman." -ForegroundColor Green
