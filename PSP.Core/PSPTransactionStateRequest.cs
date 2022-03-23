using System;

namespace PSP.Core
{
    public class PSPTransactionStateRequest
    {
        public Guid TransactionId { get; set; }
        public string Data { get; set; }
    }
}