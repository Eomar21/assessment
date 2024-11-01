using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelAutomator.Core.Interface
{
    public interface IParcelReader
    {
        List<Parcel> Read(string filePath);
    }
}
