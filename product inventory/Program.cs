using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Product Inventory Project - Create an application which manages an inventory of products. Create a product class which has a price, id, and quantity on hand. Then create an inventory class which keeps track of various products and can sum up the inventory value.
 * Erste Version: 29.08.2013
 */


namespace product_inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory i = new Inventory();
            i.print();
            i.add(new Product("abcde", price: 5.13M, quantity: 10));
            i.add(new Product("abcde", price: 7.12M, quantity: 15));
            i.add(new Product("IBM021302", price: 132321.00M, quantity: 2));
            i.print();
            i.removeStock("abcde", 7);
            i.print();
            i.removeStock("IBM021302", 5);
            i.print();
            Console.ReadKey();
        }
    }

    // Inventory contains a list of Products, the stock
    class Inventory
    {
        List<Product> stock;

        public Inventory(List<Product> stock)
        {
            this.stock = stock;
        }

        public Inventory(): this(new List<Product>())
        {
        }

        // custom output method
        public void print()
        {
            Console.WriteLine("====================\r\nInventory List: {0}",stock.Count());
            foreach (Product p in stock)
            {
                p.print();
            }
            Console.WriteLine("Overall value in stock: {0}EUR", this.getCompleteValue());
            Console.WriteLine("====================");
        }

        // calculate the value of all products, LINQ is nice :)
        public decimal getCompleteValue()
        {
            return stock.Sum(p => (p.price * p.quantity));
        }

        // add a product to stock
        public void add(Product p)
        {
            if (p != null)
            {
                // if the product isn't already in stock, add it to the list
                if (!inInventory(p))
                {
                    stock.Add(p);
                    Console.WriteLine("Added new product: {0}", p.getText());
                }
                // if we already have a product with the same id, update its price and increase quantity
                else
                {
                    Product inStock = stock.Find(prod => prod.Equals(p));
                    inStock.quantity += p.quantity;
                    inStock.price = p.price;
                    Console.WriteLine("Updated product: {0}", inStock.getText());
                }
            }
        }

        // remove items from stock
        public void removeStock(string id, int count)
        {
            Console.WriteLine("Trying to remove {0} of {1}\r\n---------------------------------", count, id);
            // check if we have a product with a matching id
            Product p = stock.Find(prod => prod.id.Equals(id));
            if (p != null)
            {
                // if we have enough product on stock, just remove the wanted quantity
                if (p.quantity >= count)
                {
                    p.quantity -= count;
                    Console.WriteLine("{0} of {1} removed! New stock of {1}: {2}", count, p.id, p.quantity);
                }
                // if we don't have enough of this product, don't do it
                else
                {
                    Console.WriteLine("Insufficient stock! Only {0} of {1} are available!", p.quantity, p.id);
                }
            }
        }

        // check if a product exists in stock - a product equals another one if their ids match
        public bool inInventory(Product p)
        {
            return stock.Exists(prod => prod.Equals(p));
        }
    }

    // simple class to represent products
    // each product has a price, an id and a quantity
    class Product
    {
        public decimal price { get; set; }
        public string id { get; set; }
        public int quantity { get; set; }

        public Product(string id, decimal price = 0.00M, int quantity = 0)
        {
            this.price = price;
            this.id = id;
            this.quantity = quantity;
        }

        // let the product write to the console itself
        public void print()
        {
            Console.WriteLine(this.getText());
        }

        // just return the description of the product
        public string getText()
        {
            return String.Format("{0}: {1}EUR ({2} in stock) | overall value: {3}", this.id, this.price, this.quantity, this.getValueOfProduct());
        }

        // checks, if two products are the same
        // two products are equal if their ids match
        public bool Equals(Product p)
        {
            if (this.id.Equals(p.id))
            {
                return true;
            }
            return false;
        }

        // return the value of all items of this product in stock
        public decimal getValueOfProduct()
        {
            return price * quantity;
        }
    }
}
