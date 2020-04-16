using System;
using System.Collections.Generic;
using LINQ_Demo.Data;

namespace LINQ_Demo
{
    public class SequenceGenerator
    {
        public static InternalDatabase database;

        public static IEnumerable<int> Numbers()
        {
            var index = 0;
            while (index++ < 15)
            {
                yield return index;
            }
        }

        public static IEnumerable<T> Items<T>(Func<T> generator)
        {
            var index = 0;
            while (index++ < 15)
            {
                yield return generator();
            }
        }

        public static IEnumerable<Customer> Customers()
        {
            return database.GetCustomers();
        }

        public static IEnumerable<Order> Orders()
        {
            return database.GetOrders();
        }

        public static IEnumerable<Product> Products()
        {
            return database.GetProducts();
        }
    }
}
