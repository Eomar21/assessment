using ParcelAutomator.Core.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelAutomator.Core.Interface
{
    internal interface IBaseParcelHandler
    {
        void Handle(Parcel parcel);
    }
}
