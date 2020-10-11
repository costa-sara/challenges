using Kenbi.Application.Helpers;
using Kenbi.Domain.Dto;
using Kenbi.Domain.Models.AppSettings;
using Kenbi.WebSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kenbi.WebSite.Controllers
{
    [Authorize]
    public class ChallengeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiEndpoints _apiEndpoints;

        private readonly IServiceHelper _serviceHelper;
        public ChallengeController(IOptions<ApiEndpoints> apiEndpoints, IHttpClientFactory httpClientFactory, IServiceHelper serviceHelper)
        {
            _apiEndpoints = apiEndpoints?.Value;
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));

            _serviceHelper = serviceHelper;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ApiResultDto<string> unprotectedResp;
            ApiResultDto<string> protectedResp;
            
            unprotectedResp = await _serviceHelper.GetRequest<ApiResultDto<string>>(_apiEndpoints.ClientName, _apiEndpoints.Challenge.GetUnAuth);
            
            protectedResp = await _serviceHelper.GetRequest<ApiResultDto<string>>(_apiEndpoints.ClientName, _apiEndpoints.Challenge.GetAuth);

            if (unprotectedResp == null || protectedResp==null || unprotectedResp?.Error != null || protectedResp?.Error != null)
                return BadRequest();
            
            return View(new ChallengeViewModel()
            {
                UnprotectedData = unprotectedResp.Result,
                ProtectedData= protectedResp.Result
            });
        }
       

        [HttpPost]
        public async Task<IActionResult> EncryptAndSave(ChallengeViewModel challengeViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                challengeViewModel.Success = false;
                return View("Views/Challenge/Index.cshtml", challengeViewModel);
            }
                

            var resp = await _serviceHelper.PostRequest<ChallengeDto, ApiResultDto<string>>(_apiEndpoints.ClientName, _apiEndpoints.Challenge.Post,
                                                                    new ChallengeDto()
                                                                    {
                                                                        Input = challengeViewModel.ProtectedData,
                                                                        Username = HttpContext.User.Identity.Name
                                                                    });

            challengeViewModel.Success = resp?.Error==null;

            return View("Views/Challenge/Index.cshtml", challengeViewModel);
        }


        #region helpers
        private async Task<Dictionary<string,string>> GetAuthorizationHeader(Dictionary<string, string> headers=null)
        {
            headers = headers ?? new Dictionary<string, string>();
            // get the saved identity token
            var identityToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            headers.Add("Authorization", string.Format($"Bearer {identityToken}"));
            return headers;
        }

        #endregion helpers
    }
}
