$yaml = ""
$yaml += "swagger: '2.0'
"
$yaml += "info:
"
$yaml += "  title: CRM Gateway Config
"
$yaml += "  description: API Gateway mapping for CRM API
"
$yaml += "  version: 1.0.0
"
$yaml += "schemes:
"
$yaml += "  - https
"
$yaml += "paths:
"
$yaml += "  /api/v1/auth/login:
"
$yaml += "    post:
"
$yaml += "      summary: Login Customer/Employee
"
$yaml += "      operationId: loginAuth
"
$yaml += "      x-google-backend:
"
$yaml += "        address: https://identity-api-204573236312.asia-southeast1.run.app/api/v1/auth/login
"
$yaml += "      responses:
"
$yaml += "        '200':
"
$yaml += "          description: OK
"

$routes = @('promotions', 'collections', 'locations', 'categories', 'customers', 'customergroups', 'menus', 'diningoptions', 'brands', 'products', 'modifiergroups', 'paymenttypes', 'paymentterms')

foreach ($r in $routes) {
    $prefixes = @("/api/$r", "/api/v1/catalog/$r", "/api/v1/crm/$r")
    
    foreach ($p in $prefixes) {
        $opId = $p.Replace("/", "_").Replace("-", "_")
        
        $yaml += "  ${p}/list:
"
        $yaml += "    post:
"
        $yaml += "      operationId: list$opId
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}/list
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"

        $yaml += "  ${p}:
"
        $yaml += "    get:
"
        $yaml += "      operationId: get$opId
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"
        $yaml += "    post:
"
        $yaml += "      operationId: post$opId
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"

        $yaml += "  ${p}/{id}:
"
        $yaml += "    get:
"
        $yaml += "      operationId: get_id$opId
"
        $yaml += "      parameters:
"
        $yaml += "        - name: id
"
        $yaml += "          in: path
"
        $yaml += "          required: true
"
        $yaml += "          type: string
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}/{id}
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"
        $yaml += "    put:
"
        $yaml += "      operationId: put_id$opId
"
        $yaml += "      parameters:
"
        $yaml += "        - name: id
"
        $yaml += "          in: path
"
        $yaml += "          required: true
"
        $yaml += "          type: string
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}/{id}
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"
        $yaml += "    delete:
"
        $yaml += "      operationId: delete_id$opId
"
        $yaml += "      parameters:
"
        $yaml += "        - name: id
"
        $yaml += "          in: path
"
        $yaml += "          required: true
"
        $yaml += "          type: string
"
        $yaml += "      x-google-backend:
"
        $yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app${p}/{id}
"
        $yaml += "      responses: { '200': { description: 'OK' } }
"
    }
}

# Add system dictionaries
$yaml += "  /api/v1/system/dictionaries/entities:
"
$yaml += "    get:
"
$yaml += "      operationId: get_dictionaries_entities
"
$yaml += "      x-google-backend:
"
$yaml += "        address: https://crm-api-204573236312.asia-southeast1.run.app/api/v1/system/dictionaries/entities
"
$yaml += "      responses: { '200': { description: 'OK' } }
"

Out-File openapi.yaml -InputObject $yaml -Encoding UTF8

