using ParcelAutomator.API.Controllers;
using ParcelAutomator.Core;

namespace ParcelAutomator.API
{
    public static class ParcelDtoExtension
    {

        public static ParcelDto ToDto(this Parcel parcel)
        {
            return new ParcelDto()
            {
                City = parcel.Receipient.Address.City,
                NeedsSigning = parcel.NeedsSigning,
                Value = parcel.Value,
                Weight = parcel.Weight,
                Department = parcel.DepartmentsAbleToHandle.FirstOrDefault().ToString() ?? "",
            };
        }
    }
}
