using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiAgent.Interactions
{
    public interface IInteractionsRepo
    {
        public Task<string> GetResponse(string prompt);
    }
}
