using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ZoneInApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ZoneInApp.Data
{
    public class SampleInbox
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();

            if (!context.PrivateMessages.Any())
            {
                var firstMessage = new PrivateMessage
                {
                    Subject = "Saw your post for a free sofa",
                    Body = "Hi, I saw that you're giving away a free sofa. Do you know what color it is?",
                    Time = DateTime.UtcNow,
                    FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                    ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                    IsOriginal = true,
                };

                context.PrivateMessages.Add(firstMessage);
                context.SaveChanges();
                firstMessage.ParentId = firstMessage.Id;
                context.SaveChanges();

                context.PrivateMessages.AddRange(

                    new PrivateMessage
                    {
                        Subject = "Saw your post for a free sofa",
                        Body = "Blue",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        IsOriginal = false,
                        ParentId = firstMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "Saw your post for a free sofa",
                        Body = "Is it still available?",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        IsOriginal = false,
                        ParentId = firstMessage.Id

                    },
                    new PrivateMessage
                    {
                        Subject = "Saw your post for a free sofa",
                        Body = "Yep, can you come in the evening, I'm out all day",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Chris")).Id,
                        IsOriginal = false,
                        ParentId = firstMessage.Id
                    });

                var secondMessage = new PrivateMessage
                {
                    Subject = "White Husky seen limping",
                    Body = "I think I saw a white husky limping near the intersection of crossroads mall and main street. what is the dog's name?",
                    Time = DateTime.UtcNow,
                    FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                    ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                    IsOriginal = true,
                };
                context.PrivateMessages.Add(secondMessage);
                context.SaveChanges();
                secondMessage.ParentId = secondMessage.Id;
                context.SaveChanges();

                context.PrivateMessages.AddRange(

                    new PrivateMessage
                    {
                        Subject = "White Husky seen limping",
                        Body = "Oh no, I will scout that area now. His name is Leone",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        IsOriginal = false,
                        ParentId = secondMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "White Husky seen limping",
                        Body = "Let me know if you need help putting up the flyers",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                        IsOriginal = false,
                        ParentId = secondMessage.Id
                    });

                var thirdMessage = new PrivateMessage
                {
                    Subject = "House cleaning",
                    Body = "Do you have any openings for the 25th of July?",
                    Time = DateTime.UtcNow,
                    FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                    ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                    IsOriginal = true,
                };

                context.PrivateMessages.Add(thirdMessage);
                context.SaveChanges();
                thirdMessage.ParentId = thirdMessage.Id;
                context.SaveChanges();

                context.PrivateMessages.AddRange(
                    new PrivateMessage
                    {
                        Subject = "House cleaning",
                        Body = "Yes I do, how many rooms do you need to get cleaned? Also, deep clean or just vacuum and dust?",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        IsOriginal = false,
                        ParentId = thirdMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "House cleaning",
                        Body = "Just vacuum would do, thanks! I have about 4 rooms and a living room",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        IsOriginal = false,
                        ParentId = thirdMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "House cleaning",
                        Body = "Ok, will be there. Confirming appointment for July 25th",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        IsOriginal = false,
                        ParentId = thirdMessage.Id
                    });

                var fourthMessage = new PrivateMessage
                {
                    Subject = "Vermicomposting",
                    Body = "Hey, I am looking to start vermicomposting. I heard you vermicompost, any tips for a newbie?",
                    Time = DateTime.UtcNow,
                    FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Jamie")).Id,
                    ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                    IsOriginal = true,
                };

                context.PrivateMessages.Add(fourthMessage);
                context.SaveChanges();
                fourthMessage.ParentId = fourthMessage.Id;
                context.SaveChanges();

                context.PrivateMessages.AddRange(
                    new PrivateMessage
                    {
                        Subject = "Vermicomposting",
                        Body = "Have you purchased the worm bin and worms and bedding material?",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        IsOriginal = false,
                        ParentId = fourthMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "Vermicomposting",
                        Body = "Yes, I have the worm factory and the worms but no bedding",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        IsOriginal = false,
                        ParentId = fourthMessage.Id
                    },
                    new PrivateMessage
                    {
                        Subject = "Vermicomposting",
                        Body = "That's fine. If you have junk mail or shredded paper or cardboard, that will suffice as a bedding",
                        Time = DateTime.UtcNow,
                        FromUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                        ToUserId = (context.Users.FirstOrDefault(u => u.FirstName == "Pamela")).Id,
                        IsOriginal = false,
                        ParentId = fourthMessage.Id
                    }
                );
            }
            context.SaveChanges();
        }
    }
}