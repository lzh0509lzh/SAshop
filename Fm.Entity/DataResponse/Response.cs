using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fm.Entity
{
    [Serializable]
    public class DataResponse_ProductInfo : BaseDataResponse
    {
        public List<Fm.Entity.product_info> List { get; set; }
    }
}
