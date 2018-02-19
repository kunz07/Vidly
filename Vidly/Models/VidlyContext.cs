﻿using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VidlyContext() : base("name=VidlyContext")
        {
        }

        public System.Data.Entity.DbSet<Vidly.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Vidly.Models.MembershipType> MembershipTypes { get; set; }
    }
}
