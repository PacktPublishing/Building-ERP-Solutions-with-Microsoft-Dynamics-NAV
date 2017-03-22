using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NAVAzureServiceBus.Classes
{
    [DataContract]
    class ShopSalesOrderLine
    {
        [DataMember]
        public int RowNo { get; set; }

        [DataMember]
        public string ItemNo { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }
    }
}
