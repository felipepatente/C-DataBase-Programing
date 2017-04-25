// Como usar o método ExecuteNonQuery() para executar instruções DDL

using System;
using system.Data;
using System.Data.SqlClient;

class ExecuteDDL
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection(
			"server=localhost;database=Northwind;uid=sa;pwd=sa"
		); 
		
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		
		//Defina a propriedade CommandText do objeto SqlCommand para uma instrução CREATE TABLE
		mySqlCommand.CommandText = 
			"CREATE TABLE myPersons (" + ;
			"PersonId INT CONSTRAINT PK_Persons PRIMARY KEY, " +
			"FirstName NVARCHAR(15) NOT NULL, " + 
			"LastName NVARCHAR(15) NOT NULL, " + 
			"DateOfBirth DATETIME "
			")";
		
		mySqlConnection.Open();
		
		//Chamar o método ExecuteNonQuery () do objeto SqlCommand para executar a instrução CREATE TABLE
		Console.WriteLine("Creating MyPersons table");
		int result = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("mySqlCommand.ExecuteNonQuery() = " + result);
		
		//Defina a propriedade CommandText do objeto SqlCommand para uma instrução ALTER TABLE
		mySqlCommand.CommandText = "ALTER TABLE MyPersons " +
			"ADD EmployerID NCHAR(5) CONSTRAINT FK_Persons_Customers " +
			"REFERENCES Customers(CustomerID)";
		
		//Chamar o método ExecuteNonQuery() do objeto SqlCommand para executar a instrução ALTER TABLE
		Console.WriteLine("Altering MyPersons table");
		result = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("mySqlCommand.ExecuteNonQuery() = " + result);
		
		//Defina a propriedade CommandText do objeto SqlCommand para executar a instrução DROP TABLE
		mySqlCommand.CommandText = "DROP TABLE myPersons";
		
		//Chamar o método ExecuteNonQuery() do objeto SqlCommand para executar a instrução DROP TABLE
		Console.WriteLine("Dropping MyPersons table");
		
		result = mySqlCommand.ExecuteNonQuery();
		Console.WriteLine("mySqlCommand.ExecuteNonQuery() = " + result);
		
		mySqlConnection.Close();
		
		
	}
}