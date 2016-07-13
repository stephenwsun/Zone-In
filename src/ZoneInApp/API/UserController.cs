using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoneInApp.Services;
using ZoneInApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZoneInApp.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/user/getactiveusers
        [HttpGet]
        [Route("getactiveusers")]
        [Authorize]
        public IActionResult GetActiveUsers()
        {
            var userId = _userManager.GetUserId(this.User);
            
            var user = _service.GetUser(userId);
            
            var users = _service.GetActiveUsers(user.NeighborhoodName);

            var updatedUsers = users.Remove(user);

            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUser(string id)
        {
            var user = _service.GetUser(id);
            return Ok(user);
        }

        // GET api/user/5
        [HttpGet]
        [Authorize]
        public IActionResult GetLoginUser()
        {
            var userId = _userManager.GetUserId(this.User);
            var user = _service.GetUser(userId);
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var userId = _userManager.GetUserId(this.User);
                _service.EditUserProfile(user, userId);
                return Ok(user);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
