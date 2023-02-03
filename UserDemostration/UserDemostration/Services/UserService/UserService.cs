using Dapper;
using UserDemostration.Models;
using UserDemostration.Services.UserService.Interface;
using UserDemostration.Tools.Dapper_ORM;

namespace UserDemostration.Services.UserService
{
	public class UserService : IUserService
	{
		private readonly DapperContext _context;
		
		public UserService(DapperContext context)
		{
			_context = context;
		}
		public UserProfile GetUserProfile()
		{
			var query = "Select * from UserProfile";
			return null;
		}
		public async Task<int> InsertUser(UserProfile model)
		{
			var query = "INSERT INTO UserProfile (UserName, Email, Password) VALUES " +
				"('" +
				model.UserName +
				"','" +
				model.Email +
				"','" +
				model.Password +
				"');";

			try
			{
				using (var connection = _context.CreateConnection())
				{
					var result = await connection.ExecuteAsync(query);

					return result;
				}
			}
			catch { throw; }
		}
	}
}
