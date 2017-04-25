/*Como chamar o SQL Server AddProduct() procedimento armazenado */

using System;
using System.Data;
using System.Data.SqlClient;


class ExecuteAddProduct
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
		
		mySqlConnection.Open();
		
		//Etapa 1: criar um objeto de comando e definir sua propriedade CommandText para uma instrução 
		//EXECUTE contendo a chamada de procedimento armazenado
		
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		mySqlCommand.CommandText = 
		"EXECUTE AddProduct @MyProductID OUTPUT, @MyProductName, " +
		"@MySupplierID, @MyCategoryID, @MyQuantityPerUnit, " +
		"@MyUnitPrice, @MyUnitsInStock, @MyUnitsOnOrder,  " +
		"@MyReorderLevel, @MyDiscontinued";


		//Etapa 2: adicionar os parâmetros necessários para o objeto Command
		mySqlCommand.Parametres.Add("@MyProductID", SqlDbType.Int);
		mySqlCommand.Parametres["@MyProductID"].Direction = ParameterDirection.Output;
		mySqlCommand.Parametres.Add("@MyProductName",SqlDbType.NVarchar,40).Value = "Widget";
		mySqlCommand.Parametres.Add("@MySupplierID",SqlDbType.Int).Value = 1;
		mySqlCommand.Parametres.Add("@MyCategoryID",SqlDbType.Int).Value = 1;
		mySqlCommand.Parametres.Add("@MyQuantityPerUnit",SqlDbType.NVarchar,20).Value = "1 per box";
		mySqlCommand.Parametres.Add("@MyUnitPrice",SqlDbType.Money).Value = 5.99;
		mySqlCommand.Parametres.Add("@MyUnitsInStock",SqlDbType.SmallInt).Value = 10;
		mySqlCommand.Parametres.Add("@MyUnitsOnOrder",SqlDbType.SmallInt).Value = 5;
		mySqlCommand.Parametres.Add("@MyDiscontinued",SqlDbType.SmallInt).Value = 5;
		mySqlCommand.Parametres.Add("@MyDiscontinued",SqlDbType.Bit).Value = 1;
		
		//Etapa 3: executar o objeto Command usando o método ExecuteNonQuery()
		mySqlCommand.ExecuteNonQuery();
		
		//Passo 4: ler o valor do parâmetro de saída
		Console.WriteLine("New ProductID = " + mySqlCommand.Parametres["@MyProductID"].Value);
		
		mySqlConnection.Close();
	}
}