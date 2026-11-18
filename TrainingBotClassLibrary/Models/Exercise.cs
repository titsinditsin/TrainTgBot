using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TrainingBotClassLibrary
{
    [Table("exercise")]
    public class Exercise
    {
        [Key]
        [Column("ex_id")]
        public int ExId { get; set; }
        [Column("muscle_group")]
        public string? MuscleGroup { get; set; }
        [Column("ex_name")]
        public string? ExName { get; set; }
    } 
}