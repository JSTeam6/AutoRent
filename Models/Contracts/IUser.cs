using Models.Enum;
using System.Collections.Generic;

namespace Models.Contracts
{
    public interface IUser
    {
        string FirstName { get; set; }

        string FamilyName { get; set; }

        string PIN { get; set; }

        string DrivingLicenseNumber { get; set; }

        string PhoneNumber { get; set; }

        UserStatus Status { get; set; }

        ICollection<Order> Orders { get; set; }
    }
}
