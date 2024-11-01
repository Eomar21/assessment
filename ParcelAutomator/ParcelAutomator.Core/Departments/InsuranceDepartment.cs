using ParcelAutomator.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelAutomator.Core.Departments
{
    internal class InsuranceDepartment : IBaseParcelHandler
    {
        public void Handle(Parcel parcel)
        {
            if (parcel.Value > 1000)
            {
                parcel.NeedsSigning = true;
            }
        }
    }
}
