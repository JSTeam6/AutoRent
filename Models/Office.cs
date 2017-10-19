using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Office
    {
        public Office()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = false)]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum 20 characters long")]
        public string City { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum 20 characters long")]
        public string OfficeName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} must be maximum 50 characters long")]
        public string Address { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
