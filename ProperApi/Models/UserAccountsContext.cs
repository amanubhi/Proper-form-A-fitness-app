using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class UserAccountsContext : DbContext
    {
        public UserAccountsContext(DbContextOptions<UserAccountsContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserInfo> Strings { get; set; }
        public DbSet<UserInfo> EmailExists { get; set; }
        public DbSet<UserInfo> LoginCheck{ get; set; }
        public DbSet<UserInfo> SignupCheck { get; set; }
        public DbSet<UserRoutines> UserRoutines { get; set; }
        public DbSet<NutEntries> NutEntries { get; set; }
        public DbSet<UserNutFull> UserNutFull { get; set; }
        public DbSet<UserNut> UserNut { get; set; }

        public DbSet<WeightHistory> WeightHistory { get; set; }
    }
}
