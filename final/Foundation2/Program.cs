using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product("Laptop", "P001", 999.99, 2);
        Product product2 = new Product("Smartphone", "P002", 499.99, 3);

        // Create customers
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Oak St", "Another Town", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);

        // Display packing labels, shipping labels, and total prices
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 1 Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine();

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 2 Total Price: $" + order2.GetTotalPrice());
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;
    private double shippingCost;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
        shippingCost = customer.IsInUSA() ? 5 : 35;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in products)
        {
            totalPrice += product.GetTotalCost();
        }
        return totalPrice + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"Name: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Name: {customer.GetName()}\nAddress: {customer.GetAddress().GetFullAddress()}";
    }
}
