using CleverBitCodingTask.Data.Entities;
using CleverBitCodingTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleverBitCodingTask.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class GameMatchController : ControllerBase
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IGameMatchService gameMatchService;

        public GameMatchController(ICurrentUserService currentUserService, IGameMatchService gameMatchService)
        {
            this.currentUserService = currentUserService;
            this.gameMatchService = gameMatchService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<GameMatch>> GetPastMatches()
        {
            return await gameMatchService.GetPastMatches();
        }

        [HttpPost]
        public async Task<int> Play()
        {
            return await gameMatchService.Play(currentUserService.UserId);
        }

        [HttpGet]
        public async Task<int> GetCurrentMatchPlayerScore()
        {
            return await gameMatchService.GetCurrentMatchPlayerScore(currentUserService.UserId);
        }
    }
}
