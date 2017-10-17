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
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string FamilyName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "PIN should be 10 digits long.")]
        public string PIN { get; set; } //PersonalIdentityNumber

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Driving license number should be 10 digits long.")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number should be at least 10 and maximum 15 digits long.")]
        public string PhoneNumber { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}