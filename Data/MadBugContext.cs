using IdentityServer4.EntityFramework.Options;
using MadBugAPI.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MadBugAPI.Data
{
    public class MadBugContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public MadBugContext(DbContextOptions<MadBugContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);
        }
    }
}