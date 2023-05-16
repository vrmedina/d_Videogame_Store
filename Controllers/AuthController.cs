using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d_Videogame_Store.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginRequestDTO request)
        {
            var response = await _authRepository.Login(
                request.Username, 
                request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterRequestDTO request)
        {
            var response = await _authRepository.Register(
                new User { Username = request.Username }, 
                request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}