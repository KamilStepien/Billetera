using FullRESTAPI.Context;
using FullRESTAPI.Models.EFModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models
{
    public static class SeedData
    {
        public static void SeedDataDB(IApplicationBuilder app)
        {
            ApplicationDBContex context = app.ApplicationServices.GetRequiredService<ApplicationDBContex>();

            context.Database.Migrate();

            if (!context.CategoriesLists.Any())
            {
                context.CategoriesLists.Add(
                    new EFCategoriesLists
                    {
                        Name = "jar"
                    });
                context.SaveChanges();
                context.CategoriesLists.Add(
                    new EFCategoriesLists
                    {
                        Name = "home"
                    });
                context.SaveChanges();
                context.CategoriesLists.Add(
                    new EFCategoriesLists
                    {
                        Name = "expenses"
                    });
                context.SaveChanges();
                context.CategoriesLists.Add(
                   new EFCategoriesLists
                    {
                        Name = "income"
                    }
                    );

                context.SaveChanges();
            }


            if (!context.NotificationLists.Any())
            {
                context.NotificationLists.Add(
                   new EFNotificationLists
                   {
                       Title = "Hi",
                       Description = "Billetera"
                   });
                context.SaveChanges();
                context.NotificationLists.Add(
                new EFNotificationLists
                {
                    Title = "Jars",
                    Description = "You have completed 1 goal"
                });
                context.SaveChanges();
                context.NotificationLists.Add(
                     new EFNotificationLists
                     {
                         Title = "Jars",
                         Description = "You have completed 5 goal"
                     });
                context.SaveChanges();
                context.NotificationLists.Add(
                     new EFNotificationLists
                     {
                         Title = "Jars",
                         Description = "You have completed 10 goal"
                     }
                    );

                context.SaveChanges();
            }
        }

     
    }
}
