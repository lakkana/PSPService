using PSP.Core;
using PSP.Providers.Ingenico;
using System.Collections.Generic;
using System.Linq;

namespace PSP.Service
{
    public class ProviderFactory
    {
        /// <summary>
        /// Load All the configured IProviders from Service Collicetion 
        /// don't Register Providers the way I have done here
        /// </summary>
        public ProviderFactory()
        {
            RegisterProviders();
        }

        protected List<IProvider> Providers { get; set; }
        private void RegisterProviders()
        {
            Providers = new List<IProvider>();

            Providers.Add(new IngenicoProvider());
        }

        public IProvider Get(string ProviderName)
        {
            return Providers.First(p => p.ProviderName.ToLowerInvariant() == ProviderName.ToLowerInvariant());
        }
    }
}
