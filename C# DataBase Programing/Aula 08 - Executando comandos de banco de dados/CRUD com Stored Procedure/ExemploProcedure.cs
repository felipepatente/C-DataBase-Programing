public List<SMS> GetSMSProcessarRetorno()
{
	
	List<SMS> sms = List<SMS>();
	
	using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoCognizant"].ConnectionString))
	{
		
		using(var Command = new SqlCommand("GetSMS", Connection))
		{
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.AddWithValue("@Bloqueio", 0);
			
			Connection.Open();
			SqlDataReader dataReader = Command.ExecuteReader();
			
			while(dataReader.Read())
			{
				sms.Add(new SMS()
				{
					Telefone = dataReader["Telefone"].ToString(),
				});
			}			
		}
	}
	
	return sms;
	
}