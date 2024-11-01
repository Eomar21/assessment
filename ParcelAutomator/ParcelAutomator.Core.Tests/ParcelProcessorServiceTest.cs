using ParcelAutomator.Core.Departments;
using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.Core.Tests

{
    public class Tests
    {
        private Parcel m_Parcel;
        private IParcelProcessorService m_ParcelProcessorService;

        [SetUp]
        public void Setup()
        {
            m_ParcelProcessorService = new ParcelProcessorService();
            m_Parcel = new()
            {
                Weight = 50,
                Value = 1000,
                Receipient = new Receipient()
                {
                    Name = "Someone",
                    Address = new Address()
                    {
                        City = "Rotterdam",
                        Street = "Street",
                        HouseNumber = 21,
                        PostalCode = "2233TT",
                    }
                }
            };
        }

        [Test]
        public void ParcelMoreThan10KShouldGoToHeavyDepartment()
        {
            m_Parcel.Weight = 50;
            m_ParcelProcessorService.ProcessParcel(m_Parcel);
            if (m_Parcel.DepartmentsAbleToHandle.FirstOrDefault() != Department.Heavy)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void ParcelLessThan1KShouldGoToMailDepartment()
        {
            m_Parcel.Weight = 0.8;
            m_ParcelProcessorService.ProcessParcel(m_Parcel);
            if (m_Parcel.DepartmentsAbleToHandle.FirstOrDefault() != Department.Mail)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void ParcelEqual1KShouldGoToMailDepartment()
        {
            m_Parcel.Weight = 1;
            m_ParcelProcessorService.ProcessParcel(m_Parcel);
            if (m_Parcel.DepartmentsAbleToHandle.FirstOrDefault() != Department.Mail)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void ParcelLessThan10KButMoreThan1ShouldGoToRegularDepartment()
        {
            m_Parcel.Weight = 9;
            m_ParcelProcessorService.ProcessParcel(m_Parcel);
            if (m_Parcel.DepartmentsAbleToHandle.FirstOrDefault() != Department.Regualr)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void ParcelEqual10ShouldGoToRegularDepartment()
        {
            m_Parcel.Weight = 10;
            m_ParcelProcessorService.ProcessParcel(m_Parcel);
            if (m_Parcel.DepartmentsAbleToHandle.FirstOrDefault() != Department.Regualr)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}