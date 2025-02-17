using System.ComponentModel.DataAnnotations;

namespace LifeCamp.Models
{
    public class UserLogin
    {
        [Key]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Identifier { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedOn { get; set; } = DateTime.UtcNow;
    }
}
