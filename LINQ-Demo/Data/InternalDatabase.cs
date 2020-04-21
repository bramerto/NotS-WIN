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
                new Customer {Id = 10, Name = "Bram"},
                new Customer {Id = 11, Name = "Steven"},
                new Customer {Id = 12, Name = "Pieter"},
                new Customer {Id = 13, Name = "Marten"},
                new Customer {Id = 14, Name = "Tomas"},
                new Customer {Id = 15, Name = "Martijn"},
                new Customer {Id = 16, Name = "Glenn"},
                new Customer {Id = 17, Name = "Daan"},
                new Customer {Id = 18, Name = "Chris"},
                new Customer {Id = 19, Name = "Roy"},
                new Customer {Id = 20, Name = "Joep"},
                new Customer {Id = 21, Name = "Jesse"},
                new Customer {Id = 22, Name = "Michael"},
                new Customer {Id = 23, Name = "Wouter"},
                new Customer {Id = 24, Name = "Stefan"}
            };

            orders = new Collection<Order>
            {
                new Order {Id = 10, CustomerId = 10, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 11, CustomerId = 11, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 12, CustomerId = 12, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 13, CustomerId = 13, ProductIds = new List<int> {Random.Next(30, 50), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 14, CustomerId = 14, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 15, CustomerId = 15, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 16, CustomerId = 16, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 17, CustomerId = 17, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 18, CustomerId = 18, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 19, CustomerId = 19, ProductIds = new List<int> {Random.Next(30, 50), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 20, CustomerId = 20, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 21, CustomerId = 21, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 22, CustomerId = 22, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 23, CustomerId = 23, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
                new Order {Id = 24, CustomerId = 24, ProductIds = new List<int> {Random.Next(10, 24), Random.Next(10, 24) }, TotalPrice = Random.Next(100, 800), Discount = 0, ShippingCost = Random.Next(1, 7)},
            };

            products = new Collection<Product>
            {
                new Product {Id = 10, Description = "Nvidia Geforce GTX 660", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 11, Description = "Nvidia Geforce GTX 670", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 12, Description = "Nvidia Geforce GTX 680", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 13, Description = "Nvidia Geforce GTX 690", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 14, Description = "Nvidia Geforce GTX 760", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 15, Description = "Nvidia Geforce GTX 770", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 16, Description = "Nvidia Geforce GTX 780", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 17, Description = "Nvidia Geforce GTX 860", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 18, Description = "Nvidia Geforce GTX 870", Price = Random.Next(100, 200), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 19, Description = "Nvidia Geforce GTX 880", Price = Random.Next(200, 300), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 20, Description = "Nvidia Geforce GTX 960", Price = Random.Next(200, 300), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 21, Description = "Nvidia Geforce GTX 970", Price = Random.Next(200, 250), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 22, Description = "Nvidia Geforce GTX 980", Price = Random.Next(200, 250), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 23, Description = "Nvidia Geforce GTX 1060", Price = Random.Next(250, 300), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
                new Product {Id = 24, Description = "Nvidia Geforce GTX 1070", Price = Random.Next(300, 400), InStock = Random.Next(100), AmountClicks = Random.Next(10000), AmountPurchased = Random.Next(1000)},
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
