using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IInboxServices
    {
        void DeletePrivateMessage(int id);
        PrivateMessage GetPrivateMessage(int id);
        List<PrivateMessage> GetPrivateMessages(string id);
        void SavePrivateMessage(PrivateMessage message, string id);
    }
}