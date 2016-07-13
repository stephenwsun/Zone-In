using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ZoneInApp.Models;

namespace ZoneInApp.Data
{
    public class SamplePosts
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Free Items",
                        Title = "Free Sofa Bed",
                        Body = "We are moving in a month and we have decided to not take this sofa with us. Gently used, pet-free smoke-free home.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Yeah I would love that, please consider me."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Oh I've been wanting one for so long, do consider me."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "This is very generous of you, I don't need it but wanted to acknowledge."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Is it already taken?"
                                }
                            }
                    },

                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Crime & Safety",
                        Title = "Mail Thieves Caught",
                        Body = "Based on a tip from a neighbor, the cops were able to nab the 3 member gang. Other stolen artifacts have been recovered.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Yay, awesome work."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Thank goodness, you guys are the best."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Kudos to the Bellevue Police Dept."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "I concur, true super heroes."
                                }
                            }
                    },

                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Crime & Safety",
                        Title = "Burglary on 5th & Madison",
                        Body = "We heard someone trying to open our front door. We called the cops, but by then he had fled the scene. He was wearing a blue jersey.",
                        Urgent = true,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Gives me the creeps!!!"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "This used to be a safe neighborhood, now am too scared to            even walk after dusk."
                                }
                            }
                    },

                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "General",
                        Title = "Construction by Crossroads Mall",
                        Body = "Good lord, the traffic is already terrrible, it takes 4 stop lights to get to my house. Wonder how much worse it's gonna get.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "We should vote to stop this construction."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "We are expanding and its time to embrace it."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "All these immigrants are spoiling the look of our suburbs."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Yikes, not another affordable housing."
                                }
                            }
                    },

                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Lost & Found",
                        Title = "White Husky found on Main St and 148th",
                        Body = "I tried to get to it but  it seemed shy and ran in the opposite direction.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Oh let me try to post it on the facebook group as well."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Were you able to take a picture?"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Did it have a collar or a micro-chip?"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Poor thing, hope it's owner is found."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Too many people abandon their pets these days, the owners must be punished."
                                }
                            }
                    },
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Crime & Safety ",
                        Title = "Accident on Fulshear access road",
                        Body = "There is a trailer that over-turned, para medics are on their way",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Geez, this is the 2nd such incident in the last 6 months"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "This city council meeting I plan to bring up this issue"
                                }
                            }
                    },
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "General",
                        Title = "July 4th fireworks",
                        Body = "Please be mindful of PTSD, veterans and pets. Also, lock your pets or keep them indoors.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Come on, its one time in a year. We need to stop putting a ban on everything."
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "I agree, my pet shivers every year and she hides under the bed"
                                }
                            }
                    },
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Lost & Found",
                        Title = "iPhone 6 found in the Fulshear mall parking lot",
                        Body = "Owner has to reveal details to confirm rightful ownership",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "You are such a good soul"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Thank goodness, am coming over to the mall. I was frantically searching for it. The case is black in color and cracked on the left"
                                },
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Indeed it is!!"
                                }
                            }
                    },
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "General",
                        Title = "Hiking group for all ages",
                        Body = "Join a group of like minded individuals for a day of hiking and interaction",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "I'd love to join, details please"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Is there an age limit?"
                                },
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Preferably no kids, otherwise no age limit"
                                }
                            }
                    },
                    new Post
                    {
                        UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                        Active = true,
                        DateCreated = DateTime.UtcNow,
                        Thanks = 0,
                        Category = "Classifieds",
                        Title = "50% off House cleaning service",
                        Body = "I am a new business owner and wanted to first reach out to my neighborhood. My staff are very professional and experienced.",
                        Urgent = false,

                        Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Umm, are we allowed to solicit on this app?"
                                },

                                new Reply
                                {
                                    UserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                                    Active = true,
                                    DateCreated = DateTime.UtcNow,
                                    Thanks = 0,
                                    Message = "Rates and timings, please."
                                }
                            }
                    });
            }
            context.SaveChanges();
        }
    }
}