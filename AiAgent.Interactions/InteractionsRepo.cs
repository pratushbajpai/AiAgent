using Azure.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace AiAgent.Interactions
{
    public class InteractionsRepo : IInteractionsRepo
    {
        readonly Kernel kernel;

        public InteractionsRepo(string endpoint, string deployment, ILogger logger)
        {
            kernel = Kernel
            .CreateBuilder()
            .AddAzureOpenAIChatCompletion(
            deployment,
            endpoint,
            new DefaultAzureCredential())
            .Build();
        }

        /// <summary>
        /// Get prompt response
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> GetResponse(string prompt)
        {
            string response = kernel.InvokePromptAsync(prompt).Result.ToString();
            return response;
        }
    }
}
