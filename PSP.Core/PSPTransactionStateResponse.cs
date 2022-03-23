using System;

namespace PSP.Core
{
    public class PSPTransactionStateResponse
    {
        public Guid TransactionId { get; set; }
        public string Data { get; set; }
    }
}