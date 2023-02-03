using MySql.Data.MySqlClient;
using System.Data;

namespace UserDemostration.Tools.Dapper_ORM
{
	public class DapperContext 
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("MysqlConnection");
		}
		public IDbConnection CreateConnection()
			=> new MySqlConnection(_connectionString);
	}
}
