namespace PSP.Core
{
    public interface IProviderTransactionStateHandler
    {
        public PSPStateCommand Command { get;  }
        public void Load(dynamic configuration);
        public IProviderTransactionState Execute(IProviderTransactionState request);
    }
}