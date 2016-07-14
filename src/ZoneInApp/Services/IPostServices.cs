using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IPostServices
    {
        void DeletePost(int id);
        List<Post> GetActivePosts();
        Post GetPost(int id);
        void SavePost(Post post);
        List<Post> GetNeighborhoodPosts(string userId);
        void SaveThanks(int id, int thankValue);
    }
}