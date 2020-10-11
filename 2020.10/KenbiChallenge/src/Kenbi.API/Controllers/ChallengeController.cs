using AutoMapper;
using Kenbi.API.Controllers.Base;
using Kenbi.Domain.Dto;
using Kenbi.Domain.Interfaces.Application;
using Kenbi.Domain.Models;
using Kenbi.Domain.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenbi.API.Controllers
{
    /// <summary>
    /// ChallengeController
    /// </summary>
    [Route("api/challenge")]
    public class ChallengeController: BaseController 
    {
        private readonly IChallengeAppService _challengeAppService;
        private readonly IMapper _mapper;

        /// <summary>
        /// ChallengeController constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="challengeAppService"></param>
        public ChallengeController( IMapper mapper,
                                    IChallengeAppService challengeAppService)
        {
            _challengeAppService = challengeAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get unprotected string 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("unprotected")]
        public ActionResult<ApiResultDto<string>> GetUnprotected()
        {
            var result = new ApiResultDto<string>();

            return result.OK("alive");
        }

        /// <summary>
        /// Get protected string
        /// </summary>
        /// <returns></returns>
        [HttpGet("protected")]
        public ActionResult<ApiResultDto<string>> GetProtected()
        {
            var result = new ApiResultDto<string>();

            return result.OK("unencrypted_value");
        }

        /// <summary>
        /// Encrypts input and saves it in db
        /// </summary>
        /// <param name="challengeDto"></param>
        /// <returns></returns>
        [HttpPost("encrypt")]
        public ActionResult<ApiResultDto<bool>> Post(ChallengeDto challengeDto)
        {
            var result = new ApiResultDto<bool>();

            if (challengeDto == null || string.IsNullOrEmpty(challengeDto.Input))
                result.BadRequestResult(HardCode.Errors.Standard.InvalidObject);

            var response = _challengeAppService.EncryptAndSaveData(_mapper.Map<Challenge>(challengeDto));

            return result.OK(response);
        }

    }
}
