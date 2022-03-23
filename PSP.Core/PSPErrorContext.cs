using System.Collections;
using System.Collections.Generic;

namespace PSP.Core
{
    public class PSPErrorContext
    {
        public List<PSPError> Errors { get; set; }

        public void AddError(string errorCode, string ErrorMessage)
        {
            if (Errors == null) Errors = new List<PSPError>();

            Errors.Add(new PSPError { ErrorCode = errorCode, ErrorMessage = ErrorMessage });
        }
    }

    public class PSPError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}