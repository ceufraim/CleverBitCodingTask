using CleverBitCodingTask.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleverBitCodingTask.Services
{
    public interface IGameMatchService
    {
        Task<IEnumerable<GameMatch>> GetPastMatches();
        Task<int> Play(string participantId);
        Task<int> GetCurrentMatchPlayerScore(string participantId);
    }
}