using SaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaAPI.Context
{
    public class ServiceContext
    {
        private static ServiceContext _instance;
        private static readonly object ObjectLocker = new object();

        public static ServiceContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (ObjectLocker)
                    {
                        if (_instance == null)
                        {
                            _instance = new ServiceContext();
                        }
                    }
                }
                return _instance;
            }
        }

        private ServiceContext()
        {
        }

        public IAuthenticateManager AuthenticateManager { get; set; }

        //public IAuthorizationManager AuthorizationManager { get; set; }

        //public IQuotaClient QuotaClient { get; set; }

        //public IFirewallManager FirewallManager { get; set; }
    }
}