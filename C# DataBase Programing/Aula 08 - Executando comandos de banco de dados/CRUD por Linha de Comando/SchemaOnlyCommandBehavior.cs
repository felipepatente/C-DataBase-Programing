/* Como ler um esquema de tabela */

using System;
using System.Data;
using System.Data.SqlClient;

class SchemaOnlyCommandBehavior
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Nortwind;uid=sa;pwd=sa");
		SqlCommand.CommandText = "SELECT ProductID, ProductName, UnitPrice  FROM Products WHERE ProductID = 1";
		mySqlConnection.Open();
		
		//Passe a constante CommandBehavior.SchemaOnly para o método ExecuteReader() para obter o esquema
		SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
		
		//Leia o DataTable contendo o esquema do DataReader
		DataTable myDataTable = productsSqlDataReader.GetSchemaTable();

		//Exibir as linhas e colunas no DataTable
		foreach(DataRow myDataRow in myDataTable.Rows)
		{
			Console.WriteLine("\nNew column details follow:");
			foreach(DataColumn myDataColumn in myDataTable.Columns)
			{
				Console.WriteLine(myDataColumn + " = " + myDataRow[myDataColumn]);
				if(myDataColumn.ToString() == "ProviderType")
				{
					Console.WriteLine(myDataColumn + " = " 
					+ ((System.Data.SqlDbType) myDataRow[myDataColumn]);
				}
			}	
		}
		productsSqlDataReader.Close();
		mySqlConnection.Close();
	}
}