using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IUserServices
    {
        void EditUserProfile(ApplicationUser user, string id);
        List<ApplicationUser> GetActiveUsers(string neighborhood);
        ApplicationUser GetUser(string id);
    }
}