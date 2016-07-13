using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class PostServices : IPostServices
    {
        private IGenericRepository _repo;

        public PostServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Returns all active posts and all replies associated with each post
        /// </summary>
        /// <returns></returns>
        public List<Post> GetActivePosts()
        {
            var posts = _repo.Query<Post>().Include(p => p.Replies).Include(p => p.User).ToList();
            return posts;
        }

        /// <summary>
        /// Returns all posts with replies associated with the logged in user's neighborhood
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Post> GetNeighborhoodPosts(string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
            var posts = _repo.Query<Post>().Where(p => p.User.NeighborhoodName == user.NeighborhoodName).Include(p => p.Replies).Include(p => p.User).ToList();
            return posts;
        }

        /// <summary>
        /// Returns a single post with the matching id and all replies associated with post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetPost(int id)
        {
            var post = _repo.Query<Post>().Where(p => p.Id == id).Include(p => p.Replies).ThenInclude(r => r.User).Include(p => p.User).FirstOrDefault();
            return post;
        }

        /// <summary>
        /// Creates a new post if id is zero
        /// Edits post if post is already created
        /// </summary>
        /// <param name="post"></param>
        public void SavePost(Post post)
        {
            if (post.Id == 0)
            {
                post.Active = true;
                post.DateCreated = DateTime.UtcNow;

                _repo.Add(post);
            }

            else
            {
                var postEdit = _repo.Query<Post>().FirstOrDefault(p => p.Id == post.Id);
                postEdit.Title = post.Title;
                postEdit.Body = post.Body;
                postEdit.DateCreated = DateTime.UtcNow;
                _repo.SaveChanges();
            }
        }

        /// <summary>
        /// Keeps track of thank value for each post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="thankValue"></param>
        public void SaveThanks(int id, int thankValue)
        {
            var post = _repo.Query<Post>().Where(p => p.Id == id).FirstOrDefault();

            if (thankValue == 1)
            {
                post.Thanks++;
            }

            _repo.SaveChanges();
        }

        /// <summary>
        /// Deletes post with the matching id and all replies associated with post
        /// </summary>
        /// <param name="id"></param>
        public void DeletePost(int id)
        {
            var postDelete = _repo.Query<Post>().Where(p => p.Id == id).Include(p => p.Replies).FirstOrDefault();
            postDelete.Active = false;
            _repo.SaveChanges();
        }
    }
}