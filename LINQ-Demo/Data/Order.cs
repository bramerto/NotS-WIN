using System.Collections.Generic;
using System.Linq;

namespace LINQ_Demo.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double ShippingCost { get; set; }

        public int GetFirstProductId()
        {
            return ProductIds.ToArray()[0];
        }
    }
}