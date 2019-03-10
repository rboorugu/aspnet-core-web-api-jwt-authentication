using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// get the user id from claims and returns all user details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<User> Get()
        {
            //read the user id
            var id = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (id == 0)
            {
                return StatusCode(404);
            }
            //return user details
            return Data.Users.GetUsers().Where(w => w.Id == id).FirstOrDefault();
        }
    }
}