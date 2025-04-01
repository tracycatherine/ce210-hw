using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private double _shippingCost;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;
    }

    public Customer Customer { get { return _customer; } set { _customer = value; } }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double TotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.TotalCost();
        }
        total += _shippingCost;
        return total;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.CustomerAddress.FullAddress()}\n";
    }
}