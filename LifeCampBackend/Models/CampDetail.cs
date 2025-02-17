using System.ComponentModel.DataAnnotations;

namespace LifeCamp.Models
{
    public class CampDetail
    {
        [Key]
        public long Id { get; set; }
        public string CampName { get; set; }
        public string CampImage { get; set; }
        public int CampType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string OrganizerId { get; set; }
        public int IsDeleted { get; set; }
        public int Status { get; set; }
        public long UserLoginId { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedOn { get; set; } = DateTime.UtcNow;
    }
}
