using Microsoft.EntityFrameworkCore;

namespace KolosPoprawa.Models;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Language> Languages { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Record> Records { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().ToTable("Language");
        modelBuilder.Entity<Task>().ToTable("Task");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Record>().ToTable("Record");
        
        modelBuilder.Entity<Student>()
            .Property(s => s.Email)
            .HasMaxLength(250);
            
        modelBuilder.Entity<Task>()
            .Property(t => t.Name)
            .HasMaxLength(100);
            
        modelBuilder.Entity<Task>()
            .Property(t => t.Description)
            .HasMaxLength(2000);
            
        modelBuilder.Entity<Language>()
            .Property(l => l.Name)
            .HasMaxLength(100);
            
        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName)
            .HasMaxLength(100);
            
        modelBuilder.Entity<Student>()
            .Property(s => s.LastName)
            .HasMaxLength(100);
        
        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
        
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        /*if (!Languages.Any())
        {
            Languages.Add(new Language()
            {
                Name = "English",
            });
            SaveChanges();
        }

        if (!Records.Any())
        {
            Records.Add(new Record()
            {
                Id = 1,
                LanguageId = 1,
                StudentId = 1,
                
            });
            SaveChanges();
        }*/
    }
}