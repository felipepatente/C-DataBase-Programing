/* Como executar uma instrução SELECT usando objeto SqlCommand */

using System;
using System.Data;
using System.Data.SqlClient;

class ExecuteSelect
{
	public static void Main()
	{
		//Criar um objeto SqlConnection para se conectar ao banco de dados
		SqlConnection mySqlConnection  = new SqlConnection("server=localhost;database=Northwind;uidi=sa;pwd=sa");
		
		//Criar um objeto SqlCommand
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		
		//Defina a propriedade Command do objeto SqlCommand para a instrução SELECT
		mySqlCommand.CommandText = "SELECT TOP 5 CustomerID, CompanyName, CompanyName, ContactName, Address"
		+ "ORDER BY CustomerID";
		
		//Abra a conexão de banco de dados usando o método Open() do objeto SqlConnection
		mySqlConnection.Open();
		
		//Criar um objeto SqlDataReader e chamar o método ExecuteReader() do objeto SqlCommand para 
		//executar a instrução SQL SELECT
		SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
		
		//Leia as linhas a partir do objeto SqlDataReader usando o método Read()
		while(mySqlDataReader.Read())
		{
			Console.WriteLine("mySqlDataReader[\"CustomerID\"] = " + mySqlDataReader["CustomerID"]);
			Console.WriteLine("mySqlDataReader[\"CompanyName\"] = " + mySqlDataReader["CompanyName"]);
			Console.WriteLine("mySqlDataReader[\"ContactName\"] = " + mySqlDataReader["ContactName"]);
			Console.WriteLine("mySqlDataReader[\"Address\"] = " + mySqlDataReader["Address"]);			
		}
		
		//Feche o objeto SqlDataReader usando o método Close()
		mySqlDataReader.Close();
		
		//Feche o objeto SqlConnection usando o método Close()
		mySqlConnection.Close();
		
		
		
		
	}	
}