using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChoosingBot.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var context = scopeServiceProvider.GetService<SqliteContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                Seed(context);
            }
        }

        private static void Seed(SqliteContext context)
        {
            if (context.RestaurantLists.Any())
                return;

            List<RestaurantList> restaurantNames = new List<RestaurantList>()
            {
                new RestaurantList() { RestaurantName = "德克斯", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "鴨肉飯", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "雞肉飯", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "甜不辣", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "甘泉魚麵", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "牛樂麵", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "早餐店", Area = Area.WuxingStreat},
                new RestaurantList() { RestaurantName = "八方雲集", Area = Area.WuxingStreat}
            };

            foreach (var item in restaurantNames)
                context.RestaurantLists.Add(item);

            context.SaveChanges();
        }
    }
}