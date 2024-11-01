using ParcelAutomator.Core.Departments;

namespace ParcelAutomator.Core
{
    public class Parcel
    {
        /// <summary>
        /// Weight in Kilos
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Value in Euros
        /// </summary>
        public double Value { get; set; }
        public required Receipient Receipient { get; set; }
        public Guid Id { get; set; }

        public bool NeedsSigning { get; set; }

        public List<Department> DepartmentsAbleToHandle { get; set; } = new List<Department>();
    }
}