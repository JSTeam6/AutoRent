using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRentACar.Models
{
    public class City
    {
        
        public City()
        {
            this.Offices = new HashSet<Office>();
        }

        public int Id { get; set; }

        public string CityName { get; set; }
        
        public virtual ICollection<Office> Offices { get; set; }
    }
}
