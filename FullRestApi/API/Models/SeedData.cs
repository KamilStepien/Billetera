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
        public static void AddCategoryToDB(IApplicationBuilder app)
        {
            ApplicationDBContex context = app.ApplicationServices.GetRequiredService<ApplicationDBContex>();

            context.Database.Migrate();

            if (!context.CategoriesLists.Any())
            {
                context.CategoriesLists.AddRange(
                    new EFCategoriesLists
                    {
                        Name = "jar"
                    },
                    new EFCategoriesLists
                    {
                        Name = "home"
                    },
                    new EFCategoriesLists
                    {
                        Name = "expenses"
                    },
                    new EFCategoriesLists
                    {
                        Name = "income"
                    }
                    );

                context.SaveChanges();
            }
        }

        public static void AddNotificationToDB(IApplicationBuilder app)
        {
            ApplicationDBContex context = app.ApplicationServices.GetRequiredService<ApplicationDBContex>();

            context.Database.Migrate();

            if (!context.NotificationLists.Any())
            {
                context.NotificationLists.AddRange(
                   new EFNotificationLists
                   {
                       Title = "Hi",
                       Description = "Billetera"
                   },
                    new EFNotificationLists
                    {
                        Title = "Jars",
                        Description = "You have completed 1 goal"
                    },
                     new EFNotificationLists
                     {
                         Title = "Jars",
                         Description = "You have completed 5 goal"
                     },
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
