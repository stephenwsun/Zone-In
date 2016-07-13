using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IEventServices
    {
        void DeleteEvent(int id);
        void SaveEvent(Event ev);
        List<Event> GetEvents(string userId);
        List<Event> GetActiveEvents();
        Event GetEvent(int id);
        void SaveGoing(int id);
        void SaveMaybe(int id);
        void SaveDecline(int id);
    }
}