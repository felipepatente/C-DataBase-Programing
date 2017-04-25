// Ilustra o uso de uma transação

using System;
using System.Data;
using System.Data.SqlClient;

class ExecuteTransaction
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection(
			"server=localhost;database=Northwind;uid=sa;pwd=sa"
		);
		
		mySqlConnection.Open();
		
		//Passo 1: criar um objecto SqlTransaction e iniciar a transacção chamando o método 
		//BeginTransaction() do objecto SqlConnection
		SqlTransaction mySqlConnection = mySqlConnection.BeginTransaction();
		
		//Passo 2: criar um objecto SqlCommand para manter uma instrução 
		//SQL SqlCommand.Transaction = mySqlTransaction
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		
		//Etapa 3: definir a propriedade Transaction para o objeto SqlCommand 
		//mySqlCommand.Transaction = mySqlTransaction
		mySqlCommand.Transaction = mySqlTransaction;
		
		
		//Etapa 4: defina a propriedade CommandText do objeto SqlCommand para a primeira instrução INSERT
		mySqlCommand.CommandText = "INSERT INTO Customers (CustomerID, CompanyName) " +
			"VALUES ('J3COM','Jason Price Corporation')";
		
		
		//Etapa 5: executar a primeira instrução INSERT
		Console.WriteLine("Running first INSERT statement");
		
		//Etapa 6: defina a propriedade CommandText do objeto SqlCommand para a segunda instrução INSERT
		mySqlCommand.CommandText = "INSERT INTO Orders (CustomerID) VALUES ('J3COM');";
		
		
		//Etapa 7: executar a segunda instrução INSERT
		Console.WriteLine("Running second INSERT statement");
		mySqlCommand.ExecuteNonQuery();
		
		//Etapa 8: confirmar a transação usando o método Commit () do objeto SqlTransaction
		Console.Write("Commmitting transaction");
		mySqlTransaction.Commit();
		
		mySqlConnection.Close();
		
	}
}