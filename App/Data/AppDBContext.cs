using Microsoft.EntityFrameworkCore;


namespace App.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Workout> Workout { get; set; }
    public DbSet<WorkoutMuscle> WorkoutMuscle { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workout>()
            .HasMany(c => c.WorkoutMuscle)
            .WithOne(e => e.Workout)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<Workout>()
            .Navigation(b => b.WorkoutMuscle)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        
    }
}