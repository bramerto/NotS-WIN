using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LINQ_Demo.Data
{
    public static class InternalDatabase
    {
        private static readonly Random Random = new Random();

        public static IEnumerable<Customer> GetCustomers()
        {
            return new Collection<Customer>
            {
                new Customer {id = 1, name = "Bram"},
                new Customer {id = 2, name = "Steven"},
                new Customer {id = 3, name = "Pieter"},
                new Customer {id = 4, name = "Marten"},
                new Customer {id = 5, name = "Tomas"},
                new Customer {id = 6, name = "Martijn"},
                new Customer {id = 7, name = "Glenn"},
                new Customer {id = 8, name = "Daan"},
                new Customer {id = 9, name = "Chris"},
                new Customer {id = 10, name = "Roy"},
                new Customer {id = 11, name = "Joep"},
                new Customer {id = 12, name = "Jesse"},
                new Customer {id = 13, name = "Michael"},
                new Customer {id = 14, name = "Wouter"},
                new Customer {id = 15, name = "Stefan"}
            };
        }

        public static IEnumerable<Order> GetOrders()
        {
            return new Collection<Order>
            {
                new Order {id = 1, customer_id = 1, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 2, customer_id = 2, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 3, customer_id = 3, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 4, customer_id = 4, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 5, customer_id = 5, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 6, customer_id = 6, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 7, customer_id = 7, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 8, customer_id = 8, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 9, customer_id = 9, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 10, customer_id = 10, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 11, customer_id = 11, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 12, customer_id = 12, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 13, customer_id = 13, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 14, customer_id = 14, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
                new Order {id = 15, customer_id = 15, product_ids = new List<int> {Random.Next(15), Random.Next(15) }, total_price = 15, discount = 0, shipping_cost = 5},
            };
        }

        public static IEnumerable<Product> GetProducts()
        {
            return new Collection<Product>
            {
                new Product {id = 1, name = "Nvidia Geforce GTX 660", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 2, name = "Nvidia Geforce GTX 670", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 3, name = "Nvidia Geforce GTX 680", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 4, name = "Nvidia Geforce GTX 690", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 5, name = "Nvidia Geforce GTX 760", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 6, name = "Nvidia Geforce GTX 770", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 7, name = "Nvidia Geforce GTX 780", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 8, name = "Nvidia Geforce GTX 860", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 9, name = "Nvidia Geforce GTX 870", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 10, name = "Nvidia Geforce GTX 880", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 11, name = "Nvidia Geforce GTX 960", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 12, name = "Nvidia Geforce GTX 970", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 13, name = "Nvidia Geforce GTX 980", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 14, name = "Nvidia Geforce GTX 1060", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 15, name = "Nvidia Geforce GTX 1070", price = 5, in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
            };
        }
    }
}
