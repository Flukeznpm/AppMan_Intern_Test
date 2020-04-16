using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
             .HasKey(c => c.std_Id);

            modelBuilder.Entity<University>()
             .HasKey(c => c.uni_Id);

            modelBuilder.Entity<StudentinUniversity>().HasKey(sc => new { sc.std_id, sc.uni_id });

            modelBuilder.Entity<StudentinUniversity>()
             .HasOne(pt => pt.Student)
             .WithMany(p => p.StudentinUniversities)
             .HasForeignKey(pt => pt.std_id);

            modelBuilder.Entity<StudentinUniversity>()
             .HasOne(pt => pt.University)
             .WithMany(t => t.StudentinUniversities)
             .HasForeignKey(pt => pt.uni_id);
        }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universitys { get; set; }
        public DbSet<StudentinUniversity> StudentinUniversities { get; set; }

    }
}