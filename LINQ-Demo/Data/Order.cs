using System.Collections.Generic;

namespace LINQ_Demo.Data
{
    public class Order
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public List<int> product_ids { get; set; }
        public double total_price { get; set; }
        public double discount { get; set; }
        public double shipping_cost { get; set; }
    }
}