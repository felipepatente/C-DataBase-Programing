/* Como chamar o SQL Server Procedimento armazenado AddProduct3 */

using System;
using System.Data;
using System.Data.SqlClient

class ExecuteAddProduct3
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
		mySqlConnection.Open();
		
		/*
		Etapa 1: criar um objeto de comando e definir sua propriedade CommandText para uma instrução EXECUTE 
		contendo a chamada de procedimento armazenado
		*/
		
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		mySqlCommand.CommandText = 
		"EXECUTE @MyProductID = AddProduct3 @MyProductName, " +
		"@MySupplierID, @MyCategoryID, @MyQuantityPerUnit, " +
		"@MyUnitPrice, @MyUnitsInStock, @MyUnitsOnOrder, " +
		"@MyReorderLevel, @MyDiscontinued";
		
		
		//Etapa 2: Adicione os parâmetros necessários ao objeto Command
		mySqlCommand.Parameters.Add("@MyProductID",SqlDbType.Int);
		mySqlCommand.Parameters["@MyProductID"].Direction = ParameterDirection.Output;
		mySqlCommand.Parameters.Add("@MyProductName", SqlDbType.NVarchar, 40).Value = "Widget";
		mySqlCommand.Parameters.Add("@MySupplierID", SqlDbType.Int).Value = 1;
		mySqlCommand.Parameters.Add("@MyCategoryID", SqlDbType.Int).Value = 1;
		mySqlCommand.Parameters.Add("@MyQuantityPerUnit", SqlDbType.NVarchar, 20).Value = "1 per box";
		mySqlCommand.Parameters.Add("@MyUnitPrice", SqlDbType.Money).Value = 5.99;
		mySqlCommand.Parameters.Add("@MyUnitsInStock", SqlDbType.SmallInt).Value = 10;
		mySqlCommand.Parameters.Add("@MyUnitsOnOrder", SqlDbType.SmallInt).Value = 5;
		mySqlCommand.Parameters.Add("@MyReorderLevel", SqlDbType.SmallInt).Value = 5;
		mySqlCommand.Parameters.Add("@MyDiscontinued", SqlDbType.Bit).Value = 1;
		
		
		//Etapa 3: executar o objeto Command usando o método ExecuteReader()
		SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
		
		
		//Etapa 4: ler as linhas usando o objeto DataReader
		while()
		{
			Console.WriteLine("mySqlDataReader[\"ProductName\"] = " +
			mySqlDataReader(["ProductName"]);
			Console.WriteLine("mySqlDataReader[\"UnitPrice\"] = " +
			mySqlDataReader(["UnitPrice"]);
		}	
		
		//Etapa 5: fechar o objeto DataReader
		mySqlDataReader.Close();
		
		//Passo 6: ler o valor do parâmetro de saída
		Console.WriteLine("New ProductID = " + mySqlCommand.Parameters["@MyProductID"].Value);
		
		
		mySqlConnection.Close();
				
	}
}
