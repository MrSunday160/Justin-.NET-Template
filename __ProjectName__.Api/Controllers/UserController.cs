using __ProjectName__.DataAccess.Services;
using __ProjectName__.Domain.Models;
using Justin.EntityFramework.Controller;
using Justin.EntityFramework.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace __ProjectName__.Api.Controllers {

    [ApiController]
    [AllowAnonymous]
    [Route("/api/[controller]")]
    public class UserController : BaseController<User> {

        private readonly IUserService _userService;
        public UserController(IUserService userService) : base(userService) {
            _userService = userService;
        }

        public override async Task<IActionResult> Get() {
            return Ok(new string("Hello World!"));
        }

    }
}
