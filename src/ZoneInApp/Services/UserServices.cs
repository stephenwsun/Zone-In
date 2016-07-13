using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class UserServices : IUserServices
    {
        private IGenericRepository _repo;

        public UserServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Returns all active users with matching neighborhood name
        /// </summary>
        /// <param name="neighborhood"></param>
        /// <returns></returns>
        public List<ApplicationUser> GetActiveUsers(string neighborhood)
        {
            var users = _repo.Query<ApplicationUser>().Where(u => u.Active == true).Where(u => u.NeighborhoodName == neighborhood).ToList();
            return users;
        }

        /// <summary>
        /// Returns user with matching number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationUser GetUser(string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Allows user to edit profile
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        public void EditUserProfile(ApplicationUser user, string id)
        {
            var editProfile = _repo.Query<ApplicationUser>().FirstOrDefault(u => u.Id == user.Id);
            editProfile.Biography = user.Biography;
            editProfile.Interests = user.Interests;
            editProfile.Skills = user.Skills;
            editProfile.Phone = user.Phone;
            _repo.SaveChanges();
        }
    }
}
