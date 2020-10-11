using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kenbi.API.Controllers.Base
{
    /// <summary>
    /// BaseController
    /// </summary>
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class BaseController : ControllerBase
    {


    }
}
