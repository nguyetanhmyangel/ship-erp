﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShipErp.Core.Domain.Contracts;
using ShipErp.Core.Domain.Entities;
using ShipErp.Core.Domain.Identity;

namespace ShipErp.Infrastructure.Contexts;
public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ////All Decimals will have 18,2 Range
        //foreach (var property in builder.Model.GetEntityTypes()
        //.SelectMany(t => t.GetProperties())
        //.Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        //{
        //    property.SetColumnType("decimal(18,2)");
        //}
        //base.OnModelCreating(builder);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
        .HasKey(x => x.Id);

        builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

        builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
        .HasKey(x => new { x.RoleId, x.UserId });

        builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
           .HasKey(x => new { x.UserId });
    }

    //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //var entries = ChangeTracker
    //    .Entries()
    //    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

    //foreach (var entityEntry in entries)
    //{
    //    var dateCreatedProp = entityEntry.Entity.GetType().GetProperty("CreatedAt");
    //    if (entityEntry.State == EntityState.Added
    //        && dateCreatedProp != null)
    //    {
    //        dateCreatedProp.SetValue(entityEntry.Entity, DateTime.Now);
    //    }
    //    var modifiedDateProp = entityEntry.Entity.GetType().GetProperty("LastUpdateAt");
    //    if (entityEntry.State == EntityState.Modified
    //        && modifiedDateProp != null)
    //    {
    //        modifiedDateProp.SetValue(entityEntry.Entity, DateTime.Now);
    //    }
    //}
    //OnBeforeSaving();
    //return await base.SaveChangesAsync(cancellationToken);
    //}

    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //    OnBeforeSaving();
    //    return  base.SaveChangesAsync(cancellationToken);
    //}


    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.Entity is IAuditableEntity trackable)
            {
                var now = DateTime.UtcNow;
                //var user = GetCurrentUser();
                switch (entry.State)
                {
                    case EntityState.Modified:
                        trackable.LastUpdatedAt = now;
                        //trackable.LastUpdatedBy = user;
                        break;

                    case EntityState.Added:
                        trackable.CreatedAt = now;
                        //trackable.CreatedBy = user;                     
                        break;
                }
            }
        }
    }
}
