using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskHandler.Services.Contracts;
using TaskHandler.Roles;


namespace TaskHandler.Controllers
{
    
    public class UserManageController : Controller
    {
        private readonly IUserService _userService;
        public UserManageController(IUserService userService)
        {
                _userService = userService;
        }

         [Authorize(Roles = Roles.Roles.Role_Admin)]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
