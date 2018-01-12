using SaAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAPI.Models
{
    public interface IAuthenticateManager
    {
        Task AuthenticateAsync(RequestContext context);
    }
}
