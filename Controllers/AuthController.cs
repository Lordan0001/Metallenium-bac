using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metall_Fest.models;
using Microsoft.CodeAnalysis.Scripting;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Metall_Fest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(MainContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'MainContext.users' is null.");
            }

            var alredyExistingEmail = await _context.users.FirstOrDefaultAsync(u => u.email == user.email);
            if (alredyExistingEmail != null)
            {
                return Problem("User with this email already exist!");

            }
 
            CreatePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);

            user.role = "user";
            user.password = "pass";
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            user.money = 0;
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("getMe"),Authorize]
        public ActionResult<object> GetMe()
        {
            var userName = User?.Identity?.Name;
            var email = User.FindFirstValue(ClaimTypes.Email);
            var role  = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new {userName,email,role});
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.email == user.email);

            if (existingUser == null)
            {
                return BadRequest("no user with this email");

            }
            if(!VerifyPasswordHash(user.password, existingUser.passwordHash, existingUser.passwordSalt))
            {
                return BadRequest("Wrong password");
            }



            string token = CreateToken(existingUser);

            var response = new
            {
                Token = token,
                User = existingUser
            };

            return Ok(response);
        }
        private string CreateToken(User user) {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.role),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyPasswordHash(string reqPassword, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {
            using (var hmac = new HMACSHA512(storedPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(reqPassword));
                return computedHash.SequenceEqual(storedPasswordHash);
            }

        }
    }
}
