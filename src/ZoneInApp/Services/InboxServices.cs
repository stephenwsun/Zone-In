using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class InboxServices : IInboxServices
    {
        private IGenericRepository _repo;

        public InboxServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Returns all private messages associated with the logged in user's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PrivateMessage> GetPrivateMessages(string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
            //user.PrivateMessages = user.PrivateMessages.ToList();
            var messages = _repo.Query<PrivateMessage>().Where(m => m.ToUser.Id == user.Id || m.FromUserId == user.Id).Where(m => m.IsOriginal == true).ToList();

            //var messages = user.PrivateMessages.ToList();

            //var messages = _repo.Query<PrivateMessage>().Where(m => m.FromUser.Id == user.Id).ToList();
            return messages;
        }

        /// <summary>
        /// Returns a single private message with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PrivateMessage GetPrivateMessage(int id)
        {
            //var message = _repo.Query<PrivateMessage>().Where(m => m.Id == id).FirstOrDefault();
            var message = _repo.Query<PrivateMessage>().Where(m => m.ParentId == id).FirstOrDefault();
            return message;
        }

        /// <summary>
        /// Creates a new private message if id is zero
        /// Edits private message if message is already created
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        public void SavePrivateMessage(PrivateMessage message, string id)
        {
            if (message.Id == 0)
            {
                var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();

                message.Time = DateTime.UtcNow;
                _repo.Add(message);
            }

            else
            {
                var messageEdit = _repo.Query<PrivateMessage>().FirstOrDefault(m => m.Id == message.Id);
                messageEdit.Subject = message.Subject;
                messageEdit.Body = message.Body;
                messageEdit.Time = DateTime.UtcNow;
                _repo.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes message with the matching id
        /// </summary>
        /// <param name="id"></param>
        public void DeletePrivateMessage(int id)
        {
            var messageDelete = _repo.Query<PrivateMessage>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(messageDelete);
        }
    }
}
