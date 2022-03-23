namespace PSP.Core
{
    public interface IProviderCommand
    {
        public PSPCommand Command { get; }
        public void Load(dynamic configuration);
        public IProviderRequest Execute(IProviderRequest request);
    }
}