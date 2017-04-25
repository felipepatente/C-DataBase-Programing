/* Como executar um comando TableDirect */

using System;
using System.Data;
using System.Data.OleDb;

class ExecuteTableDirect
{
	public static void void Main()
	{
		OleDbConnection myOleDbConnection = 
		new OleDbConnection("Provider=SQLOLEDB;server=localhost;database=Northwind; uid=sa;pwd=sa");
		OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
		
		//Defina a propriedade CommandType do objeto OleDbCommand para TableDirect
		myOleDbCommand.CommandType = CommandType.TableDirect;
		
		//Defina a propriedade CommandText do objeto OleDbCommand para o nome da tabela para recuperar
		myOleDbCommand.CommandText = "Products";
		
		myOleDbConnection.Open();
		
		OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();
		
		//Apenas ler as primeiras 5 linhas do objeto OleDbDataReader
		for(int count = 1; count <= 5; count++)
		{
			myOleDbDataReader.Read();
			Console.WriteLine("myOleDbDataReader[\"ProductID\"] = " + myOleDbDataReader["ProductID"]);
			Console.WriteLine("myOleDbDataReader[\"ProductName\"] = " + myOleDbDataReader["ProductName"]);
			Console.WriteLine("myOleDbDataReader[\"QuantityPerUnit\"] = " + myOleDbDataReader["QuantityPerUnit"]);
			Console.WriteLine("myOleDbDataReader[\"UnitPrice\"] = " + myOleDbDataReader["UnitPrice"]);
		}
		
		myOleDbDataReader.Close();
		myOleDbConnection.Close();
	}
}