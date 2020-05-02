using AdkTabber.ViewModels.AuthViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<ActionResult<User>> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return await _userManager.FindByNameAsync(model.Username);
            }
            return BadRequest("Incorrect username or password");
        }



        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<User>> SignUp(RegisterViewModel model)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<User>(model), model.Password);
            if (result.Succeeded)
            {
                return await _userManager.FindByNameAsync(model.Username);
            }
            return BadRequest(string.Join("\n", result.Errors.Select(x=>x.Description)));
        }


        [HttpGet]
        [Route("current")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            try
            {
                var result = await _userManager.GetUserAsync(HttpContext.User);
                return result;
            }
            catch
            {
                return BadRequest("Cannot get current user");
            }                     
        }

        public async Task<ActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
