using CleverBitCodingTask.Data.Entities;
using CleverBitCodingTask.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleverBitCodingTask.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<GameMatch> GameMatches { get; set; }
        public DbSet<GameMatchParticipant> GameMatchParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GameMatch>(gameMatch => {
                gameMatch.HasKey(m => m.Id);

                gameMatch.HasOne(m => m.Winner)
                        .WithOne()
                        .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GameMatchParticipant>(gameMatchParticipant => {
                gameMatchParticipant.HasKey(p => new { p.GameMatchId, p.ParticipantId});

                gameMatchParticipant.HasOne(m => m.Participant)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
