using Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Management.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskRequiredAction> TaskRequiredActions { get; set; }
        public DbSet<TaskDocument> TaskDocuments { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(e => e.RoleId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.UserId });
                entity.Property(e => e.IsManager).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Priority).IsRequired().HasConversion<string>();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.Property(e => e.DueDate).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
                entity.HasOne(e => e.Team)
                      .WithMany(t => t.Tasks)
                      .HasForeignKey(e => e.TeamId);
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.UserId });
                entity.Property(e => e.AssignedAt).IsRequired();
                entity.HasOne(e => e.Task)
                      .WithMany(t => t.TaskAssignments)
                      .HasForeignKey(e => e.TaskId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.TaskAssignments)
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<TaskRequiredAction>(entity =>
            {
                entity.HasKey(e => e.ActionId);
                entity.Property(e => e.ActionType).IsRequired().HasConversion<string>();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.Property(e => e.DueDate).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
                entity.HasOne(e => e.Task)
                      .WithMany(t => t.RequiredActions)
                      .HasForeignKey(e => e.TaskId);
            });

            modelBuilder.Entity<TaskDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId);
                entity.Property(e => e.Data).IsRequired();
                entity.Property(e => e.UploadedBy).IsRequired();
                entity.Property(e => e.ActionId).IsRequired();
                entity.HasOne(td => td.Action).WithMany(ta => ta.Documents).HasForeignKey(td => td.ActionId);
                entity.HasOne(td => td.UploadedByUser).WithMany(u => u.TaskDocuments).HasForeignKey(td => td.UploadedBy);
            });

            modelBuilder.Entity<TaskNote>(entity =>
            {
                entity.HasKey(e => e.NoteId);
                entity.Property(e => e.NoteText).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne(e => e.RequiredAction).WithMany().HasForeignKey(e => e.ActionId);
            });
        }
    }
}
