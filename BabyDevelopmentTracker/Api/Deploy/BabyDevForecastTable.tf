resource "azurerm_sql_table" "baby_dev_forecast" {
  name               = "BabyDevForecast"
  schema             = "dbo"
  resource_group_name = azurerm_resource_group.example.name
  server_name        = azurerm_sql_server.example.name
  database_name      = azurerm_sql_database.example.name

  column {
    name    = "Id"
    type    = "int"
    nullable = false
    identity = {
      increment = 1
      column_name = "Id"
      seed_value = 1
    }
  }

  column {
    name    = "Name"
    type    = "nvarchar(max)"
    nullable = false
  }

  column {
    name    = "AgeRangeStart"
    type    = "int"
    nullable = false
  }

  column {
    name    = "AgeRangeEnd"
    type    = "int"
    nullable = false
  }

  column {
    name    = "Description"
    type    = "nvarchar(max)"
    nullable = false
  }
}