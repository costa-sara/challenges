using Kenbi.Domain.Models;

namespace Kenbi.Domain.Interfaces.Application
{
    public interface IChallengeAppService
    {
        bool EncryptAndSaveData(Challenge rawData);
    }
}
