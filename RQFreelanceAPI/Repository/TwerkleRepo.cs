

using Dapper;
using RQFreelanceAPI.Models;
using RQFreelanceAPI.Repository.Interfaces;

namespace RQFreelanceAPI.Repository
{
    public class TwerkleRepo : ITwerkleRepo
    {
        private readonly DapperContext _context;
        public TwerkleRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<string> GetWordOfDay()
        {
            string word = "";

            var query = @"SELECT WordOfDay as CorrectAnswer FROM TwerkleWord WHERE cast(DateToUseWord as date) = @Date;";

            using (var connection = _context.CreateConnection())
            {
                word = connection.Query<string>(query, new { Date = DateTime.Now.Date }).FirstOrDefault();
            }


            if (string.IsNullOrEmpty(word))
            {
                Random r = new Random();
                var id = r.Next(1, 13);

                query = @"SELECT WordOfDay as CorrectAnswer FROM TwerkleWord WHERE TwerkeWordID = @Id;";

                using (var connection = _context.CreateConnection())
                {
                    word = connection.Query<string>(query, new { Id = id }).FirstOrDefault();
                }
            }
            return word;



        }

        public async Task<string> GetRandomWord()
        {
            string word = "";

            var query = @"SELECT TOP 1 WordOfDay FROM TwerkleWord ORDER BY NEWID()";

            using (var connection = _context.CreateConnection())
            {
                word = connection.Query<string>(query, new { Date = DateTime.Now.Date }).FirstOrDefault();
            }

            return word;

        }
    }
}
