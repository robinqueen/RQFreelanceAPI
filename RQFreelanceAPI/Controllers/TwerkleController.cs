using Microsoft.AspNetCore.Mvc;
using RQFreelanceAPI.Models;
using RQFreelanceAPI.Repository.Interfaces;

namespace RQFreelanceAPI.Controllers
{
    public class TwerkleController : Controller
    {

        private readonly ILogger<TwerkleController> _logger;
        private readonly ITwerkleRepo _twerkleRepo;

        public TwerkleController(ILogger<TwerkleController> logger, ITwerkleRepo twerkleRepo)
        {
            _logger = logger;
            _twerkleRepo = twerkleRepo;
        }

        [HttpGet("GetTodaysWordOfDay")]
        public async Task<string> GetTodaysWordOfDay()
        {
            string res = "";
            try
            {
                res = await _twerkleRepo.GetWordOfDay();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

    }
}
