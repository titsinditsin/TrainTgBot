
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class UserDto
    {
        public long TgId { get; set; }
        public string? UserName { get; set; }
    }
}