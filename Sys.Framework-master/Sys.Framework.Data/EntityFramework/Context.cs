using Sys.Framework.Model.Sys;
using Sys.Framework.Model.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Data.EntityFramework
{
    public class Context : DbContext
    {
        public Context() : base("Robot")
        {
            Database.SetInitializer<Context>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<T_Sys_Accept> T_Sys_Accept { get; set; }
        public DbSet<T_Sys_Business> T_Sys_Business { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Controllers> Controllers { get; set; }
        public DbSet<RoleActions> RoleActions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<WebSites> WebSites { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<View_Authority> View_Authority { get; set; }
    }
}
