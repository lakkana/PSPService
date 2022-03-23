﻿using PSP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP.Providers.Ingenico.PSPStateCommands
{
    public class IngenicoTransactionErrored : IProviderTransactionStateHandler
    {
        protected IngenicoConfiguration Configuration { get; set; }
        public PSPStateCommand Command { get { return PSPStateCommand.Errored; } }

        public IProviderTransactionState Execute(IProviderTransactionState request)
        {
            // do Provider Specific BL
            request.Response = new PSPTransactionStateResponse();
            request.Response.Data = $"Ingenico Transaction Errored - Loaded configuration :{Configuration.ConfigDataX}";
            return request;
        }

        public void Load(dynamic configuration)
        {
            Configuration = (IngenicoConfiguration)configuration;
        }
    }
}
