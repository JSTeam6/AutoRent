using Models;
using Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service.Contracts
{
    public interface ICarServices
    {
        Car Create();

        Car Find();


    }
}
