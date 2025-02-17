using LifeCamp.Common;
using LifeCamp.DAL;
using LifeCamp.Models;
using LifeCamp.ViewModel;
using LifeCampBackend.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LifeCampBackend.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly LifeCampDbContext _context;
        private readonly JwtTokenService _generateJwtTokenHelper;

        public AuthAPIController(LifeCampDbContext context)
        {
            _context = context;
            _generateJwtTokenHelper = new JwtTokenService();
        }

        /// <summary>
        /// to add-update Admin 
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("api/Auth/AddUpdateAdmin")]
        public async Task<IActionResult> AddUpdateAdmin([FromBody] AdminLogin userdetail)
        {
            if (userdetail.Id == 0)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.AdminLogins.Add(userdetail);

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.AdminLogins.Update(userdetail);
            }

            await _context.SaveChangesAsync();

            var user = _context.AdminLogins.FirstOrDefault(u => u.Id == userdetail.Id);
            var userDetails = new UserDetail
            {
                UserloginId = user.Id,
                CreatedAt = user.CreatedAt,
                RoleType = 1,
                Description = "",
                PhoneNumber = "",
                ZipCode = "",
                Country = "",
                State = "",
                City = "",
                Address = "",
                UpdatedAt = DateTime.Now,
                DeletedOn = DateTime.MinValue
            };

            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User successfully added." });
        }
        /// <summary>
        /// to add -update user
        /// </summary>
        /// <param name="userdetail"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("api/Auth/AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUser([FromBody] UserLogin userdetail)
        {
            if (userdetail.Id == 0)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.UserLogins.Add(userdetail);
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.UserLogins.Update(userdetail);
            }
            await _context.SaveChangesAsync();
            var user = _context.AdminLogins.FirstOrDefault(u => u.Id == userdetail.Id);
            var userDetails = new UserDetail
            {
                UserloginId = user.Id,
                CreatedAt = user.CreatedAt,
                RoleType = 2,
                Description = "",
                PhoneNumber = "",
                ZipCode = "",
                Country = "",
                State = "",
                City = "",
                Address = "",
                UpdatedAt = DateTime.Now,
                DeletedOn = DateTime.MinValue
            };

            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User successfully added." });
        }

        /// <summary>
        /// to get detail of login user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Auth/LoginDetail")]
        public async Task<IActionResult> LoginDetail([FromBody] LoginDetailModel loginDetailModel)
        {
            if (loginDetailModel == null)
            {
                return BadRequest(new { message = "Invalid request payload." });
            }
            try
            {
                var userLogin = await _context.UserLogins
                    .Where(c => c.Identifier == loginDetailModel.Identifier && c.Password == loginDetailModel.Password)
                    .FirstOrDefaultAsync();


                Response.Cookies.Append(CookieKeyNames.UserCookie, "", new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Path = "/",
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None
                });
                if (userLogin != null)
                {
                    var token = _generateJwtTokenHelper.GenerateToken(userLogin.Id.ToString(), "User");

                    Response.Cookies.Append(CookieKeyNames.UserCookie, token, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        Path = "/",
                        HttpOnly = true,
                        Secure = true, // Set to true if using HTTPS
                        SameSite = SameSiteMode.None
                    });
                    return Ok(new { message = "Login successful (User).", token = token });
                }

                var adminLogin = await _context.AdminLogins
                    .Where(c => c.Identifier == loginDetailModel.Identifier && c.Password == loginDetailModel.Password)
                    .FirstOrDefaultAsync();

                Response.Cookies.Append(CookieKeyNames.AdminCookie, "", new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Path = "/",
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None
                });
                if (adminLogin != null)
                {
                    var token = _generateJwtTokenHelper.GenerateToken(adminLogin.Id.ToString(), "Admin");
                    Response.Cookies.Append(CookieKeyNames.AdminCookie, token, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        Path = "/",
                        HttpOnly = true,
                        Secure = true, // Set to true if using HTTPS
                        SameSite = SameSiteMode.None
                    });
                    return Ok(new { message = "Login successful (Admin).", token = token });
                }

                return BadRequest(new { message = "Invalid credentials. Please check your identifier and password." });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = "An error occurred while retrieving login details.", error = ex.Message });
            }
        }
        /// <summary>
        /// for token validation
        /// </summary>
        /// <param name="loginDetailModel"></param>
        /// <returns></returns>


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/Auth/CheckValidation")]
        public async Task<IActionResult> CheckValidation()
        {
            try
            {
                return Ok(new { status = 200 });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = "An error occurred while retrieving login details.", error = ex.Message });
            }
        }
    }
}
