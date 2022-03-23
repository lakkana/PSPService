namespace PSP.Core
{
    public interface IProviderRequest
    {
        public PSPStateCommand Command { get; set; }
        public PSPRequest Request { get; set; }
        public PSPResponse Response { get; set; }
        public PSPErrorContext ErrorContext { get; set; }
    }
}