using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Common
{
    public class MyEnumClass
    {
    }
    public enum HttpVerb
    {
        NotSupported = -1,
        Get,
        Post,
        Put,
        Delete,
        Head,
        Options
    }

}