using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoneInApp.Services;
using Microsoft.AspNetCore.Identity;
using ZoneInApp.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZoneInApp.API
{
    [Route("api/[controller]")]
    public class InboxController : Controller
    {
        private IInboxServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public InboxController(IInboxServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/message
        /// <summary>
        /// Get all Parent messages only
        /// </summary>
        [HttpGet]
        [Route("getusermessages")]
        [Authorize]
        public IActionResult GetUserMessages()
        {
            var userId = _userManager.GetUserId(this.User);
            var messages = _service.GetPrivateMessages(userId);
            return Ok(messages);
        }

        // GET api/message/5
        /// <summary>
        /// Get the Parent message and subsequent replies to it
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetMessage(int id)
        {
            var message = _service.GetPrivateMessage(id);
            return Ok(message);
        }

        // POST api/message
        /// <summary>
        /// Create or Edit a message
        /// </summary>
        /// <param name="message"></param>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]PrivateMessage message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var userId = _userManager.GetUserId(this.User);
                _service.SavePrivateMessage(message, userId);
                return Ok(message);
            }
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete a message
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                _service.DeletePrivateMessage(id);
                return Ok();
            }
        }
    }
}
