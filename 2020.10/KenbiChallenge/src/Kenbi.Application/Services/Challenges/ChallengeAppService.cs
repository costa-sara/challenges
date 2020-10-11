using Kenbi.Application.Helpers;
using Kenbi.Domain.Dao;
using Kenbi.Domain.Dto;
using Kenbi.Domain.Models;
using Kenbi.Domain.Interfaces.Application;
using Kenbi.Domain.Interfaces.Repository;
using System;

namespace Kenbi.Application.Services.Challenges
{
    public class ChallengeAppService : IChallengeAppService
    {
        private readonly IChallengeRepository _challengeRepository;

        public ChallengeAppService(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        public bool EncryptAndSaveData(Challenge rawData)
        {

            return _challengeRepository.SaveData(
                    new ChallengeDao()
                    {
                        Input = rawData.Input,
                        Output = CryptHelper.ComputeSha256Hash(rawData.Input),
                        Username = rawData.Username,
                        CreatedAt = DateTime.UtcNow.ToString()
                    }
                );
        }

    }

}
