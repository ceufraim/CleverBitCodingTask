using CleverBitCodingTask.Models;

namespace CleverBitCodingTask.Data.Entities
{
    public class GameMatchParticipant
    {
        public int GameMatchId { get; set; }
        public string ParticipantId { get; set; }
        public decimal ParticipantScore { get; set; }
        public ApplicationUser Participant { get; set; }
    }
}