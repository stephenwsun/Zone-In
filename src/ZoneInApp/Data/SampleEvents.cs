using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ZoneInApp.Models;

namespace ZoneInApp.Data
{
    public class SampleEvents
    {
        public static void Initialize(IServiceProvider sp)
        {
            var context = sp.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        Active = true,
                        Title = "Code Jam",
                        Description = "Hello, calling all coders for a night of coding and sharing ideas and plain networking",
                        EventAddr = "10910 Wynfield Springs Dr., Richmond, TX 77406",
                        EventStart = new DateTime(2016, 7, 23, 22, 0, 0),
                        EventEnd = new DateTime(2016, 7, 24, 6, 0, 0),
                        Going = 9,
                        Declined = 2,
                        Maybe = 3
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        Active = true,
                        Title = "FREE FREE FREE ----Garage Sale--- FREE FREE FREE",
                        Description = "I would like to practise being a minimalist and what better way than to start purging things in my own garage. Come attend and take what you need.",
                        EventAddr = "628 154th Ave SE, Bellevue, WA 98007",
                        EventStart = new DateTime(2016, 7, 31, 10, 0, 0),
                        EventEnd = new DateTime(2016, 7, 31, 16, 0, 0),
                        Going = 11,
                        Declined = 4,
                        Maybe = 7
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        Active = true,
                        Title = "Learn about Construction Management from a pro",
                        Description = "This will be a fun interactive session, so be prepared to ask lots of questions. If you're looking for a career in construction management, this session will be very informative",
                        EventAddr = "1000 Queen Anne Ave N, Seattle, WA 98109",
                        EventStart = new DateTime(2016, 7, 26, 9, 0, 0),
                        EventEnd = new DateTime(2016, 7, 26, 12, 0, 0),
                        Going = 3,
                        Declined = 10,
                        Maybe = 2
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        Active = true,
                        Title = "Obstacle course at Creek Trail",
                        Description = "Hello, calling all young and old to join in the annual obstacle course. A fun event for family and friends. Limited to first 100 participants. RSVP mandatory.",
                        EventAddr = "31803 Fulshear Creek Trail, Fulshear, TX",
                        EventStart = new DateTime(2016, 7, 16, 10, 0, 0),
                        EventEnd = new DateTime(2016, 7, 16, 14, 0, 0),
                        Going = 48,
                        Declined = 12,
                        Maybe = 27
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        Active = true,
                        Title = "Kids play date at Lk Hills Community Park",
                        Description = "Hello, calling all kids between the ages of 5-9 to come hang out. Health food choices and drinks will be available",
                        EventAddr = "1200-164th Avenue SE, Bellevue, WA 98009",
                        EventStart = new DateTime(2016, 7, 16, 10, 0, 0),
                        EventEnd = new DateTime(2016, 7, 16, 14, 0, 0),
                        Going = 9,
                        Declined = 2,
                        Maybe = 4
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                        Active = true,
                        Title = "Recycling Day at Seattle Goodwill",
                        Description = "If you would like to dispose your outdated or broken electronic items, this is a safe location to dispose it",
                        EventAddr = "115 Belmont Ave E, Seattle, WA 98102",
                        EventStart = new DateTime(2016, 7, 31, 10, 0, 0),
                        EventEnd = new DateTime(2016, 7, 31, 16, 0, 0),
                        Going = 16,
                        Declined = 3,
                        Maybe = 6
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        Active = true,
                        Title = "Basic HTML5/CSS Workshop for Middle Schoolers at Seven Lakes High School",
                        Description = "Hello, this will be a hands on learning session. I would like to pass on the knowledge that I recently acquired from a coding bootcamp. It is super easy and so much fun, you won't want to miss it",
                        EventAddr = "9251 S Fry Rd, Katy, TX 77494",
                        EventStart = new DateTime(2016, 7, 30, 10, 0, 0),
                        EventEnd = new DateTime(2016, 7, 30, 16, 0, 0),
                        Going = 56,
                        Declined = 22,
                        Maybe = 37
                    },
                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        Active = true,
                        Title = "Karaoke at Baker Street Pub & Grill",
                        Description = "Calling all for a night of crooning",
                        EventAddr = "23501 Cinco Ranch Blvd, Katy, TX 77494",
                        EventStart = new DateTime(2016, 7, 15, 19, 0, 0),
                        EventEnd = new DateTime(2016, 7, 15, 23, 0, 0),
                        Going = 8,
                        Declined = 3,
                        Maybe = 5
                    },
                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        Active = true,
                        Title = "Wine tasting at Braman Winery",
                        Description = "Exquisite aged wine, join us for an afternoon of fun and laughter",
                        EventAddr = "3333 Farm to Market 359, Richmond, TX 77406",
                        EventStart = new DateTime(2016, 7, 17, 11, 0, 0),
                        EventEnd = new DateTime(2016, 7, 17, 16, 0, 0),
                        Going = 12,
                        Declined = 3,
                        Maybe = 5
                    },
                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        Active = true,
                        Title = "B'day party at Kingdom & Wheels",
                        Description = "Let's celebrate Katy's 8th B'day",
                        EventAddr = "25757 Westheimer Pkwy #190, Katy, TX 77494",
                        EventStart = new DateTime(2016, 7, 17, 11, 0, 0),
                        EventEnd = new DateTime(2016, 7, 17, 15, 0, 0),
                        Going = 22,
                        Declined = 3,
                        Maybe = 2
                    },
                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        Active = true,
                        Title = "Vermicomposting",
                        Description = "This will be a fun interactive session for all those interested in reducing kitchen waste and turning it into healthy compost for your garden",
                        EventAddr = "628 154th Ave SE, Bellevue, WA 98007",
                        EventStart = new DateTime(2016, 7, 26, 9, 0, 0),
                        EventEnd = new DateTime(2016, 7, 26, 12, 0, 0),
                        Going = 15,
                        Declined = 4,
                        Maybe = 6
                    },

                    new Event
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        Active = true,
                        Title = "Its summer and its grilling time at Kerry Park",
                        Description = "Inviting all couples for an afternoon of grilling and playing poker by the pool",
                        EventAddr = "211 W Highland Dr, Seattle, WA 98119",
                        EventStart = new DateTime(2016, 7, 16, 11, 0, 0),
                        EventEnd = new DateTime(2016, 7, 16, 17, 0, 0),
                        Going = 23,
                        Declined = 6,
                        Maybe = 9
                    });
            }
            context.SaveChanges();
        }
    }
}