using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Entity
{
    public class RequestOrder:orderrecord
    {
        public List<orderlist> olist { get; set; }

    }
}
