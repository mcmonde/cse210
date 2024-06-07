namespace Foundation2;


class Order
{
    private List<Product> _products;
    private Customer _customer;
    private double _shippingCost;

    public Order(Customer customer)
    {
        this._customer = customer;
        _products = new List<Product>();
        _shippingCost = customer.IsInUSA() ? 5 : 35;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.GetTotalCost();
        }
        return totalPrice + _shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"Name: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Name: {_customer.GetName()}\nAddress: {_customer.GetAddress().GetFullAddress()}";
    }
}