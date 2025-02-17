using LifeCamp.DAL;
using LifeCamp.Models;
using LifeCamp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Resources;
using System.Security.Claims;

namespace LifeCamp.WebAPI
{
    [ApiController]
    public class CampAPIController : ControllerBase
    {

        private readonly LifeCampDbContext _context;

        public CampAPIController(LifeCampDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// to add-update CampDetails 
        /// </summary>
        /// <returns></returns>
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/Camp/AddUpdateCamp")]
        public async Task<IActionResult> AddUpdateCamp([FromBody] CampDetail campDetail)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userLoginIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == "loginid");

            if (userLoginIdClaim == null)
            {
                return new JsonResult(new { status = 401, message = "User is not authorized." });
            }
            long userLoginId = Convert.ToInt32(userLoginIdClaim.Value);


            var cartItem = new CampDetail
            {
                CampName = campDetail.CampName,
                CampImage = campDetail.CampImage,
                CampType = campDetail.CampType,
                Address = campDetail.Address,
                City = campDetail.City,
                State = campDetail.State,
                Country = campDetail.Country,
                ZipCode = campDetail.ZipCode,
                PhoneNumber = campDetail.PhoneNumber,
                Description = campDetail.Description,
                OrganizerId = campDetail.OrganizerId,
                IsDeleted = campDetail.IsDeleted,
                Status = campDetail.Status,
                UserLoginId = userLoginId,
                Email = campDetail.Email,
                Latitude = campDetail.Latitude,
                Longitude = campDetail.Longitude,
                StartDate = campDetail.StartDate,
                EndDate = campDetail.EndDate,
                StartTime = campDetail.StartTime,
                EndTime = campDetail.EndTime
            };


            if (campDetail.Id == 0)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.CampDetails.Add(cartItem);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Camp successfully added." });
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).ToList();
                    return BadRequest(new { errors });
                }
                _context.CampDetails.Update(campDetail);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Camp successfully Updated." });
            }
        }

        /// <summary>
        /// to get all camp details 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/Camp/GetAllCamps")]
        public async Task<IActionResult> GetAllCamps()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userLoginIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == "loginid");

                if (userLoginIdClaim == null)
                {
                    return new JsonResult(new { status = 401, message = "User is not authorized." });
                }
                long userLoginId = Convert.ToInt32(userLoginIdClaim.Value);

                var campDetails = await _context.CampDetails.Where(camp => camp.IsDeleted == 0 && camp.UserLoginId == userLoginId).ToListAsync();

                if (campDetails == null || !campDetails.Any())
                {
                    return NotFound(new { message = "No camp details found." });
                }

                return Ok(campDetails);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = "An error occurred while retrieving the camp details.", error = ex.Message });
            }
        }

        /// <summary>
        /// to get camp detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/Camp/GetCampById/{id}")]
        public async Task<IActionResult> GetCampById(int id)
       {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userLoginIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == "loginid");

                if (userLoginIdClaim == null)
                {
                    return new JsonResult(new { status = 401, message = "User is not authorized." });
                }
                long userLoginId = Convert.ToInt32(userLoginIdClaim.Value);

                var campDetail = await _context.CampDetails.FirstOrDefaultAsync(c => c.Id == id && c.UserLoginId == userLoginId);

                if (campDetail == null)
                {
                    return NotFound(new { message = $"Camp detail with ID {id} not found." });
                }

                return Ok(campDetail);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = "An error occurred while retrieving the camp details.", error = ex.Message });
            }
        }


        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("api/Camp/DeleteCampById/{id}")]
        public async Task<IActionResult> DeleteCampById(int id)
        {
            try
            {

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userLoginIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == "loginid");

                if (userLoginIdClaim == null)
                {
                    return new JsonResult(new { status = 401, message = "User is not authorized." });
                }
                long userLoginId = Convert.ToInt32(userLoginIdClaim.Value);

                var campDetail = await _context.CampDetails.FirstOrDefaultAsync(c => c.Id == id && c.UserLoginId == userLoginId);
                if (campDetail == null)
                {
                    return NotFound(new { message = $"Camp detail with ID {id} not found." });
                }
                else
                {
                    campDetail.IsDeleted = 1;

                }
                _context.CampDetails.Update(campDetail);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Camp deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = "An error occurred while deleting the camp details.", error = ex.Message });
            }
        }

    }
}
