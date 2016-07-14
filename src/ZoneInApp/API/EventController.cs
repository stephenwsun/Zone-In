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
    public class EventController : Controller
    {
        private IEventServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(IEventServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/event/getactiveevents
        /// <summary>
        /// ADMIN ONLY: Get all events from all neighborhoods
        /// </summary>
        [HttpGet]
        [Route("getactiveevents")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetActiveEvents()
        {
            var events = _service.GetActiveEvents();
            return Ok(events);
        }

        // GET: api/event/getevents
        /// <summary>
        /// All events pertaining to the logged in user's neighborhood
        /// </summary>
        [HttpGet]
        [Route("getevents")]
        [Authorize]
        public IActionResult GetEvents()
        {
            var userId = _userManager.GetUserId(User);
            var events = _service.GetEvents(userId);
            return Ok(events);
        }


        // GET api/event/5
        /// <summary>
        /// Detailed information about the selected event
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetEvent(int id)
        {
            var ev = _service.GetEvent(id);
            return Ok(ev);
        }

        // POST api/event
        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="ev"></param>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Event ev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var userId = _userManager.GetUserId(this.User);
                ev.UserId = userId;

                _service.SaveEvent(ev);
                return Ok(ev);
            }
        }

        // PUT api/values/5
        /// <summary>
        /// Update the Going, Maybe, Declined options of the event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventValue"></param>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]int eventValue)
        {
            if (eventValue == 1)
            {
                _service.SaveGoing(id);
                return Ok();
            }

            else if (eventValue == 2)
            {
                _service.SaveMaybe(id);
                return Ok();
            }

            else if (eventValue == 3)
            {
                _service.SaveDecline(id);
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }

        // DELETE api/event/5
        /// <summary>
        /// ADMIN ONLY: Deletes an event from any neighborhood
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                _service.DeleteEvent(id);
                return Ok();
            }
        }
    }
}