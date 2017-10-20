using Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string FamilyName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The {0} must be at least 10 characters long")]
        [MaxLength(10, ErrorMessage = "The {0} must be maximum 10 characters long")]
        public string PIN { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The {0} must be at least 10 characters long")]
        [MaxLength(10, ErrorMessage = "The {0} must be maximum 10 characters long")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The {0} must be at least 10 characters long")]
        [MaxLength(15, ErrorMessage = "The {0} must be maximum 15 characters long")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}