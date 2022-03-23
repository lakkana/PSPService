using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP.Core
{
    public interface IProvider
    {
        public string ProviderName { get; }
        public void Load(string configuration);
        public IProviderCommand LoadOperation(PSPCommand command);
        public IProviderTransactionStateHandler LoadTransactionStateHandler(PSPStateCommand command); 
    }
}
