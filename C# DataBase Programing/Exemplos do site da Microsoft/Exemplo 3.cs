/*Obtendo informações de esquema do DataReader
Enquanto o DataReader estiver aberto, você poderá recuperar informações de esquema sobre o conjunto de 
resultados atual usando o método GetSchemaTable.GetSchemaTable retorna um objeto DataTable populado com 
linhas e colunas que contêm informações de esquema do conjunto de resultados atual.DataTable contém uma 
linha para cada coluna do conjunto de resultados. Cada coluna da linha da tabela de esquema é mapeada 
para uma propriedade da coluna retornada no conjunto de resultados, onde ColumnName é o nome da 
propriedade e o valor da coluna é o valor da propriedade. O exemplo de código a seguir gravará as 
informações de esquema para DataReader.*/

static void GetSchemaInfo(SqlConnection connection)
{
    using (connection)
    {
        SqlCommand command = new SqlCommand(
          "SELECT CategoryID, CategoryName FROM Categories;",
          connection);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();
        DataTable schemaTable = reader.GetSchemaTable();

        foreach (DataRow row in schemaTable.Rows)
        {
            foreach (DataColumn column in schemaTable.Columns)
            {
                Console.WriteLine(String.Format("{0} = {1}",
                   column.ColumnName, row[column]));
            }
        }
    }
}