
namespace ListProfessionalBlazor.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Work>().HasData(
            new Work { Id = 1, Name = "Home Office" },
            new Work { Id = 2, Name = "Empresa" }
        );

        modelBuilder.Entity<ListProfessional>().HasData(
            new ListProfessional
            {
                Id = 1,
                Name = "João",
                Position = "Gerente",
                Years = "4",
                WorkId = 1
            },
            new ListProfessional
            {
                Id = 2,
                Name = "Maria",
                Position = "Desenvolvedora Sênior",
                Years = "8",
                WorkId = 2
            }
        );

    }

        public DbSet<ListProfessional> ListProfessionals { get; set; }
        public DbSet<Work> Works { get; set; }
}
