using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpProjectV3.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CSharpProjectV3.DAL
{
    //Located Context and Initializer in a separate "Data Access Layer" folder for navigation and cleanliness reasons.

    public class DaylilyContext : DbContext
    {
        public DaylilyContext() : base("DaylilyContext")
        {
        }

        public DbSet<Daylily> Daylilies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Stops database from making table names plural.  Optional, but I chose to do it this way to avoid confusion.

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}