$crm = Get-Content 'ZAP_Ecosystem_CRM.postman_collection.json' | ConvertFrom-Json
$identity = Get-Content 'ZAP_Identity.postman_collection.json' | ConvertFrom-Json
$app = Get-Content 'ZAP_App.postman_collection.json' | ConvertFrom-Json

$master = @{
    info = @{
        _postman_id = [guid]::NewGuid().ToString()
        name = "ZAP Ecosystem - Master Suite v3 (Full)"
        schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
    }
    item = @(
        @{
            name = "IDENTITY"
            item = $identity.item
        },
        @{
            name = "CRM"
            item = $crm.item
        },
        @{
            name = "APP"
            item = $app.item
        }
    )
    variable = @(
        @{
            key = "gateway"
            value = "http://localhost:5120"
            type = "string"
        }
    )
}

$master | ConvertTo-Json -Depth 100 | Set-Content 'ZAP_Ecosystem_Master_Suite_v3.postman_collection.json' -Encoding UTF8
