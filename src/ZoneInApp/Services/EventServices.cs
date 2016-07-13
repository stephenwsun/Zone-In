using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class EventServices : IEventServices
    {
        private IGenericRepository _repo;

        public EventServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// returns all events in the logged in user's neighborhood
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Event> GetEvents(string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
            var events = _repo.Query<Event>().Where(ev => ev.User.NeighborhoodName == user.NeighborhoodName).ToList();
            return events;
        }


        /// <summary>
        /// Returns all active events
        /// </summary>
        /// <returns></returns>
        public List<Event> GetActiveEvents()
        {
            var events = _repo.Query<Event>().ToList();
            return events;
        }


        /// <summary>
        /// Returns a single event with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            var eventDetail = _repo.Query<Event>().Where(e => e.Id == id).FirstOrDefault();
            return eventDetail;
        }

        /// <summary>
        /// Creates a new event if id is zero
        /// Edits an event if event is already created
        /// </summary>
        /// <param name="ev"></param>
        public void SaveEvent(Event ev)
        {
            if (ev.Id == 0)
            {
                ev.Active = true;
                _repo.Add(ev);
            }

            else
            {
                var eventEdit = _repo.Query<Event>().FirstOrDefault(e => e.Id == ev.Id);
                eventEdit.Title = ev.Title;
                eventEdit.Description = ev.Description;

                _repo.SaveChanges();
            }
        }

        /// <summary>
        /// Keeps track of going value for events
        /// </summary>
        /// <param name="id"></param>
        /// <param name="goingValue"></param>
        public void SaveGoing(int id)
        {
            var ev = _repo.Query<Event>().Where(p => p.Id == id).FirstOrDefault();

            ev.Going++;
            _repo.SaveChanges();
        }

        /// <summary>
        /// Keeps track of maybe value for events
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maybeValue"></param>
        public void SaveMaybe(int id)
        {
            var ev = _repo.Query<Event>().Where(p => p.Id == id).FirstOrDefault();

            ev.Maybe++;
            _repo.SaveChanges();
        }

        /// <summary>
        /// Keeps track of decline value for events
        /// </summary>
        /// <param name="id"></param>
        /// <param name="declineValue"></param>
        public void SaveDecline(int id)
        {
            var ev = _repo.Query<Event>().Where(p => p.Id == id).FirstOrDefault();

            ev.Declined++;
            _repo.SaveChanges();
        }

        /// <summary>
        /// Deletes event with the matching id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id)
        {
            var eventDelete = _repo.Query<Event>().Where(e => e.Id == id).FirstOrDefault();
            eventDelete.Active = false;

            _repo.SaveChanges();
        }
    }
}