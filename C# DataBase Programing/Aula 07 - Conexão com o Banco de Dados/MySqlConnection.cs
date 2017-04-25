/*
MySqlConnection.cs ilustra como usar um objeto SqlConnection para se conectar a um banco de dados 
SQL Server
*/

using System;
using System.Data;
using System.Data.SqlClient;

class MySqlConnection
{
	public static void Main()
	{
		//Formulando uma string contendo os detalhes da conexão do banco de dados
		string connectionString = "server=localhost;database=Nortwind;uid=sa;pwd=sa";
		
		//Criando um objeto SqlConnection para se conectar ao banco de dados, passando uma string 
		//de conexão para o construtor
		SqlConnection mySqlConnection = new SqlConnection(connectionString);
		
		//Abrindo a conexão de banco de dados usando o método open() do objeto SqlConnection
		mySqlConnection.Open();
		
		//Exibindo as propriedades do objeto SqlConnection
		Console.Write("mySqlConnection.ConnectionString = " + mySqlConnection.ConnectionString);
		Console.Write("mySqlConnection.ConnectionTimeout " + mySqlConnection.ConnectionTimeout);
		Console.Write("mySqlConnection.Database = " + mySqlConnection.Database);
		Console.Write("mySqlConnection.DataSource " + mySqlConnection.DataSource);
		Console.Write("mySqlConnection.PacketSize = " + mySqlConnection.PacketSize);
		Console.Write("mySqlConnection.ServerVersion = " + mySqlConnection.ServerVersion);
		Console.Write("mySqlConnection.State = " + mySqlConnection.State);
		Console.Write("mySqlConnection.WorkstationId = " + mySqlConnection.WorkstationId);
		
		//Fechando a conexão de banco de dados usando o método Close () do objeto SqlConnection
		mySqlConnection.Close();
	
	}
		
}