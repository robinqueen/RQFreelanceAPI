using RQFreelanceAPI.Models;

namespace RQFreelanceAPI.Repository.Interfaces
{
    public interface IHousingPropertyRepo
    {
        public Task<List<HousingProperty>> GetHousingProperties();
    }
}
