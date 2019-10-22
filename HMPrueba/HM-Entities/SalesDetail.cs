using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Entities
{
    public class SalesDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public string Codigo { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
