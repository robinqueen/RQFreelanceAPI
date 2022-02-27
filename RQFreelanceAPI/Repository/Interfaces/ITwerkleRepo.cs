using RQFreelanceAPI.Models;

namespace RQFreelanceAPI.Repository.Interfaces
{
    public interface ITwerkleRepo
    {
        public Task<string> GetWordOfDay();
        public Task<string> GetRandomWord();
    }
}
