/* Como controlar o comportamento do comando para retornar uma única linha */

using System;
using System.Data;
using System.Data.SqlClient;

class SingleRowCommandBehavior
{
	SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Nortwind;uid=sa;pwd=sa");
	
	SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
	mySqlCommand.CommandText = "SELECT ProductID, ProductName, QuantityPerUnit,UnitPrice" + "FROM Products";
	
	mySqlConnection.Open();
	
	//Passar o valor CommandBehavior.SingleRow para o método ExecuteReader (), indicando que o objeto 
	//Command retorna apenas uma única linha
	SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SingleRow);
	
	while(mySqlDataReader.Read())
	{
		Console.WriteLine("mySqlDataReader[\"ProductID\"] = " + mySqlDataReader["ProductID"]);
		Console.WriteLine("mySqlDataReader[\"ProductName\"] = " + mySqlDataReader["ProductName"]);
		Console.WriteLine("mySqlDataReader[\"QuantityPerUnit\"] = " + mySqlDataReader["QuantityPerUnit"]);
		Console.WriteLine("mySqlDataReader[\"UnitPrice\"] = " + mySqlDataReader["UnitPrice"]);
	}
	
	mySqlDataReader.Close();
	mySqlConnection.Close();
}