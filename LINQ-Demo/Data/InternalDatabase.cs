using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LINQ_Demo.Data
{
    public class InternalDatabase
    {
        private static readonly Random Random = new Random();
        private readonly Collection<Customer> customers;
        private readonly Collection<Order> orders;
        private readonly Collection<Product> products;

        public InternalDatabase()
        {
            customers = new Collection<Customer>
            {
                new Customer {id = 10, name = "Bram"},
                new Customer {id = 11, name = "Steven"},
                new Customer {id = 12, name = "Pieter"},
                new Customer {id = 13, name = "Marten"},
                new Customer {id = 14, name = "Tomas"},
                new Customer {id = 15, name = "Martijn"},
                new Customer {id = 16, name = "Glenn"},
                new Customer {id = 17, name = "Daan"},
                new Customer {id = 18, name = "Chris"},
                new Customer {id = 19, name = "Roy"},
                new Customer {id = 20, name = "Joep"},
                new Customer {id = 21, name = "Jesse"},
                new Customer {id = 22, name = "Michael"},
                new Customer {id = 23, name = "Wouter"},
                new Customer {id = 24, name = "Stefan"}
            };

            orders = new Collection<Order>
            {
                new Order {id = 10, customer_id = 10, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 11, customer_id = 11, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 12, customer_id = 12, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 13, customer_id = 13, product_ids = new List<int> {Random.Next(30, 50), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 14, customer_id = 14, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 15, customer_id = 15, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 16, customer_id = 16, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 17, customer_id = 17, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 18, customer_id = 18, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 19, customer_id = 19, product_ids = new List<int> {Random.Next(30, 50), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 20, customer_id = 20, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 21, customer_id = 21, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 22, customer_id = 22, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 23, customer_id = 23, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
                new Order {id = 24, customer_id = 24, product_ids = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, total_price = Random.Next(100, 800), discount = 0, shipping_cost = 5},
            };

            products = new Collection<Product>
            {
                new Product {id = 10, description = "Nvidia Geforce GTX 660", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 11, description = "Nvidia Geforce GTX 670", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 12, description = "Nvidia Geforce GTX 680", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 13, description = "Nvidia Geforce GTX 690", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 14, description = "Nvidia Geforce GTX 760", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 15, description = "Nvidia Geforce GTX 770", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 16, description = "Nvidia Geforce GTX 780", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 17, description = "Nvidia Geforce GTX 860", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 18, description = "Nvidia Geforce GTX 870", price = Random.Next(100, 200), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 19, description = "Nvidia Geforce GTX 880", price = Random.Next(200, 300), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 20, description = "Nvidia Geforce GTX 960", price = Random.Next(200, 300), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 21, description = "Nvidia Geforce GTX 970", price = Random.Next(200, 250), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 22, description = "Nvidia Geforce GTX 980", price = Random.Next(200, 250), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 23, description = "Nvidia Geforce GTX 1060", price = Random.Next(250, 300), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
                new Product {id = 24, description = "Nvidia Geforce GTX 1070", price = Random.Next(300, 400), in_stock = Random.Next(100), amount_clicks = Random.Next(10000), amount_purchased = Random.Next(1000)},
            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers ?? throw new NullReferenceException();
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders ?? throw new NullReferenceException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return products ?? throw new NullReferenceException();
        }
    }
}
