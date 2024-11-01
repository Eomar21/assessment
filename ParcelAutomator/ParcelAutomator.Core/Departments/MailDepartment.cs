using ParcelAutomator.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelAutomator.Core.Departments
{
    internal class MailDepartment : IBaseParcelHandler
    {
        public void Handle(Parcel parcel)
        {
            if (parcel.Weight <= 1)
            {
                parcel.DepartmentsAbleToHandle.Add(Department.Mail);
            }
        }
    }
}
