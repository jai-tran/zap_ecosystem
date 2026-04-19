const fs = require('fs');

function updateCollection(path, getCatalog) {
    if (!fs.existsSync(path)) {
        console.log(`File not found: ${path}`);
        return;
    }
    const data = JSON.parse(fs.readFileSync(path, 'utf8'));
    const catalogItem = getCatalog(data);

    if (catalogItem) {
        const brandsFolder = {
            "name": "brands",
            "description": "",
            "item": [
                {
                    "name": "list",
                    "request": {
                        "method": "POST",
                        "header": [{"key": "Content-Type", "value": "application/json"}],
                        "body": {
                            "mode": "raw",
                            "raw": JSON.stringify({
                                "page_index": 1,
                                "page_size": 10,
                                "search": "",
                                "filters": {}
                            }, null, 2),
                            "options": {"raw": {"language": "json"}}
                        },
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/brands/list",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "brands", "list"]
                        }
                    }
                },
                {
                    "name": "getById",
                    "request": {
                        "method": "GET",
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/brands/:id",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "brands", ":id"],
                            "variable": [{"key": "id", "value": ""}]
                        }
                    }
                },
                {
                    "name": "create",
                    "request": {
                        "method": "POST",
                        "header": [{"key": "Content-Type", "value": "application/json"}],
                        "body": {
                            "mode": "raw",
                            "raw": JSON.stringify({
                                "brand_code": "NEW-BRAND",
                                "name": "New Brand Name",
                                "slug": "new-brand-name",
                                "description": "Description here",
                                "is_premium": true
                            }, null, 2),
                            "options": {"raw": {"language": "json"}}
                        },
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/brands/create",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "brands", "create"]
                        }
                    }
                },
                {
                    "name": "update",
                    "request": {
                        "method": "PUT",
                        "header": [{"key": "Content-Type", "value": "application/json"}],
                        "body": {
                            "mode": "raw",
                            "raw": JSON.stringify({
                                "name": "Updated Brand Name",
                                "description": "Updated Description"
                            }, null, 2),
                            "options": {"raw": {"language": "json"}}
                        },
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/brands/:id",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "brands", ":id"],
                            "variable": [{"key": "id", "value": ""}]
                        }
                    }
                },
                {
                    "name": "delete",
                    "request": {
                        "method": "DELETE",
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/brands/:id",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "brands", ":id"],
                            "variable": [{"key": "id", "value": ""}]
                        }
                    }
                }
            ]
        };

        const unitsFolder = {
            "name": "units",
            "description": "",
            "item": [
                {
                    "name": "list",
                    "request": {
                        "method": "POST",
                        "header": [{"key": "Content-Type", "value": "application/json"}],
                        "body": {
                            "mode": "raw",
                            "raw": JSON.stringify({
                                "page_index": 1,
                                "page_size": 10,
                                "search": ""
                            }, null, 2),
                            "options": {"raw": {"language": "json"}}
                        },
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/units/list",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "units", "list"]
                        }
                    }
                },
                {
                    "name": "getById",
                    "request": {
                        "method": "GET",
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/units/:id",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "units", ":id"],
                            "variable": [{"key": "id", "value": ""}]
                        }
                    }
                },
                {
                    "name": "create",
                    "request": {
                        "method": "POST",
                        "header": [{"key": "Content-Type", "value": "application/json"}],
                        "body": {
                            "mode": "raw",
                            "raw": JSON.stringify({
                                "code": "TEST-UOM",
                                "name": "Test Unit",
                                "precision": 0,
                                "is_active": true
                            }, null, 2),
                            "options": {"raw": {"language": "json"}}
                        },
                        "url": {
                            "raw": "{{gateway}}/api/v1/catalog/units/create",
                            "host": ["{{gateway}}"],
                            "path": ["api", "v1", "catalog", "units", "create"]
                        }
                    }
                }
            ]
        };

        if (!catalogItem.item.find(i => i.name === 'brands')) {
            catalogItem.item.push(brandsFolder);
        }
        if (!catalogItem.item.find(i => i.name === 'units')) {
            catalogItem.item.push(unitsFolder);
        }

        fs.writeFileSync(path, JSON.stringify(data, null, 4));
        console.log(`Updated: ${path}`);
    } else {
        console.log(`Catalog folder not found in: ${path}`);
    }
}

// Update ZAP_Ecosystem_CRM
updateCollection('d:/01-Working/PROJECTS/ZAP/Project/ecosystem/ZAP_Ecosystem_CRM.postman_collection.json', (data) => {
    return data.item[0].item[0].item.find(i => i.name === 'catalog');
});

// Update ZAP_Ecosystem_Master_Suite_v3
updateCollection('d:/01-Working/PROJECTS/ZAP/Project/ecosystem/ZAP_Ecosystem_Master_Suite_v3.postman_collection.json', (data) => {
    const crm = data.item.find(i => i.name === 'CRM');
    if (!crm) return null;
    const api = crm.item.find(i => i.name === 'api');
    if (!api) return null;
    const v1 = api.item.find(i => i.name === 'v1');
    if (!v1) return null;
    return v1.item.find(i => i.name === 'catalog');
});
