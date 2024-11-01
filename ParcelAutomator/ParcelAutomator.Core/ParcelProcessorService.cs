using ParcelAutomator.Core.Departments;
using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.Core
{
    internal class ParcelProcessorService : IParcelProcessorService
    {
        private readonly List<IBaseParcelHandler> m_ParcelHandlers;

        public ParcelProcessorService()
        {
            m_ParcelHandlers = new List<IBaseParcelHandler>()
            {
                new HeavyDepartment(),
                new InsuranceDepartment(),
                new MailDepartment(),
                new RegularDepartment(),
            };
        }

        public void ProcessParcel(Parcel parcel)
        {
            m_ParcelHandlers.ForEach(x => x.Handle(parcel));
        }
    }
}