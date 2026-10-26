using System.Data;

namespace VendorMachine;

public class Product
{
    public Product(string name, decimal price, int quantity, int code) => (Name, Price, Quantity, Code) = (name, price, quantity, code);
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }
    public int Code { get; }

    public void Delivery() => Quantity = Quantity - 1;
}

public class StateMachine
{
    public Product Product { get; }
    public decimal Money { get; }

    public StateMachine(Product product, decimal money) => (Product, Money) = (product, money);

    public bool IsPaidFull() => Money >= Product.Price;
}

public class ProductDelivery
{
    public Product Product { get; }
    public decimal Change { get; }
}

public class VendorMachine
{
    public List<Product> _products = new();
    public decimal _changes { get; }
    public StateMachine _stateMachine { get; }

    public VendorMachine(List<Product> products, decimal changes)
    {
        _products = products;
        _changes = changes;
    }

    public decimal SelectProduct(int code)
    {
        var product = _products.FirstOrDefault(x => x.Code == code);

        if (product.Quantity == 0) throw Exception("Product is empty");

        _stateMachine = new StateMachine(product, 0);

        return product.Price;
    }

    public void InsertCoin(decimal coin)
    {
        _stateMachine = new StateMachine(_stateMachine.Product, _stateMachine.Money + coin);
    }

    public bool IsPaidFull() => _stateMachine.IsPaidFull();

    public ProductDelivery Delivery()
    {
        var change = _stateMachine.Money - _stateMachine.Product.Price;

        if (_changes < change)
        {
            Cancel();
            return null;
        }

        _stateMachine.Product.Delivery();

        _changes = _changes - change;

        return new ProductDelivery(_stateMachine.Product, change);
    }

    public decimal Cancel()
    {
        var customerMoney = _stateMachine.Money;
        _stateMachine = null;

        return customerMoney;
    }
}