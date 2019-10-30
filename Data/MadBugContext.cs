using IdentityServer4.EntityFramework.Options;
using MadBugAPI.Data.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MadBugAPI.Data
{
    public class MadBugContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public DbSet<Bug> Bugs { get; set; }
        public MadBugContext(DbContextOptions<MadBugContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bug>(x=>{
                x.HasKey(x=>x.Id);
                x.Property(x=>x.Id).ValueGeneratedOnAdd();
                x.Property(x=>x.Title).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Body).HasMaxLength(500);
                x.Property(x=>x.Severity).IsRequired();
                x.ToTable("Bug");
                //User relationship
                x.HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId);
            });
            
            base.OnModelCreating(builder);
        }
    }
}