using System.Collections.Generic;
using System.Linq;

namespace LINQ_Demo.Data
{
    public class Order
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public IEnumerable<int> product_ids { get; set; }
        public double total_price { get; set; }
        public double discount { get; set; }
        public double shipping_cost { get; set; }

        public int GetFirstProductId()
        {
            return product_ids.ToArray()[0];
        }
    }
}