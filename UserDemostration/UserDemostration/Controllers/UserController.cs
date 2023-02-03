using Microsoft.AspNetCore.Mvc;
using UserDemostration.Models;
using UserDemostration.Services.UserService.Interface;

namespace UserDemostration.Controllers
{
	[Route("api/User")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserService _userService;
		public UserController(IUserService userService) {			
			_userService = userService;
		}

		[HttpPost(Name = "Insert new User")]
		public async Task<IActionResult> SetUserProfile(UserProfile userProfile)
		{
			Reply oReply = new() { message = "OK"};
			
			try
			{
				oReply.result = await _userService.InsertUser(userProfile);

				if (oReply.result != 0)
					return StatusCode(200, oReply);
				else
				{
					oReply.message = "the database return 0";
					return StatusCode(500, oReply);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500 , ex.Message);
			}			
		}
		
	}
}
