using CleverBitCodingTask.Data;
using CleverBitCodingTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverBitCodingTask.Services
{
    public class GameMatchService : IGameMatchService
    {
        private readonly ApplicationDbContext ctx;

        public GameMatchService(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<GameMatch>> GetPastMatches()
        {
            return await ctx.GameMatches.Include(x => x.Winner).Where(x => x.ExpiresAt < DateTime.Now).ToListAsync();
        }

        public async Task<int> Play(string participantId)
        {
            var activeGame = ctx.GameMatches.Where(x => x.ExpiresAt > DateTime.Now).OrderBy(x => x.ExpiresAt).FirstOrDefault();
            if (activeGame == null)
                throw new Exception("Cannot find active match");

            var newGameMatchParticipant = new GameMatchParticipant() {
                GameMatchId = activeGame.Id,
                ParticipantId = participantId,
                ParticipantScore = new Random().Next(0, 100)
            };

            ctx.GameMatchParticipants.Add(newGameMatchParticipant);

            await ctx.SaveChangesAsync();

            var currentWinner = ctx.GameMatchParticipants.Where(x => x.GameMatchId == activeGame.Id).OrderByDescending(x => x.ParticipantScore).First();

            activeGame.Winner = currentWinner;

            await ctx.SaveChangesAsync();

            return (int)newGameMatchParticipant.ParticipantScore;
        }

        public async Task<int> GetCurrentMatchPlayerScore(string participantId)
        {
            var activeGame = await ctx.GameMatches.Where(x => x.WinnerId == null).OrderBy(x => x.ExpiresAt).FirstOrDefaultAsync();
            var participantRecord = await ctx.GameMatchParticipants.Where(x => x.ParticipantId == participantId && x.GameMatchId == activeGame.Id).FirstOrDefaultAsync();
            return (int)(participantRecord?.ParticipantScore ?? -1);
        }
    }
}
