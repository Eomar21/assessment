using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.Core.Tests
{
    public class ParcelReaderTest
    {
        private IParcelReader m_ParcelReader;

        [SetUp]
        public void Setup()
        {
            m_ParcelReader = new ParcelReader();
        }

        [Test]
        public void ReadAndMakeSureTheyAre17()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "TestFiles", "Container_68465468.xml");

            var parcels = m_ParcelReader.Read(filePath);
            if (parcels.Count != 17)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ReadAndMakeSureTheyAreNotNull()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "TestFiles", "Container_68465468.xml");

            var parcels = m_ParcelReader.Read(filePath);
            parcels.ForEach(x =>
            {
                Assert.That(x.DepartmentsAbleToHandle, Is.Not.Null);
                Assert.That(x.Value, Is.TypeOf(typeof(double)));
                Assert.That(x.Weight, Is.TypeOf(typeof(double)));
                // Check on all properties
                // etc....
            });
        }
    }
}

