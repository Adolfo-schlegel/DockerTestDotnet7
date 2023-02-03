using UserDemostration.Models;

namespace UserDemostration.Services.UserService.Interface
{
	public interface IUserService
	{
		public UserProfile GetUserProfile();
		public Task<int> InsertUser(UserProfile model);
	}
}
