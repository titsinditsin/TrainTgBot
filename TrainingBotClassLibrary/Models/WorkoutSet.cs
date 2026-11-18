using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TrainingBotClassLibrary
{
    [Table("workout_set")]
    public class WorkoutSet
    {
        [Column("set_id")]
        public int SetId { get; set; }
        [Column("tr_id")]
        public int TrId { get; set; }
        [Column("ex_id")]
        public int ExId { get; set; }
        [Column("weight")]
        public int Weight { get; set; }
        [Column("times")]
        public int Times { get; set; }
        [ForeignKey("ExId")]
        [JsonIgnore]
        public Exercise Exercise { get; set; } = null!;


        [ForeignKey("TrId")]
        [JsonIgnore]
        public Training Training { get; set; } = null!;
    }
}