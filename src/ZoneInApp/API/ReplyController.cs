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
    public class ReplyController : Controller
    {
        private IReplyServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReplyController(IReplyServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/values
        /// <summary>
        /// ADMIN ONLY: get all replies across all neighborhoods
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Get()
        {
            return Ok();
        }

        // POST api/values
        /// <summary>
        /// Create or Edit a reply associated with the selected post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reply"></param>
        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Post(int id, [FromBody]Reply reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userId = _userManager.GetUserId(this.User);
                reply.UserId = userId;

                _service.SaveReply(id, reply);
                return Ok();
            }
        }
    }
}
