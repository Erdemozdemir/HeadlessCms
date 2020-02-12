using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdufaceCms.DataAccessLayer
{
    public class DatabaseContext : IdentityDbContext<UserEntity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Eduface;Integrated Security=True;Connect Timeout=30;Encrypt=False;", opt => opt.MigrationsAssembly("EdufaceCms.UI"));

            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-TMUOCV4\\SQLEXPRESS;Initial Catalog=Eduface;User Id=perdemM5_Eduface;Password=8426159753;", opt => opt.MigrationsAssembly("EdufaceCms.UI"));


            optionsBuilder.UseSqlServer("Data Source=http://hostsql1.isimtescil.net;Initial Catalog=perdemM5_eduace;User Id=perdemM5_erdemo;Password=8426159753Ee.;Connect Timeout=30;Encrypt=False;", opt => opt.MigrationsAssembly("EdufaceCms.UI"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentEntity>()
                .HasOne(X => X.City)
                .WithOne()
                .IsRequired();


            builder.Entity<StudentEntity>()
                .HasOne(X => X.County)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentEntity>()
                .HasOne(X => X.Branch)
                .WithOne()
                .IsRequired();

            builder.Entity<GuarantorEntity>()
                .HasOne(X => X.City)
                .WithOne()
                .IsRequired();


            builder.Entity<GuarantorEntity>()
                .HasOne(X => X.County)
                .WithOne()
                .IsRequired();

            builder.Entity<GuarantorEntity>()
                .HasOne(X => X.Student)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentEducationEntity>()
                .HasOne(X => X.Student)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentEducationEntity>()
                .HasOne(X => X.Time)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentEducationEntity>()
                .HasOne(X => X.Level)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentEducationEntity>()
                .HasOne(X => X.Education)
                .WithOne()
                .IsRequired();


            builder.Entity<StudentPaymentEntity>()
                .HasOne(X => X.Student)
                .WithOne()
                .IsRequired();

            builder.Entity<StudentPaymentEntity>()
                .HasOne(X => X.PaymentType)
                .WithOne()
                .IsRequired();

            builder.Entity<PreRegisterEntity>()
                .HasOne(X => X.DataQuality)
                .WithOne()
                .IsRequired();
            builder.Entity<PreRegisterEntity>()
                .HasOne(X => X.DataSource)
                .WithOne()
                .IsRequired();
            builder.Entity<PreRegisterEntity>()
                .HasOne(X => X.Level)
                .WithOne()
                .IsRequired();

            builder.Entity<PreRegisterEntity>()
                .HasOne(X => X.Time)
                .WithOne()
                .IsRequired();
            builder.Entity<PreRegisterEntity>()
                .HasOne(X => X.PaymentType)
                .WithOne()
                .IsRequired();
        }

        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CountyEntity> Counties { get; set; }
        public DbSet<DataQualityEntity> DataQualities { get; set; }
        public DbSet<DataSourceEntity> DataSources { get; set; }
        public DbSet<EducationEntity> Educations { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentEducationEntity> StudentEducations { get; set; }
        public DbSet<StudentPaymentEntity> StudentPayments { get; set; }
        public DbSet<GuarantorEntity> Guarantors { get; set; }
        public DbSet<LevelEntity> Levels { get; set; }
        public DbSet<LogEntity> Log { get; set; }
        public DbSet<PaymentTypeEntity> PaymentTypes { get; set; }
        public DbSet<PreRegisterEntity> PreRegisterEntities { get; set; }
        public DbSet<PriceEntity> Prices { get; set; }
        public DbSet<TimeEntity> Times { get; set; }
    }
}
