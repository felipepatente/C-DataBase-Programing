/*Recuperando vários conjuntos de resultados usando NextResult
Se vários conjuntos de resultados forem retornados, DataReader fornecerá o método NextResult para iterar 
nos conjuntos de resultados em ordem. O exemplo a seguir mostra SqlDataReader processando os resultados 
de duas instruções SELECT usando o método ExecuteReader.*/

static void RetrieveMultipleResults(SqlConnection connection)
{
    using (connection)
    {
        SqlCommand command = new SqlCommand(
          "SELECT CategoryID, CategoryName FROM dbo.Categories;" +
          "SELECT EmployeeID, LastName FROM dbo.Employees",
          connection);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.HasRows)
        {
            Console.WriteLine("\t{0}\t{1}", reader.GetName(0),
                reader.GetName(1));

            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                    reader.GetString(1));
            }
            reader.NextResult();
        }
    }
}