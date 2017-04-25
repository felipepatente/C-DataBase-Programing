//Como usar o evento StateChange

using System;
using System.Data;
using System.Data.SqlCliente;

class StateChange
{
	//Defina o método StateChangeHandler () para manipular o evento StateChange
	public static void StateChangeHandler(object mySender, StateChangeEventArgs myEvent){
		Console.WriteLine(
			"mySqlConnection State has changed from " +
			 myEvent.OriginalState + " to " + myEvent.CurrentState 
		);
	}
	
	public static void Main(){
		
		//Criando um objeto SqlConnection
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
		
		//Monitorar o evento StateChange usando o método StateChangeHandler()
		mySqlConnection.StateChange += new StateChangeEventHandler(StateChangeHandler);
		
		//Abre mySqlConnection, fazendo com que o Estado altere a forma fechada para abrir
		Console.WriteLine("Calling mySqlConnection.Open()");
		mySqlConnection.Open();
		
		//fecha mySqlConnection, fazendo com que o Estado altere a forma aberta para fechada
		Console.WriteLine("Calling mySqlConnection.Close()");
		mySqlConnection.Close();
		
	}
}