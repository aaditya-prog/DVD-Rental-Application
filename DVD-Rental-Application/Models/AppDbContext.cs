using Microsoft.EntityFrameworkCore;
namespace DVD_Rental_Application.Models
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<User> users { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Studio> studios { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<MembershipCategory> membershipcategories { get; set; }
        public DbSet<LoanType> loantypes { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<DVDCopy> dvdcopies { get; set; }
        public DbSet<DVDTitle> dvdtitles { get; set; }
        public DbSet<DVDCategory> dvdcategories { get; set; }
        public DbSet<CastMember> castmembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CastMember>().HasNoKey();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
