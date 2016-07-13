using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class ReplyServices : IReplyServices
    {
        private IGenericRepository _repo;

        public ReplyServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Adds reply to the post with matching post id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reply"></param>
        public void SaveReply(int id, Reply reply)
        {
            var post = _repo.Query<Post>().Where(p => p.Id == id).Include(p => p.Replies).Include(p => p.User).FirstOrDefault();
            reply.Active = true;
            reply.DateCreated = DateTime.UtcNow;
            post.Replies.Add(reply);

            _repo.SaveChanges();        
        }
    }
}
