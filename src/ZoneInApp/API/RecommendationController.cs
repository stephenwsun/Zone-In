﻿using System;
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
    public class RecommendationController : Controller
    {
        private IRecommendationServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecommendationController(IRecommendationServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }


        // GET api/recommendations/getallrecommendations
        /// <summary>
        /// ADMIN ONLY: Get all recommendations across all neighborhoods across all categories
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Get()
        {
            var recommendations = _service.GetAllRecommendations();
            return Ok(recommendations);
        }


        // GET api/recommendations/getrecommendations
        /// <summary>
        /// GET all recommendations pertaining to the logged in user's neighborhood
        /// </summary>
        [HttpGet]
        [Route("getrecommendations")]
        [Authorize]
        public IActionResult GetRecommendations()
        {
            var userId = _userManager.GetUserId(this.User);
            var recommendations = _service.GetRecommendations(userId);
            return Ok(recommendations);
        }


        // GET api/recommendation/5
        /// <summary>
        /// Get a detailed info about the recommendation
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var recommendation = _service.GetRecommendation(id);
            return Ok(recommendation);
        }


        // POST api/recommendation
        /// <summary>
        /// Create or Edit a recommendation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recommendation"></param>
        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Post(int id, [FromBody]Recommendation recommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var userId = _userManager.GetUserId(this.User);

                recommendation.UserId = userId;
                recommendation.CategoryId = id;
                _service.SaveRecommendation(id, recommendation);
                return Ok();
            }
        }

        // PUT api/values/5
        /// <summary>
        /// Update the count on the Recommend button
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recommendationValue"></param>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]int recommendationValue)
        {
            _service.SaveRecommendations(id, recommendationValue);
            return Ok();
        }

        // DELETE api/values/5
        /// <summary>
        /// ADMIN ONLY: delete a recommendation
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
                _service.DeleteRecommendation(id);
                return Ok();
            }
        }
    }
}