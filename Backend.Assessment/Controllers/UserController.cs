using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Application.Repositories;
using Backend.Assessment.Controllers;
using Backend.Assessment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Assessment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        /// <summary>
        /// Inject Logger 
        /// Inject User Service 
        /// </summary>
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Api for get all Users in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<User>> GetUsers()
        {
            _logger.LogInformation("Access Get All Users");
            var allUsers = _userService.GetAllUsersAlphabetized();
            return allUsers;
        }
        /// <summary>
        /// Add Random User Names
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRandomNames")]
        public IActionResult AddRandomNames()
        {
            _logger.LogInformation("Access add random names");
            return _userService.CreateRandomNames();
        }
        /// <summary>
        /// Get String Alphabetized
        /// </summary>
        /// <param name="name">get name as parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetNameAlphabetically")]
        public ActionResult<string> GetNameAlphabetically(string name)
        {
            _logger.LogInformation("Access Get Name Alphabetically");
            return _userService.GetUserNameAlphabetized(name);
        }
    }
}
