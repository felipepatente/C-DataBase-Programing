//Como usar o método ExecuteNonQuery () para executar instrução INSERT, UPDATE e DELETE

using System;
using System.Data;
using System.Data.SqlClient;

class ExecuteInsertUpdateDelete
{
	public static void DisplayRow(SqlCommand mySqlCommand, string CustomerID)
	{
		mySqlCommand.CommandText = 
			"SELECT CustomerID, CompanyName" +
			"FROM Customers " + 
			"WHERE CustomerID = '" + CustomerID + "'";
			
			SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
			while()
			{
				Console.WriteLine("mySqlDataReader[\"CustomerID\"] = " + mySqlDataReader["CustomerID"]);
				Console.WriteLine("mySqlDataReader[\"CompanyName\"] = " + mySqlDataReader["CompanyName"]);
			}
			
			mySqlDataReader.Close();
	}
	
	
	public static void Main()
	{
		SqlConnection mySqlConnection  = new SqlConnection(
			"server=localhost;database=Northwind;uid=sa;pwd=sa"
		);
		
		//Criar um objeto SqlCommand e definir sua propriedade Commandtext para uma instrução INSERT
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		mySqlCommand.CommandText = 
		"INSERT INTO Customers (CustomerID, CompanyName) VALUES ('J2COM','Jason Price Corporation');";
		
		mySqlConnection.Open();
		
		//Chamar o método ExecuteNonQuery do objeto SqlCommand para executar a instrução INSERT
		int numberOfRows = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("Number of rows added = " + numberOfRows);
		DisplayRow(mySqlCommand,"J2COM");
		
		//Defina a propriedade CommandText do objeto SqlCommand para uma instrução UPDATE
		mySqlCommand.CommandText = 
			"UPDATE Customers SET CompanyName = 'New Company' WHERE CustomerID = 'J2COM'";
			
		//Chamar o método ExecuteNonQuery() do objeto SqlCommand para executar a instrução UPDATE
		numberOfRows = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("Number of rows updated = " + numberOfRows);
		DisplayRow(mySqlCommand,"J2COM");
		
		
		//Defina a propriedade CommandText do objeto SqlCommand para executar a instrução DELETE
		mySqlCommand.CommandText = "DELETE FROM Customers WHERE CustomerID = 'J2COM'";
		
		
		//Chamar o método ExecuteNonQuery() do objeto SqlCommand para executar a instrução DELETE
		numberOfRows = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("Number of rows deleted = " + numberOfRows);
		
		mySqlConnection.Close();
		
	}
	
}
