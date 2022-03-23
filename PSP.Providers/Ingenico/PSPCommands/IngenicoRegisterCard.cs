using PSP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP.Providers.Ingenico.PSPCommands
{
    public class IngenicoRegisterCard : IProviderCommand
    {
        public PSPCommand Command { get { return PSPCommand.Register; } }
        protected IngenicoConfiguration Configuration {get; set;}

        public IProviderRequest Execute(IProviderRequest request)
        {

            // do Provider Specific BL
            request.Response = new PSPResponse();
            request.Response.Data = $"Registered - Loaded configuration : {Configuration.ConfigDataX}";
            return request;
        }

        public void Load(dynamic configuration)
        {
            Configuration = (IngenicoConfiguration)configuration;
        }
    }
}
