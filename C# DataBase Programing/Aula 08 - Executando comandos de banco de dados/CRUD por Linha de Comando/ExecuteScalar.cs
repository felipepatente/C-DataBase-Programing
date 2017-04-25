// Como usar o método ExecuteScalar () para executar uma instrução SELECT que retorna um único valor

using System;
using System.Data;
using System.Data.SqlClient;

class ExecuteScalar
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection(
			"server=localhost;database=Northwind;uid=sa;pwd=sa"
		);
		
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		mySqlCommand.CommandText = "SELECT COUNT(*) FROM Products";
		mySqlConnection.Open();
		
		//Chamar o método ExecuteScalar () do objeto SqlCommand para executar a instrução SELECT
		int returnValue = (int) mySqlCommand.ExecuteScalar();
		Console.WriteLine("mySqlCommand.ExecuteScalar() = " + returnValue);
		
		mySqlConnection.Close();
	}
}