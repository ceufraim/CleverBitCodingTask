using CleverBitCodingTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverBitCodingTask.Data.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext ctx;

        public DataSeeder(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task Seed()
        {
            await SeedGameMatches();
        }

        private async Task SeedGameMatches()
        {
            if(ctx.GameMatches.Count() == 0)
            {
                DateTime expiresAt = DateTime.Now.AddHours(1);
                var newGameMatchList = new List<GameMatch>();
                for (int i = 0; i < 10; i++)
                {
                    newGameMatchList.Add(new GameMatch()
                    {
                        ExpiresAt = expiresAt
                    });
                    expiresAt = expiresAt.AddHours(1);
                }

                ctx.GameMatches.AddRange(newGameMatchList);

                await ctx.SaveChangesAsync();
            }
        }
    }
}
