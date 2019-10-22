using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Codigo { get; set; }

        public string  Description { get; set; }

        public Decimal Price { get; set; }
    }
}
