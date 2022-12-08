using GoGreenApi.Data.Mappings;
using GoGreenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoGreenApi.Data
{
    public class GoGreenDbContext : DbContext
    {
        public GoGreenDbContext(DbContextOptions<GoGreenDbContext> options) : base(options)
        {
        }
        public DbSet<CompanyModel> Companys { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SchedulingModel> Schedulings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SchedulingMapping());

            base.OnModelCreating(modelBuilder);
        }
    }


}
