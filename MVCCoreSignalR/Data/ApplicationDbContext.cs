using FastDostavka.Data.Configurations;
using FastDostavka.Data.Entities.IdentityUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data
{
    public class ApplicationDbContext : IdentityDbContext<DbUser, DbRole, int, IdentityUserClaim<int>,
   DbUserRole, IdentityUserLogin<int>,
   IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<UserReceiver> UserReceivers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DbUserConfiguration());
            builder.ApplyConfiguration(new DbUserRoleConfiguration());
            builder.ApplyConfiguration(new DbRoleConfiguration());
            builder.Entity<UserReceiver>(userReceiver =>
            {
                userReceiver.HasKey(ur => new { ur.UserId, ur.MessageId });

                userReceiver.HasOne(ur => ur.Message)
                    .WithMany(r => r.UserReceivers)
                    .HasForeignKey(ur => ur.MessageId)
                    .IsRequired();

                userReceiver.HasOne(ur => ur.User)
                    .WithMany(r => r.UserReceivers)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
