/*Este exemplo demonstra como chamar um procedimento armazenado do SQL Server no banco de dados de 
exemplo Northwind. O nome do procedimento armazenado é dbo.SalesByCategory e tem um parâmetro de entrada 
chamado @CategoryName com um tipo de dados de nvarchar(15). O código cria um novo SqlConnection dentro de 
um bloco using para que a conexão seja descartada quando o procedimento terminar. Os objetos SqlCommand e 
SqlParameter são criados e suas propriedades são definidas. Um SqlDataReader executa o SqlCommand e 
retorna o conjunto de resultados do procedimento armazenado, exibindo a saída na janela do console.*/

static void GetSalesByCategory(string connectionString, 
    string categoryName)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // Create the command and set its properties.
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SalesByCategory";
        command.CommandType = CommandType.StoredProcedure;

        // Add the input parameter and set its properties.
        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@CategoryName";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = categoryName;

        // Add the parameter to the Parameters collection. 
        command.Parameters.Add(parameter);

        // Open the connection and execute the reader.
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
        reader.Close();
    }
}