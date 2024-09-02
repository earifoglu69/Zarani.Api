using Microsoft.AspNetCore.Mvc;

namespace Zarani.Api.Controllers
{
    /// <summary>
    /// Base controller for all other controllers in the application.
    /// </summary>
    /// <typeparam name="T">The type of the derived controller.</typeparam>
    [ApiController, Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase
    {
        private ILogger<T> _log;

        /// <summary>
        /// Gets the logger service.
        /// </summary>
        protected ILogger<T> _logger => _log ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
