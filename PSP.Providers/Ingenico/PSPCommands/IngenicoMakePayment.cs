using PSP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP.Providers.Ingenico.PSPCommands
{
    public class IngenicoMakePayment : IProviderCommand
    {
        public PSPCommand Command { get { return PSPCommand.MakePayment; } }
        protected IngenicoConfiguration Configuration {get; set;}

        public IProviderRequest Execute(IProviderRequest request)
        {

            // do Provider Specific BL
            request.Response = new PSPResponse();
            request.Response.Data = $"Ingenico Make Payment - Loaded configuration : {Configuration.ConfigDataY}";
            return request;
        }

        public void Load(dynamic configuration)
        {
            Configuration = (IngenicoConfiguration)configuration;
        }
    }
}
