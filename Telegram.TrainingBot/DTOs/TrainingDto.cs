
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class TrainingDto
    {
        public int TrId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public long TgId { get; set; }
    }
}