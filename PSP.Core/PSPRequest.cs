using System;

namespace PSP.Core
{
    public class PSPRequest
    {
        public Guid TransactionId { get; set; }
        public string  Data { get; set; }
    }
}