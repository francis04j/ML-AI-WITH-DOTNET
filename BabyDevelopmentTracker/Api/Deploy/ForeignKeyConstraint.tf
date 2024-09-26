resource "azurerm_sql_index" "milestones_fk" {
  name               = "FK_Milestones_BabyDevForecast"
  schema             = "dbo"
  resource_group_name = azurerm_resource_group.example.name
  server_name        = azurerm_sql_server.example.name
  database_name      = azurerm_sql_database.example.name
  table_name        = "Milestones"
  index_type        = "unique"
  columns           = ["BabyDevForecastId"]
  online             = true

  index_column {
    name   = "BabyDevForecastId"
    order  = "ASC"
  }

  foreign_key {
    name                 = "FK_Milestones_BabyDevForecast"
    referenced_schema    = "dbo"
    referenced_table     = "BabyDevForecast"
    referenced_columns   = ["Id"]
    delete_rule         = "CASCADE"
    update_rule         = "CASCADE"
  }
}