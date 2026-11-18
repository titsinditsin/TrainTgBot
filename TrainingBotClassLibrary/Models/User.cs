using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TrainingBotClassLibrary
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("tg_id")]
        public long TgId { get; set; }
        [Column("username")]
        public string? UserName { get; set; }
    }
}