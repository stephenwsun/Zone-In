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
    public class CategoryController : Controller
    {
        private ICategoryServices _service;
        private IRecommendationServices _recoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ICategoryServices service, UserManager<ApplicationUser> userManager, IRecommendationServices recoService)
        {
            _service = service;
            _userManager = userManager;
            _recoService = recoService;
        }


        // GET: api/category
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var categories = _service.GetCategories();
            return Ok(categories);
        }


        // GET api/category/getcategoryrecommendations
        [HttpGet]
        [Route("getCategoryRecommendations")]
        [Authorize]
        public IActionResult GetCategoryRecommendations(int id)
        {
            var userId = _userManager.GetUserId(User);
            var recommendations = _service.GetCategory(id, userId);
            return Ok(recommendations);
        }


        // POST api/category
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                _service.SaveCategory(category);
                return Ok(category);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
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
                _service.DeleteCategory(id);
                return Ok();
            }
        }
    }
}
