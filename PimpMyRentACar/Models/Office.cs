using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRentACar.Models
{
    public class Office
    {
        
        public Office()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
