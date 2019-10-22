using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Entities
{
    public class Sales
    {
        public int SaleId { get; set; }
        public string Rif { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public decimal Saldo { get; set; }
    }
}
