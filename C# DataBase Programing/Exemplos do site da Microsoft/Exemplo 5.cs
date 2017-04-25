/*Usando parâmetros com um OleDbCommand ou um OdbcCommand
Ao usar parâmetros com um OleDbCommand ou OdbcCommand, a ordem dos parâmetros adicionados à coleção de 
Parameters deve coincidir com a ordem dos parâmetros definidos no procedimento armazenado. O Provedor de 
Dados do .NET Framework para OLE DB e o provedor de dados do .NET Framework para ODBC lidam com parâmetros
em um procedimento armazenado como espaços reservados e aplicam valores de parâmetro na ordem. Além disso,
os parâmetros do valor de retorno devem ser os primeiros parâmetros adicionados à coleção de Parameters.
 
O provedor de dados do .NET Framework para OLE DB e o provedor de dados do .NET Framework para ODBC não 
oferecem suporte aos parâmetros nomeados para passar parâmetros para uma instrução SQL ou procedimento 
armazenado. Nesse caso, você deverá usar o espaço reservado de ponto de interrogação (?), como no exemplo 
a seguir.*/

/*
SELECT * FROM Customers WHERE CustomerID = ?
Como resultado, a ordem na qual os objetos Parameter são adicionados à coleção de Parameters deve 
corresponder diretamente à posição do espaço reservado do ? para o parâmetro.
*/


OleDbCommand command = new OleDbCommand("SampleProc", connection);
command.CommandType = CommandType.StoredProcedure;

OleDbParameter parameter = command.Parameters.Add(
  "RETURN_VALUE", OleDbType.Integer);
parameter.Direction = ParameterDirection.ReturnValue;

parameter = command.Parameters.Add(
  "@InputParm", OleDbType.VarChar, 12);
parameter.Value = "Sample Value";

parameter = command.Parameters.Add(
  "@OutputParm", OleDbType.VarChar, 28);
parameter.Direction = ParameterDirection.Output;







//Exemplo do ODBC

OdbcCommand command = new OdbcCommand( _
  "{ ? = CALL SampleProc(?, ?) }", connection);
command.CommandType = CommandType.StoredProcedure;

OdbcParameter parameter = command.Parameters.Add( _
  "RETURN_VALUE", OdbcType.Int);
parameter.Direction = ParameterDirection.ReturnValue;

parameter = command.Parameters.Add( _
  "@InputParm", OdbcType.VarChar, 12);
parameter.Value = "Sample Value";

parameter = command.Parameters.Add( _
  "@OutputParm", OdbcType.VarChar, 28);
parameter.Direction = ParameterDirection.Output;