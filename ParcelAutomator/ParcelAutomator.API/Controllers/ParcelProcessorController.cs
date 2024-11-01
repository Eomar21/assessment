using Microsoft.AspNetCore.Mvc;
using ParcelAutomator.Core;
using ParcelAutomator.Core.Interface;

namespace ParcelAutomator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelProcessorController : ControllerBase
    {
        private readonly ILogger<ParcelProcessorController> m_Logger;
        private readonly IParcelProcessorService m_ParcelProcessorService;
        private readonly IParcelReader m_ParcelReader;

        public ParcelProcessorController(
            ILogger<ParcelProcessorController> logger,
            IParcelProcessorService parcelProcessorService,
            IParcelReader parcelReader)
        {
            m_Logger = logger;
            m_ParcelProcessorService = parcelProcessorService;
            m_ParcelReader = parcelReader;
        }

        [HttpPost("process")]
        public async Task<ActionResult<IEnumerable<Parcel>>> Post(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            var parcels = await GetParcelsAsync(file);
            if (parcels != null)
            {
                parcels.ForEach(m_ParcelProcessorService.ProcessParcel);
                return parcels;
            }
            return BadRequest("No parcels found");


        }

        [HttpPost("processdto")]
        public async Task<ActionResult<IEnumerable<ParcelDto>>> PostDto(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            var parcels = await GetParcelsAsync(file);
            var parcelDtos = new List<ParcelDto>();

            if (parcels != null)
            {
                parcels.ForEach(x =>
                {
                    m_ParcelProcessorService.ProcessParcel(x);
                    parcelDtos.Add(x.ToDto());
                });
            }
            return parcelDtos;
        }

        private async Task<List<Parcel>> GetParcelsAsync(IFormFile file)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            Directory.CreateDirectory(uploadDirectory);
            var fullPath = Path.Combine(uploadDirectory, file.FileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var parcels = m_ParcelReader.Read(fullPath);
            return parcels;
        }
    }
}
