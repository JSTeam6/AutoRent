<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using Models.Contracts;
using System.Collections.Generic;
>>>>>>> z
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
<<<<<<< HEAD
    public class Office
=======
    public class Office : IOffice
>>>>>>> z
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
