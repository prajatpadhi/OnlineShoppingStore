namespace OnlineShoppingStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using OnlineShoppingStore.App_Start;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShoppingStore.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShoppingStore.Concrete.EFDbContext context)
        {
            PasswordHasher hasher = new PasswordHasher();
            context.Users.AddOrUpdate(u => u.UserName, new ApplicationUser() { UserName="prajatpadhi",
            Id="prajatpadhi",PasswordHash=hasher.HashPassword("password")});
        }
    }
}
