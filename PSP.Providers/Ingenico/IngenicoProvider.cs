using PSP.Core;
using PSP.Providers.Ingenico.PSPCommands;
using PSP.Providers.Ingenico.PSPStateCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP.Providers.Ingenico
{
    public class IngenicoProvider : IProvider
    {
        public IngenicoProvider()
        {
            RegisterCommands();
            RegisterTransactionStateHandlers();
        }

        protected IngenicoConfiguration Configuration { get; set; }
        private List<IProviderCommand> providerCommands { get; set; }

        private List<IProviderTransactionStateHandler> transactionStateHandlers { get; set; }
        public string ProviderName { get => "Ingenico"; }

        /// <summary>
        /// get the configuration Json from DB and deserialise at the provider level (note : this is not the resposibility of the caller, this is provider specific logic)
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public void Load(string configuration)
        {
            Configuration  =  System.Text.Json.JsonSerializer.Deserialize<IngenicoConfiguration>(configuration);
        }

        /// <summary>
        /// Create a Base Provider habe it implemented there 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IProviderCommand LoadOperation(PSPCommand command)
        {
            var op =  providerCommands.First(c => c.Command == command);
            op.Load(Configuration);

            return op;
        }

        /// <summary>
        /// Create a Base Provider habe it implemented there 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IProviderTransactionStateHandler LoadTransactionStateHandler(PSPStateCommand command)
        {
            var op =  transactionStateHandlers.First(c => c.Command == command);
            op.Load(Configuration);

            return op;
        }

        //either this way or using service collection (this way is nicer than manullay register)
        private void RegisterCommands()
        {
            if (providerCommands == null)
                providerCommands = new List<IProviderCommand>();

            providerCommands.Add(new IngenicoRegisterCard());
            providerCommands.Add(new IngenicoMakePayment());
        }

        //either this way or using service collection (this way is nicer than manullay register)
        private void RegisterTransactionStateHandlers()
        {
            if (transactionStateHandlers == null)
                transactionStateHandlers = new List<IProviderTransactionStateHandler>();

            transactionStateHandlers.Add(new IngenicoTransactionComplete());
            transactionStateHandlers.Add(new IngenicoTransactionErrored());

        }
    }
}
