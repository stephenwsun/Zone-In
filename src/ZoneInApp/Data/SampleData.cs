using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using ZoneInApp.Models;
using System.Collections.Generic;

namespace ZoneInApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("stephensun.me@gmail.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "stephensun.me@gmail.com",
                    Email = "stephensun.me@gmail.com",
                    Active = true,
                    NeighborhoodName = "Canyon Gate at Westheimer Lakes",
                    FirstName = "Stephen",
                    LastName = "Sun",
                    Address = "10910 Wynfield Springs Dr., Richmond, TX 77406",
                    Biography = "Coding and playing video games is all I do day in and day out, so if there's anyone with similar interests, lets sync up.",
                    Interests = "Computer Games",
                    Skills = "Coding",
                    Phone = "832-570-0261",
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Deepa (IsAdmin)
            var deepa = await userManager.FindByNameAsync("deepachacko@gmail.com");
            if (deepa == null)
            {
                // create user
                deepa = new ApplicationUser
                {
                    UserName = "deepachacko@gmail.com",
                    Email = "deepachacko@gmail.com",
                    Active = true,
                    NeighborhoodName = "E Lk Hills",
                    FirstName = "Deepa",
                    LastName = "Chacko",
                    Address = "628 154th Ave SE, Bellevue, WA 98007",
                    Biography = "I love yoga, church, composting, organizing and walking, so if anyone has similar interests, I would be happy to catch up.",
                    Interests = "Yoga, Composting",
                    Skills = "CPR",
                    Phone = "206-234-4602",
                };
                await userManager.CreateAsync(deepa, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(deepa, new Claim("IsAdmin", "true"));
            }

            // Ensure Jeff (IsAdmin)
            var jeff = await userManager.FindByNameAsync("jeffhannel@gmail.com");
            if (jeff == null)
            {
                // create user
                jeff = new ApplicationUser
                {
                    UserName = "jeffhannel@gmail.com",
                    Email = "jeffhannel@gmail.com",
                    Active = true,
                    NeighborhoodName = "Queen Anne",
                    FirstName = "Jeff",
                    LastName = "Hannel",
                    Address = "1000 Queen Anne Ave N, Seattle, WA 98109",
                    Biography = "I love going on long walks with my wife and spending time with my cat.",
                    Interests = "Grilling",
                    Skills = "Grilling",
                    Phone = "206-962-7126",
                };
                await userManager.CreateAsync(jeff, "Secret123!");

                // add claims
                //await userManager.AddClaimAsync(jeff, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("mike@codercamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "mike@codercamps.com",
                    Email = "mike@codercamps.com",
                    Active = true,
                    NeighborhoodName = "Canyon Gate at Westheimer Lakes",
                    FirstName = "Mike",
                    LastName = "Smith",
                    Address = "25226 Hamden Valley Dr, Richmond, TX 77406",
                    Biography = "I love riding horses and living in the countryside.",
                    Interests = "Horses",
                    Skills = "Horse riding",
                    Phone = "718-557-1326",
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            // Ensure Pamela (not IsAdmin)
            var pamela = await userManager.FindByNameAsync("pamela@codercamps.com");
            if (pamela == null)
            {
                // create user
                pamela = new ApplicationUser
                {
                    UserName = "pamela@codercamps.com",
                    Email = "pamela@codercamps.com",
                    Active = true,
                    NeighborhoodName = "E Lk Hills",
                    FirstName = "Pamela",
                    LastName = "Osborne",
                    Address = "15418 SE 8th St, Bellevue, WA 98007",
                    Biography = "I am an urban and regional planner.",
                    Interests = "Blogging",
                    Skills = "Social Media",
                    Phone = "718-557-1326",
                };
                await userManager.CreateAsync(pamela, "Secret123!");
            }

            var charles = await userManager.FindByNameAsync("charles@codercamps.com");
            if (charles == null)
            {
                // create user
                charles = new ApplicationUser
                {
                    UserName = "charles@codercamps.com",
                    Email = "charles@codercamps.com",
                    Active = true,
                    NeighborhoodName = "Queen Anne",
                    FirstName = "Charles",
                    LastName = "Clark",
                    Address = "1237 Warren Ave N, Seattle, WA 98109",
                    Biography = "I am a personal trainer at 24 Hour Fitness.",
                    Interests = "Working out",
                    Skills = "Lifting weights, Coaching",
                    Phone = "914-388-0731",
                };
                await userManager.CreateAsync(charles, "Secret123!");
            }

            var chris = await userManager.FindByNameAsync("chris@codercamps.com");
            if (chris == null)
            {
                // create user
                chris = new ApplicationUser
                {
                    UserName = "chris@codercamps.com",
                    Email = "chris@codercamps.com",
                    Active = true,
                    NeighborhoodName = "Canyon Gate at Westheimer Lakes",
                    FirstName = "Chris",
                    LastName = "Guild",
                    Address = "10918 Dermott Ridge Dr, Richmond, TX 77406",
                    Biography = "I am a cashier at Krogers.",
                    Interests = "Watching movies",
                    Skills = "Cooking",
                    Phone = "785-439-7189",
                };
                await userManager.CreateAsync(chris, "Secret123!");
            }

            var jamie = await userManager.FindByNameAsync("jamie@codercamps.com");
            if (jamie == null)
            {
                // create user
                jamie = new ApplicationUser
                {
                    UserName = "jamie@codercamps.com",
                    Email = "jamie@codercamps.com",
                    Active = true,
                    NeighborhoodName = "E Lk Hills",
                    FirstName = "Jamie",
                    LastName = "Porter",
                    Address = "228 153rd Pl SE, Bellevue, WA 98007",
                    Biography = "I am the chief operating officer at Woolf Brothers.",
                    Interests = "Technology",
                    Skills = "Public speaking",
                    Phone = "586-578-1845",
                };
                await userManager.CreateAsync(jamie, "Secret123!");
            }

            var evelyn = await userManager.FindByNameAsync("evelyn@codercamps.com");
            if (evelyn == null)
            {
                // create user
                evelyn = new ApplicationUser
                {
                    UserName = "evelyn@codercamps.com",
                    Email = "evelyn@codercamps.com",
                    Active = true,
                    NeighborhoodName = "Queen Anne",
                    FirstName = "Evelyn",
                    LastName = "Harrison",
                    Address = "164 Aloha St, Seattle, WA 98109",
                    Biography = "I am a sports analyst for ESPN.",
                    Interests = "Football, Basketball",
                    Skills = "Statistics",
                    Phone = "510-327-7089",
                };
                await userManager.CreateAsync(evelyn, "Secret123!");
            }
            context.SaveChanges();
        }
    }
}
