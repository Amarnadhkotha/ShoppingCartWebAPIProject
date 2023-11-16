using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartProject.Models
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Product> Products
        {
            get;
            set;
        }

        public DbSet<Cart> Cart
        {
            get;
            set;
        }

    }
}
