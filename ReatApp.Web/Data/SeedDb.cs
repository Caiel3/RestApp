using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data.Entities;
using ReatApp.Web.Helpers;
using RestApp.Common.Entities;
using RestApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Data
{
    public class SeedDbf
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDbf(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Andres", "Carmona", "andrescarmonapipe@gmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.RestaurantAdmin.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());


                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }







    }

    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Andres", "Carmona", "andrescarmonapipe@gmail.com", "322 311 4620", "Tricentenario", UserType.Admin);
            await CheckUserAsync("2020", "Alejandro", "Martinez", "didier1997@hotmail.es", "322 311 4510", "Enciso", UserType.Admin);
            await CheckUserAsync("3030", "Admin", "Restaurant 1", "adminrestaurant1@yopmail.com", "322 311 4510", "Tricentenario", UserType.RestaurantAdmin);
            await CheckUserAsync("4040", "Admin", "Restaurant 2", "adminrestaurant2@yopmail.com", "322 311 4510", "Santo Domingo", UserType.RestaurantAdmin);
            await CheckUserAsync("5050", "Admin", "Restaurant 3", "adminrestaurant3@yopmail.com", "322 311 4510", "Laureles", UserType.RestaurantAdmin);
            await CheckUserAsync("6060", "Admin", "Restaurant 4", "adminrestaurant4@yopmail.com", "322 311 4510", "Acevedo", UserType.RestaurantAdmin);
            await CheckUserAsync("7070", "user", "1", "user1@yopmail.com", "322 311 4510", "San Pedro", UserType.User);
            await CheckUserAsync("8080", "user", "2", "user2@yopmail.com", "322 311 4510", "sabaneta", UserType.User);

            await CheckRestaurantsAsync();
            await CheckPointSaleAsync();
        }

        private async Task CheckPointSaleAsync()
        {
            if (!_context.PointSale.Any())
            {
                User user1 = await _userHelper.GetUserAsync("adminrestaurant1@yopmail.com");
                User user2 = await _userHelper.GetUserAsync("adminrestaurant2@yopmail.com");
                User user3 = await _userHelper.GetUserAsync("adminrestaurant3@yopmail.com");
                User user4 = await _userHelper.GetUserAsync("adminrestaurant4@yopmail.com");

                Restaurant mcDonalds = await _context.Restaurants.FirstOrDefaultAsync(c => c.Name == "Mc Donalds");
                Restaurant KFC = await _context.Restaurants.FirstOrDefaultAsync(c => c.Name == "KFC");
                Restaurant starbucks = await _context.Restaurants.FirstOrDefaultAsync(c => c.Name == "Starbucks");
                Restaurant subway = await _context.Restaurants.FirstOrDefaultAsync(c => c.Name == "Subway");
                string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris gravida, nunc vel tristique cursus, velit nibh pulvinar enim, non pulvinar lorem leo eget felis. Proin suscipit dignissim nisl, at elementum justo laoreet sed. In tortor nibh, auctor quis est gravida, blandit elementum nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Integer placerat nisi dui, id rutrum nisi viverra at. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque sodales sollicitudin tempor. Fusce volutpat, purus sit amet placerat gravida, est magna gravida risus, a ultricies augue magna vel dolor. Fusce egestas venenatis velit, a ultrices purus aliquet sed. Morbi lacinia purus sit amet nisi vulputate mollis. Praesent in volutpat tortor. Etiam ac enim id ligula rutrum semper. Sed mattis erat sed condimentum congue. Vestibulum consequat tristique consectetur. Nunc in lorem in sapien vestibulum aliquet a vel leo.";

                await AddPointSaleAsync(mcDonalds, lorem, "Mc Donalds Tricentenario", "Tricentenario", 6.2936, -75.5642 , new string[] { "tricentenario1", "tricentenario2" }, user1);
                await AddPointSaleAsync(mcDonalds, lorem, "Mc Donalds santodomingo", "santodomingo", 6.2992, -75.5439, new string[] { "santodomingo1", "santodomingo2" }, user1);

                await AddPointSaleAsync(KFC, lorem, "KFC Enciso", "Enciso", 6.2495, -75.5525, new string[] { "enciso1", "enciso2" }, user2);
                await AddPointSaleAsync(KFC, lorem, "KFC La 30", "La 30", 6.2236, -75.5705, new string[] { "la301", "la302" }, user2);

                await AddPointSaleAsync(starbucks, lorem, "Starbucks Sabaneta", "Sabaneta", 6.1566, -75.6103, new string[] { "sabaneta1", "sabaneta2" }, user3);
                await AddPointSaleAsync(starbucks, lorem, "Starbucks Laureles", "Laureles", 6.2547, -75.5872, new string[] { "laureles1", "laureles2" }, user3);

                await AddPointSaleAsync(subway, lorem, "Subway Acevedo", "Acevedo", 6.3004, -75.5585, new string[] { "acevedo1", "acevedo2" }, user4);
                await AddPointSaleAsync(subway, lorem, "Subway Madera", "Madera", 6.3087, -75.5573, new string[] { "madera1", "madera2" }, user4);



                await _context.SaveChangesAsync();
            }
        }

        private async Task AddPointSaleAsync(Restaurant restaurant, string description, string name, string address, double latitude, double longitude, string[] images, User user)
        {
            PointSale pointSale = new PointSale
            {
                Restaurant = restaurant,
                Description = description,
                Name = name,
                Address = address,
                Tables = 10,
                HourStart = new TimeSpan(2),
                HourFinish = new TimeSpan(4),
                Latitude = latitude,
                Longitude = longitude,
                CatalogueImage = new List<Catalogue>(),
                Qualifications = GetRandomQualifications(description, user)
            };

            foreach (string image in images)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images", $"{image}.png");
                Guid imageId = await _blobHelper.UploadBlobAsync(path, "products");
                pointSale.CatalogueImage.Add(new Catalogue { ImageId = imageId });
            }

            _context.PointSale.Add(pointSale);
        }


        private ICollection<Qualification> GetRandomQualifications(string description, User user)
        {
            List<Qualification> qualifications = new List<Qualification>();
            for (int i = 0; i < 10; i++)
            {
                qualifications.Add(new Qualification
                {
                    Date = DateTime.UtcNow,
                    Remarks = description,
                    Score = _random.Next(1, 5),
                    User = user
                });
            }

            return qualifications;
        }

        private async Task CheckRestaurantsAsync()
        {
            if (!_context.Restaurants.Any())
            {
                await AddRestaurantAsync("Mc Donalds");
                await AddRestaurantAsync("KFC");
                await AddRestaurantAsync("Starbucks");
                await AddRestaurantAsync("Subway");
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddRestaurantAsync(string name)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images", $"{name}.png");
            Guid imageId = await _blobHelper.UploadBlobAsync(path, "categories");
            _context.Restaurants.Add(new Restaurant { Name = name, ImageId = imageId });
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.RestaurantAdmin.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

       
               
        
    }

}
