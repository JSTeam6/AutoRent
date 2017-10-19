using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Contracts
{
    public interface IOrderComposer
    {
        int CarId { get; set; }

        User User { get; set; }
    }
}
