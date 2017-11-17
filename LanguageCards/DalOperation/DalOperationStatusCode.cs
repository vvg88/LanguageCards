using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.DalOperation
{
    public enum DalOperationStatusCode
    {
        Error,
        EntityNotFound,
        UserNotFound,
        InnerExceptionOccurred,
    }
}
