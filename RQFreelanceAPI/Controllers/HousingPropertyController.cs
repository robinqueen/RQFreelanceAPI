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

        [HttpGet("GetAllHousingPropertiesTest")]
        public async Task<List<HousingProperty>> GetAllHousingPropertiesTest()
        {
            HousingProperty p1 = new HousingProperty();
            p1.ID = 1;
            p1.AddressLine1 = "Test1 ";


            HousingProperty p2 = new HousingProperty();
            p1.ID = 1;
            p1.AddressLine1 = "Test1 ";

            List<HousingProperty> l = new List<HousingProperty>();
            l.Add(p1);
            l.Add(p2);
            return l;
        }

        [HttpGet("GetAllHousingProperties")]
        public async Task<List<HousingProperty>> GetAllHousingProperties()
        {
            List<HousingProperty> res = new List<HousingProperty>();
            try
            {
                res = await _housingPropertyRepo.GetHousingProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
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