using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Utility.Error
{
    public static class ExceptionExtension
    {
        public static bool Handled(this Exception exception, Func<Exception, bool> predicate)
        {
            if (exception is AggregateException)
            {
                return ((AggregateException)exception).Flatten().InnerExceptions.Any(predicate);
            }

            if (exception?.InnerException != null)
            {
                return predicate(exception.InnerException);
            }

            return predicate(exception);
        }
    }
}