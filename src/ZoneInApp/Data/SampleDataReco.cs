using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ZoneInApp.Models;

namespace ZoneInApp.Data
{
    public class SampleDataReco
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            if (!db.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Veterinarians", NumBusinesses = 2},
                    new Category { Name = "Plumbers", NumBusinesses = 4 },
                    new Category { Name = "Carpet Cleaners", NumBusinesses = 3 },
                    new Category { Name = "Auto Repair", NumBusinesses = 2 },
                    new Category { Name = "Appliance Repair", NumBusinesses = 2},
                    new Category { Name = "Movers", NumBusinesses = 2 }
                };

                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            if (!db.Recommendations.Any())
            {
                var recommendations = new Recommendation[]
                {
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "North Coast Moving & Storage",
                                BusAddr = "13045 SE 32nd St, Bellevue, WA 98005",
                                BusPhone = "(206) 501-3846",
                                Url = "www.ncoastallied.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Reliable Moving",
                                BusAddr = "2608 2nd Ave #123, Seattle, WA 98121",
                                BusPhone = "(206) 443-0210",
                                Url = "www.reliablemoving.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Movers of America",
                                BusAddr = "2648 15th Ave W Suite 1045, Seattle, WA 98119",
                                BusPhone = "(206) 459-4708",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "ABC Appliance Services",
                                BusAddr = "11700 NE 7th St, Bellevue, WA 98005",
                                BusPhone = "(425) 644-5260",
                                NumRecos = 3,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Albert Lee Appliance",
                                BusAddr = "1476 Elliott Ave W, Seattle, WA 98119",
                                BusPhone = "(206) 282-2110",
                                Url = "www.albertleeappliance.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Emerald City Appliance Repair",
                                BusAddr = "1200 Westlake Ave N #1006, Seattle, WA 98109",
                                BusPhone = "(206) 274-1084",
                                Url = "www.emeraldcityappliancerepair.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "InFix Appliances Repair",
                                BusAddr = "7115 S Mason Rd, Richmond, TX 77407",
                                BusPhone = "(832) 514-5190",
                                Url = "www.infixappliancesrepair.com",
                                NumRecos = 5,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Weston Lakes Appliance Repair",
                                BusAddr = "4814 Winster Dr, Fulshear, TX 77441",
                                BusPhone = "(281) 407-0120",
                                NumRecos = 2,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Houston Katy Appliance Repair",
                                BusAddr = "19002 Waterford Cove, Houston, TX 77094",
                                BusPhone = "(832) 321-3758",
                                Url="www.houston-katy-appliance-repair.com",
                                NumRecos = 4,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Appliance Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Cinco Tire & Automotive",
                                BusAddr = "24217 Cinco Terrace Dr, Katy, TX 77494",
                                BusPhone = "(281) 392-4900",
                                Url = "www.cincotireandauto.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Bellevue Auto Service & Electric Inc",
                                BusAddr = "14320 NE 21st St, Bellevue, WA 98007",
                                BusPhone = "(425)747-6800",
                                Url = "www.bellevueauto.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Jeff's Autohaus",
                                BusAddr = "14121 NE 24th St, Bellevue, WA 98007",
                                BusPhone = "(425)644-7100",
                                Url = "www.jeffsauto.com",
                                NumRecos = 14,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Firestone Complete Auto Care",
                                BusAddr = "2299 140th Ave NE, Bellevue, WA 98005",
                                BusPhone = "(425)429-7446",
                                Url = "www.firestonecompleteautocare.com",
                                NumRecos = 7,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Moving Genius Movers",
                                BusAddr = "4031 FM 1463 #40, Katy, TX 77494",
                                BusPhone = "(832) 571-5876",
                                Url = "www.movinggenius.com",
                                NumRecos = 7,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Baby Huey's Moving",
                                BusAddr = "11511 Gaston Rd #102, Katy, TX 77494",
                                BusPhone = "(281) 492-6683",
                                Url = "www.babyhueysmoving.com",
                                NumRecos = 2,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Square Cow Movers Katy",
                                BusAddr = "22239 Katy Fwy, Katy, TX 77494",
                                BusPhone = "(832) 437-8511",
                                Url = "www.squarecowmovers.com",
                                NumRecos = 4,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Movers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Driver's Auto Repair - Katy Farm Market",
                                BusAddr = "5959 FM 1463, Katy, TX 77494",
                                BusPhone = "(281) 377-3741",
                                Url = "driversautorepairkaty.com",
                                NumRecos = 2,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Fulshear Car Care",
                                BusAddr = "30200 Front St, Fulshear, TX 77441",
                                BusPhone = "(281) 346-2404",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Auto Repair")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Value Pet Care",
                                BusAddr = "6734 Westheimer Lakes N Dr #105, Katy, TX 77494",
                                BusPhone = "(281) 398-2776",
                                Url = "valuepetcare.vet",
                                NumRecos = 3,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "The WellPet Center",
                                BusAddr = "5910 FM 1463, Katy, TX 77494",
                                BusPhone = "(281) 394-2355",
                                Url = "thewellpetcenter.com",
                                NumRecos = 4,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Banfield Pet Hospital",
                                BusAddr = "5574 W Grand Pkwy S, Richmond, TX 77406",
                                BusPhone = "(281) 344-0127",
                                Url = "banfield.com",
                                NumRecos = 7,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Jim's Ultra Clean Inc",
                                BusAddr = "15100 SE 38th St, Bellevue, WA 98006",
                                BusPhone = "(425) 830-1235",
                                Url = "www.jimsultraclean.wix.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "D. A. Burns",
                                BusAddr = "13830 Bel-Red Rd, Bellevue, WA 98005",
                                BusPhone = "(206) 782-2268",
                                Url = "www.daburns.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "D & M Carpet Cleaning",
                                BusAddr = "1431 Sand Lake Ln, Richmond, TX 77407",
                                BusPhone = "(281) 568-1490",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Clean As A Whistle",
                                BusAddr = "808 Park 2 Dr, Sugar Land, TX 77478",
                                BusPhone = "(713) 784-4648",
                                Url="cleanasawhistlehouston.com",
                                NumRecos = 4,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "R & R Steam Clean",
                                BusAddr = "5006 Rollingstone Rd, Richmond, TX 77407",
                                BusPhone = "(281) 818-1333",
                                Url="rrsteamclean.com",
                                NumRecos = 4,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Bellevue Pro Carpet Cleaners",
                                BusAddr = "4109 163rd Ave SE, Bellevue, WA 98006",
                                BusPhone = "(206)779-6843",
                                Url="www.carpetcleanersbellevue.com",
                                NumRecos = 6,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Carpet Cleaners")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "NW Electric And Solar",
                                BusAddr = "4044 23rd Ave W, Seattle, WA 98199",
                                BusPhone = "206-257-1678",
                                Url = "www.nwelectricandsolar.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Button Plumbing and Heating",
                                BusAddr = "15027 130th Ave SE, Renton, WA 98058",
                                BusPhone = "425-271-4289",
                                Url = "www.buttonplumbingco.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Crazy George Plumbing",
                                BusAddr = "4817, Fm. 359 Road, Richmond, TX 77406",
                                BusPhone = "(281) 667-7672",
                                Url = "www.crazygeorgeplumbing.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "C E Anderson Inc",
                                BusAddr = "1638 McCrary Rd, Richmond, TX 77406",
                                BusPhone = "(281) 499-8664",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                BusinessName = "Scofield Plumbing Co",
                                BusAddr = "6219 Cheridan Cir, Richmond, TX 77406",
                                BusPhone = "(281) 344-0900",
                                NumRecos = 2,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Wagly Lake Hills Pet Campus",
                                BusAddr= "639 156th Ave SE, Bellevue, WA 98007",
                                BusPhone = "(425) 529-5459",
                                Url = "www.wagly.com",
                                NumRecos = 2,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Companion Animal Hospital",
                                BusAddr= "1827 156th Ave NE, Bellevue, WA 98007",
                                BusPhone = "425-746-1800",
                                Url = "www.companionbellevue.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },

                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "Aerowood Animal Hospital",
                                BusAddr= "2975 156th Ave SE, Bellevue, WA 98007",
                                BusPhone = "425-746-6557",
                                Url= "www.aerowoodanimalhospital.com",
                                NumRecos = 0,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Veterinarians")).Id
                            },
                            new Recommendation
                            {
                                UserId = (db.Users.FirstOrDefault(u => u.FirstName == "Deepa")).Id,
                                BusinessName = "TM Plumbing, LLC",
                                BusAddr= "15712 NE 1st Pl, Bellevue, WA 98008",
                                BusPhone = "(206)465-6222",
                                Url= "www.tmplumb.com",
                                NumRecos = 3,
                                CategoryId = (db.Categories.FirstOrDefault(c=>c.Name == "Plumbers")).Id
                            }
                };

                db.Recommendations.AddRange(recommendations);
                db.SaveChanges();
            }
        }
    }
}