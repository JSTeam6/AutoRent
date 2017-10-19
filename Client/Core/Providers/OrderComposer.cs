using Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Client.Core.Providers
{
    public class OrderComposer : IOrderComposer
    {
        public OrderComposer()
        {

        }

        public int CarId { get; set; }
        public User User { get; set; }
    }
}
