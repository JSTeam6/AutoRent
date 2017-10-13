using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRentACar
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string PIN { get; set; } //PersonalIdentityNumber

        [Required]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Status { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }

}