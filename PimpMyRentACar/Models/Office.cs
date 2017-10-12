using System;
using System.Collections.Generic;
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
        public virtual City City {get;set;}
        public int? CityId { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Car> Cars { get; set; } // we first ask for a city, then we foreach the offices and display
        //the type of cars available

    }
}
