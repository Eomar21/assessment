using ParcelAutomator.Core.Interface;
using System.Xml.Linq;

namespace ParcelAutomator.Core
{
    internal class ParcelReader : IParcelReader
    {
        public List<Parcel> Read(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            var parcels = new List<Parcel>();
            foreach (var element in doc.Descendants("Parcel"))
            {
                var addressElement = element.Element("Receipient")?.Element("Address");
                parcels.Add(new Parcel
                {
                    Weight = double.Parse(element.Element("Weight")?.Value ?? "0.0"),
                    Value = double.Parse(element.Element("Value")?.Value ?? "0.0"),
                    Receipient = new Receipient
                    {
                        Name = element.Element("Receipient")?.Element("Name")?.Value ?? string.Empty,
                        Address = new Address
                        {
                            Street = addressElement?.Element("Street")?.Value ?? string.Empty,
                            City = addressElement?.Element("City")?.Value ?? string.Empty,
                            PostalCode = addressElement?.Element("PostalCode")?.Value ?? string.Empty,
                            HouseNumber = int.Parse(addressElement?.Element("HouseNumber")?.Value ?? "0")
                        }
                    }
                }
                );
            }

            return parcels;
        }
    }
}