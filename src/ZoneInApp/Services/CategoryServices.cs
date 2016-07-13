using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class CategoryServices: ICategoryServices
    {
        private IGenericRepository _repo;

        public CategoryServices(IGenericRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Returns all business categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            var categories = _repo.Query<Category>().ToList();
            return categories;
        }


        /// <summary>
        /// Returns a single business category with the matching id and all recommended businesses associated with category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Recommendation> GetCategory(int id, string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
            //var categories = _repo.Query<Category>().Where(c => c.Id == id).Include(r => r.Recommendations.Where(c => c.User.NeighborhoodName == user.NeighborhoodName)).ToList();
            var recommendations = _repo.Query<Recommendation>().Where(r => r.CategoryId == id).Where(r => r.User.NeighborhoodName == user.NeighborhoodName).ToList();
            return recommendations;
        }


        /// <summary>
        /// Admin use
        /// Creates a new business category if id is zero
        /// Edits business category if category is already created
        /// </summary>
        /// <param name="category"></param>
        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                _repo.Add(category);
            }
            else
            {
                var categoryEdit = _repo.Query<Category>().Where(c => c.Id == category.Id).FirstOrDefault();
                categoryEdit.Name = category.Name;
                categoryEdit.NumBusinesses = _repo.Query<Category>().Where(c => c.Id == category.Id).Count();
                _repo.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes business category with the matching id and all recommendations associated with category
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategory(int id)
        {
            var categoryDelete = _repo.Query<Category>().Where(c => c.Id == id).FirstOrDefault();
            _repo.SaveChanges();
        }
    }
}
