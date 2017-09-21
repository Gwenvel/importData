using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KraigsList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KraigsListContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }
            
            AddCategories(context);
            AddAds(context);
            AddImages(context);
        }

        private static void AddCategories(KraigsListContext context) 
        {
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "antiques" },
                new Category { CategoryId = 2, Name = "appliances" },
                new Category { CategoryId = 3, Name = "arts+crafts" },
                new Category { CategoryId = 4, Name = "atv/utv/sno" },
                new Category { CategoryId = 5, Name = "auto parts" },
                new Category { CategoryId = 6, Name = "baby+kid" },
                new Category { CategoryId = 7, Name = "barter" },
                new Category { CategoryId = 8, Name = "beauty+hlth" },
                new Category { CategoryId = 9, Name = "bikes" },
                new Category { CategoryId = 10, Name = "boats" },
                new Category { CategoryId = 11, Name = "books" },
                new Category { CategoryId = 12, Name = "business" },
                new Category { CategoryId = 13, Name = "cars+trucks" },
                new Category { CategoryId = 14, Name = "cds/dvd/vhs" },
                new Category { CategoryId = 15, Name = "cell phones" },
                new Category { CategoryId = 16, Name = "clothes+acc" },
                new Category { CategoryId = 17, Name = "collectibles" },
                new Category { CategoryId = 18, Name = "computers" },
                new Category { CategoryId = 19, Name = "electronics" },
                new Category { CategoryId = 20, Name = "farm+garden" },
                new Category { CategoryId = 21, Name = "free" },
                new Category { CategoryId = 22, Name = "furniture" },
                new Category { CategoryId = 23, Name = "garage sale" },
                new Category { CategoryId = 24, Name = "general" },
                new Category { CategoryId = 25, Name = "heavy equip" },
                new Category { CategoryId = 26, Name = "household" },
                new Category { CategoryId = 27, Name = "jewelry" },
                new Category { CategoryId = 28, Name = "materials" },
                new Category { CategoryId = 29, Name = "motorcycles" },
                new Category { CategoryId = 30, Name = "music instr" },
                new Category { CategoryId = 31, Name = "photo+video" },
                new Category { CategoryId = 32, Name = "rvs+camp" },
                new Category { CategoryId = 33, Name = "sporting" },
                new Category { CategoryId = 34, Name = "tickets" },
                new Category { CategoryId = 35, Name = "tools" },
                new Category { CategoryId = 36, Name = "toys+games" },
                new Category { CategoryId = 37, Name = "trailers" },
                new Category { CategoryId = 38, Name = "video gaming" },
                new Category { CategoryId = 39, Name = "wanted" },
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private static void AddAds(KraigsListContext context) 
        {
            var ads = new List<Ad>
            {
                new Ad { 
                    Title = "Phone",
                    Description = "An old iPhone 3",
                    Price = 20.00M,
                    Phone = "555-5555",
                    Timestamp = DateTime.Now,
                    Street = "123 Main",
                    City = "Scottsdale",
                    State = "AZ",
                    Zip = 85255,
                    Email = "test@test.com",
                    ActiveId = "1234",
                    CategoryId = 1
                 },
                new Ad { 
                    Title = "Walkman",
                    Description = "A neat music playing device",
                    Price = 40.00M,
                    Phone = "777-7777",
                    Timestamp = DateTime.Now,
                    Street = "321 Main",
                    City = "Scottsdale",
                    State = "AZ",
                    Zip = 85255,
                    Email = "test@test.com",
                    ActiveId = "4321",
                    CategoryId = 1
                 },
            };

            foreach (var ad in ads)
            {
                context.Ads.Add(ad);
            }

            context.SaveChanges();
        }

        private static void AddImages(KraigsListContext context) 
        {
            var images = new List<Image>
            {
                new Image { 
                    URL = "https://images-na.ssl-images-amazon.com/images/I/41UywapRmbL._SY300_.jpg",
                    IsPrimary = true,
                    AdId = 1
                },
                new Image { 
                    URL = "https://www.imore.com/sites/imore.com/files/styles/larger_wm_blw/public/field/image/2015/08/history-iphone-3g_hero.jpg",
                    IsPrimary = false,
                    AdId = 1
                },
                new Image { 
                    URL = "http://i.telegraph.co.uk/multimedia/archive/01436/walkman1_1436143i.jpg",
                    IsPrimary = true,
                    AdId = 2
                },
                new Image { 
                    URL = "https://cdn.vox-cdn.com/thumbor/H5ssNco7ApcGIWaMga8Z0v189gw=/1020x0/cdn.vox-cdn.com/uploads/chorus_asset/file/2851684/1979_tpsl2_2.1404231268.jpg",
                    IsPrimary = false,
                    AdId = 2
                },
            };

            foreach (var image in images)
            {
                context.Images.Add(image);
            }

            context.SaveChanges();
        }
    }
}
