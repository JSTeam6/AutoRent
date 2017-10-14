using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Models
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
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
