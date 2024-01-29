using Development.Assesment.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace Development.Assesment.Data.Context
{
    public class AssesmentContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public AssesmentContext(DbContextOptions<AssesmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithMany(g => g.Users);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Permissions)
                .WithMany(p => p.Groups);

            //modelBuilder.Entity<UserGroup>().HasNoKey();

            //modelBuilder.Entity<GroupPermission>().HasNoKey();

            //// Seed dummy data for the User entity
            //modelBuilder.Entity<User>().HasData(
            //    new User { UserId = 1, UserName = "JohnDoe", Email = "john.doe@example.com" },
            //    new User { UserId = 2, UserName = "JaneDoe", Email = "jane.doe@example.com" }
            //// Add more users as needed
            //);

            //// Seed dummy data for the Group entity
            //modelBuilder.Entity<Group>().HasData(
            //    new Group { GroupId = 1, GroupName = "GroupA", GroupDescription = "Description for GroupA" },
            //    new Group { GroupId = 2, GroupName = "GroupB", GroupDescription = "Description for GroupB" }
            //// Add more groups as needed
            //);

            //// Seed dummy data for the Permission entity
            //modelBuilder.Entity<Permission>().HasData(
            //    new Permission { PermissionId = 1, PermissionName = "PermissionA", PermissionDescription = "Description for PermissionA" },
            //    new Permission { PermissionId = 2, PermissionName = "PermissionB", PermissionDescription = "Description for PermissionB" }
            //// Add more permissions as needed
            //);

            //// Seed dummy data for the junction table UserGroup
            //modelBuilder.Entity<UserGroup>().HasData(
            //    new UserGroup {  UserId = 1, GroupId = 1 },
            //    new UserGroup {  UserId = 2, GroupId = 2 }
            //// Add more associations as needed
            //);

            //// Seed dummy data for the junction table GroupPermission
            //modelBuilder.Entity<GroupPermission>().HasData(
            //    new GroupPermission {  GroupId = 1, PermissionId = 1 },
            //    new GroupPermission {  GroupId = 2, PermissionId = 2 }
            //// Add more associations as needed
            //);

            base.OnModelCreating(modelBuilder);
        }
    }
}
