using Microsoft.AspNetCore.Mvc;
using RQFreelanceAPI.Models;
using RQFreelanceAPI.Repository;
using RQFreelanceAPI.Repository.Interfaces;
using System.Reflection;
using System.Text;

namespace RQFreelanceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HousingPropertyController : ControllerBase
    {
        private readonly ILogger<HousingPropertyController> _logger;
        private readonly IHousingPropertyRepo _housingPropertyRepo;

        public HousingPropertyController(ILogger<HousingPropertyController> logger, IHousingPropertyRepo housingPropertyRepo)
        {
            _logger = logger;
            _housingPropertyRepo = housingPropertyRepo;
        }

        [HttpGet("GetAllHousingProperties")]
        public async Task<List<HousingProperty>> GetAllHousingProperties()
        {
            return await _housingPropertyRepo.GetHousingProperties();
        }

        [HttpGet("GetAllHousingPropertiesByPropertyType/{type}")]
        public List<HousingProperty> GetAllHousingPropertiesByPropertyType(string type)
        {
            var housingProperties = GetAllHousingProperties().Result;
            housingProperties = housingProperties.Where(x => x.PropertyType == type).ToList();

            return housingProperties;
        }

       

    }
}