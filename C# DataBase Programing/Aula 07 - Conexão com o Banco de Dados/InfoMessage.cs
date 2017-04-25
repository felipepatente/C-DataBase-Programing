//Como usar o evento InfoMessage

using System;
using System.Data;
using System.Data.SqlCliente;

class InfoMessage{
	
	//Definindo o método InfoMessageHandLer() para manipular o evento InfoMessage
	public static void InfoMessageHandLer(object mySender, SqlInfoMessageEventArgs myEvent){
		Console.WriteLine("The following message was produced:\n " + myEvent.Errors[0]);
	}
	
	public static void Main(){
		//Criando um objeto SqlConnection
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;ui=sa;pwd=sa");
		
		//Monitorar o evento InfoMessage usando o método InfoMessageHandler()
		mySqlConnection.InfoMessage += new SqlInfoMessageEventHandler(InforMessageHandler);
		
		//Abrindo mySqlConnection
		mySqlConnection.Open();
		
		//Criando um objeto SqlComand
		SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		
		//Executar uma instrução PRINT
		mySqlCommand.CommandText = "PRINT 'This is the message from the PRINT statement'";
		mySqlCommand.ExecuteNonQuery();
		
		//Execute uma declaração RAISERROR
		mySqlCommand.CommandText = "RAISERROR('This is the message from the RAISERROR statement',10,1)";
		mySqlCommand.ExecuteNonQuery();
		
		//Fechando mySqlConnection
		mySqlConnection.Close();
		
	}
}