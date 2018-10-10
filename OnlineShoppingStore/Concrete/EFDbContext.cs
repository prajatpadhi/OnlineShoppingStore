using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Concrete
{
    public class EFDbContext:IdentityDbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<LoginModel> login { get; set; }
        

        public EFDbContext():base("name=EFDbContext")
        {
               
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}