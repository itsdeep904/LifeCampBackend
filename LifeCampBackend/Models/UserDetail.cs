using System.ComponentModel.DataAnnotations;

namespace LifeCamp.Models
{
    public class UserDetail
    {
        [Key]
        public long Id { get; set; }
        public long UserloginId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public int RoleType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedOn { get; set; } = DateTime.UtcNow;
    }
}
