using System;
using System.Collections;
using System.Collections.Generic;

namespace CleverBitCodingTask.Data.Entities
{
    public class GameMatch
    {
        public int Id { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int? WinnerId { get; set; }
        public GameMatchParticipant Winner { get; set; }
    }
}