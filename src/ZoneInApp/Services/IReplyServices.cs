using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IReplyServices
    {
        void SaveReply(int id, Reply reply);
    }
}