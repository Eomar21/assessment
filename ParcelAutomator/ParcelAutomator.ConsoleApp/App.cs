using ParcelAutomator.Core;
using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.ConsoleApp
{
    public class App
    {
        private IParcelReader ParcelReader;
        public IParcelProcessorService ParcelProcessorService;

        public App(IParcelProcessorService parcelProcessorService, IParcelReader parcelReader)
        {
            ParcelProcessorService = parcelProcessorService;
            ParcelReader = parcelReader;
        }

        public void Run()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Files", "Container_68465468.xml");

            var parcels = ParcelReader.Read(filePath);

            parcels.ForEach(ParcelProcessorService.ProcessParcel);
            Console.WriteLine("----------------------------------------");
            foreach (var item in parcels)
            {
                Console.WriteLine($"Item Value : {item.Value.ToString()}");
                Console.WriteLine($"Item Weight : {item.Weight.ToString()}");
                Console.WriteLine($"Item Receipient Name : {item.Receipient.Name}");
                Console.WriteLine($"Item City : {item.Receipient.Address.City}");
                Console.WriteLine($"Item needs signing : {item.NeedsSigning}");
                Console.WriteLine($"Item needs signing : {item.NeedsSigning.ToString()}");
                Console.WriteLine($"Item needs signing : {item.NeedsSigning.ToString()}");
                Console.WriteLine($"Department to Handle : {item.DepartmentsAbleToHandle.First()}");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}