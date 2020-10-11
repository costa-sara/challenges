using Kenbi.Domain.Dao;

namespace Kenbi.Domain.Interfaces.Repository
{
    public interface IChallengeRepository
    {
        bool SaveData(ChallengeDao challengeDao);
    }
}
