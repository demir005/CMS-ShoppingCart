using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSShoppingCard.Models.Data
{
    public class Db : DbContext
    {
        public DbSet<PageDTO> Pages { get; set; }

        public DbSet<SlidebarDTO> Slidebar { get; set; }

        public DbSet<CategoryDTO> Categories { get; set; }

        public DbSet<ProductDTO> Products { get; set; }

        public DbSet<UserDTO> Users { get; set; }

        public DbSet<RoleDTO> Roles { get; set; }

        public DbSet<UserRolesDTO> UserRoles { get; set; }

        public DbSet<OrderDTO> Orders { get; set; }

        public DbSet<OrderDetailsDTO> OrderDetails { get; set; }

    }
}