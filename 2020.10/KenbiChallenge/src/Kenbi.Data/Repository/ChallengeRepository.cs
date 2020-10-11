using Kenbi.Domain.Dao;
using Kenbi.Domain.Interfaces.Repository;
using Npgsql;

namespace Kenbi.Data.Repository
{
    public class ChallengeRepository: IChallengeRepository
    {
       
        public ChallengeRepository()
        {
        }

        public bool SaveData(ChallengeDao challengeDao)
        {
            // PostgeSQL-style connection string
            string connstring = "Server=db-challenge-herzsache.c9cjyugmuuhc.eu-central-1.rds.amazonaws.com; Port=5432; Database=core; User Id=postgres; Password=u1gdVLPKQjDtmEaPS1Jo;";
            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();


            string sql = "INSERT INTO public.challenge(input, output, username, createdat)" +
                         $"VALUES('{challengeDao.Input}', '{challengeDao.Output}', '{challengeDao.Username}', '{challengeDao.CreatedAt}');";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            // data adapter making request from our connection
            var rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 0)
                return false;

            return true;
        }

  
    }
}
