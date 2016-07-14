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
    public class PostController : Controller
    {
        private IPostServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(IPostServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/post/getactiveposts
        /// <summary>
        /// ADMIN ONLY: Get all posts from all neighborhoods
        /// </summary>
        [HttpGet]
        [Route("getactiveposts")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetActivePosts()
        {
            var posts = _service.GetActivePosts();
            return Ok(posts);
        }

        // GET: api/post/getneighborhoodposts
        /// <summary>
        /// Get posts pertaining to the logged in user's neighborhood
        /// </summary>
        [HttpGet]
        [Route("getneighborhoodposts")]
        [Authorize]
        public IActionResult GetNeighborhoodPosts()
        {
            var userId = _userManager.GetUserId(this.User);
            var posts = _service.GetNeighborhoodPosts(userId);
            return Ok(posts);
        }

        // GET api/post/5
        /// <summary>
        /// Get all replies pertaining to the selected post
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetPost(int id)
        {
            var post = _service.GetPost(id);
            return Ok(post);
        }

        // POST api/post
        /// <summary>
        /// Create or Edit a post
        /// </summary>
        /// <param name="post"></param>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var userId = _userManager.GetUserId(this.User);
                post.UserId = userId;
                _service.SavePost(post);
                return Ok(post);
            }
        }

        // PUT api/values/5
        /// <summary>
        /// Update the count when the "Thanks" button is clicked
        /// </summary>
        /// <param name="id"></param>
        /// <param name="thankValue"></param>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]int thankValue)
        {
            _service.SaveThanks(id, thankValue);
            return Ok();
        }

        // DELETE api/post/5
        /// <summary>
        /// Delete a post
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
                _service.DeletePost(id);
                return Ok();
            }
        }
    }
}