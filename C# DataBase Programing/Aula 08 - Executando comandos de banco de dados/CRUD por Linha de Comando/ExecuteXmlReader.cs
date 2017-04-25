// Como usar o método ExecuteXmlReader() para executar uma instrução SELECT que retorna XML

using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

class ExecuteXmlReader
{
	public static void Main()
	{
		SqlConnection mySqlConnection = new SqlConnection(
			"server=localhost;database=Northwind;uid=sa;pwd=sa"
		);
		
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		
		//Defina a propriedade CommandText do objeto SqlCommand para uma instrução SELECT que recupera XML
		mySqlCommand.CommandText = "SELECT TOP 5 ProductID, ProductName, UnitPrice " +
									"FROM Products " + 
									"ORDER BY ProductID " +
									"FOR XML AUTO";
									
		mySqlConnection.Open();
		
		//Criar um objeto SqlDataReader e chamar o método ExecuteReader () do objeto SqlCommand para executar 
		//a instrução SELECT
		XmlReader myXmlReader = mySqlCommand.ExecuteXmlReader();
		
		//Leia as linhas do objeto XmlReader usando o método Read()
		myXmlReader.Read();
		while(!myXmlReader.EOF)
		{
			Console.WriteLine(myXmlReader.ReadOuterXml());
		}
		
		myXmlReader.Close();
		mySqlConnection.Close();
		
	}
}
