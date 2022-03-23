namespace PSP.Core
{
    public interface IProviderTransactionState
    {
        public PSPStateCommand Command { get; }
        public PSPTransactionStateRequest Request { get; set; }
        public PSPTransactionStateResponse Response { get; set; }
        public PSPErrorContext ErrorContext { get; set; }
    }
}