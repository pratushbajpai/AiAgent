using AIAgentAppSvc.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace AIAgentAppSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly ILogger<ActionsController> _logger;
        public ActionsController(ILogger<ActionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionContract> Get(Kernel kernel, [FromQuery] string prompt)
        {
            if (kernel == null) throw new ArgumentNullException(nameof(kernel), "Can not be null");

            var response = await kernel.InvokePromptAsync<string>(prompt);
            return new ActionContract()
            {
                Response = $" Reponse for {prompt} : {response}" 
            };
        }
    }
}
