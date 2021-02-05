using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FullRESTAPI.Models.EFModels;

namespace FullRESTAPI.Context
{
    public class ApplicationDBContex:DbContext
    {
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFCategorie> Categories { get; set; }
        public DbSet<EFCategoriesLists> CategoriesLists { get; set; }
        public DbSet<EFJars> Jars { get; set; }
        public DbSet<EFNotificationLists> NotificationLists { get; set; }
        public DbSet<EFNotification> Notifications { get; set; }
        public DbSet<EFShoppingElement> ShoppingElements { get; set; }
        public DbSet<EFTransaction> Transactions { get; set; }

        public ApplicationDBContex(DbContextOptions<ApplicationDBContex> options) : base(options)
        {
            ;
        }
    }
}
