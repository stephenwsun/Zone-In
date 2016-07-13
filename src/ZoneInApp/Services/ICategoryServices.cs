using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface ICategoryServices
    {
        void DeleteCategory(int id);
        void SaveCategory(Category category);
        List<Category> GetCategories();
        //List<Category> GetCategory(int id, string userId);
        List<Recommendation> GetCategory(int id, string userId);
    }
}