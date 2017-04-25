using System;
using System.Data;
using System.Data.SqlClient;

class ConnectionPooling
{
	public static void main(){
		
		//Criando um objeto SqlConnection para se conectar ao banco de dados, definindo tamanho máximo de pool 
		//para 10 e tamanho de pool de min para 5
		SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa;"
		 + "max pool size=10; min pool size=5");
		 
		//Abrindo o objeto SqlConnection 10 vezes
		for(int count = 1; count <= 10; count++){
			Console.WriteLine("Count = " + count);
			
			//Criar um objeto DateTime e defini-lo para a data e hora atuais
			DateTime start = DateTime.Now;
			
			//Abrindo a conexão de banco de dados usando o método open() do objeto SqlConnection
			mySqlConnection.Open();
			
			//Subtraia a data e hora atuais desde o início armazenando a diferença em um TimeSpan
			TimeSpan timeTaken = DateTime.Now - start;
			
			//Exibir o número de milissegundos recebidos para abrir a conexão
			Console.WriteLine("Milliseconds = " + timeTaken.Milliseconds);
			
			//Exibir o estado da conexão
			Console.WriteLine("mySqlConnection.State = " + mySqlConnection.State);
			
			//Fechando a conexão de banco de dados usando o método Close () do objeto SqlConnection
			mySqlConnection.Close();
			
			/*
				//Para verificar se uma conexão estar fechada
				if(mySqlConnection.State == ConnectionState.Closed){
					mySqlConnection.Open();
				}
			*/
		}
	}
}
