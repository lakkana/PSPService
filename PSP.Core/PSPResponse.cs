using System;

namespace PSP.Core
{
    public class PSPResponse
    {
        public Guid TransactionId { get; set; }
        public string Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}