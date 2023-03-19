using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour.Models
{
    public class TourContext:DbContext
    {
        public TourContext() : base("name=TourConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Adminstrators> Administrators { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Attrations> Attrations { get; set; }
    }
}