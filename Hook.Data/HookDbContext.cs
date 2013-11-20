using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Hook.Model;
using Hook.Data;
using Hook.Data.DbInit;

namespace Hook.Data
{
    public class HookDbContext : DbContext
    {
        // ToDo: Move Initializer to Global.asax; don't want dependence on SampleData
        static HookDbContext()
        {
            Database.SetInitializer(new HookDatabaseInitializer());
        }

        public HookDbContext()
            : base(nameOrConnectionString: "Hook") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Connection> Requests { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}