using Models;
using System;

namespace Client.Core.Contracts
{
    public interface IOrderComposer
    {
        Car SelectedCar { get; set; }

        User SelectedUser { get; set; }

        Office DestinationOffice { get; set; }

        DateTime DepartureDate { get; set; }

        int Duration { get; set; }
    }
}
