resource "azurerm_sql_table" "milestones" {
  name               = "Milestones"
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
    name    = "Milestone"
    type    = "nvarchar(max)"
    nullable = false
  }

  column {
    name    = "BabyDevForecastId"
    type    = "int"
    nullable = false
  }
}
