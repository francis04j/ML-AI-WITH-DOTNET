# Configure Azure provider
provider "azurerm" {
  features {}
}

# Create a resource group
resource "azurerm_resource_group" "api_rg" {
  name     = "api-rg"
  location = "eastus" # Replace with your desired region
}

# Create an Azure Cosmos DB account
resource "azurerm_cosmosdb_account" "cosmosdb_account" {
  name                = "mycosmosdb"
  resource_group_name = azurerm_resource_group.api_rg.name
  location            = azurerm_resource_group.api_rg.location
  kind                = "Global"
  consistency_policy  = {
    type                   = "Strong"
  }
  location_config = {
    locations = [
      {
        id       = "eastus"
        failover = "Primary"
      },
      {
        id       = "westus"
        failover = "Secondary"
      }
    ]
  }
}

# Create an Azure App Service plan
resource "azurerm_app_service_plan" "app_service_plan" {
  name                 = "api-app-service-plan"
  resource_group_name  = azurerm_resource_group.api_rg.name
  location             = azurerm_resource_group.api_rg.location
  sku_name             = "B1" # Replace with desired SKU
  reserved_instance_type = "Basic_B1"
}

# Create an Azure App Service (API)
resource "azurerm_app_service" "api" {
  name                 = "myapi"
  resource_group_name  = azurerm_resource_group.api_rg.name
  location             = azurerm_resource_group.api_rg.location
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  runtime_version      = "dotnet-7" # Replace with your desired .NET version
}