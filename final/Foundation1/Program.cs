using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Order dineInOrder = new DineInOrder("DIN-123", 50.00M, 4);
        dineInOrder.AddItem("Burger");
        dineInOrder.AddItem("Fries");
        dineInOrder.AddItem("Soda");

        Order takeoutOrder = new TakeoutOrder("TKO-456", 35.00M, "John Brown", "435-456-7890");
        takeoutOrder.AddItem("Pizza");
        takeoutOrder.AddItem("Salad");
        takeoutOrder.AddItem("Juice");

        DisplayOrderDetails(dineInOrder);
        DisplayOrderDetails(takeoutOrder);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Order Details:");
        order.DisplayOrderDetails();
        Console.WriteLine();
    }
}


class Order
{
    protected string orderId;
    protected DateTime orderDateTime;
    protected decimal totalAmount;
    protected List<string> orderedItems;

    public Order(string orderId, decimal totalAmount)
    {
        this.orderId = orderId;
        this.orderDateTime = DateTime.Now;
        this.totalAmount = totalAmount;
        orderedItems = new List<string>();
    }

    public virtual void PlaceOrder()
    {
        Console.WriteLine("Order placed successfully.");
    }

    public void AddItem(string item)
    {
        orderedItems.Add(item);
    }

    public virtual void DisplayOrderDetails()
    {
        Console.WriteLine($"Order ID: {orderId}");
        Console.WriteLine($"Order Date & Time: {orderDateTime}");
        Console.WriteLine($"Total Amount: ${totalAmount}");
        Console.WriteLine("Ordered Items:");
        foreach (var item in orderedItems)
        {
            Console.WriteLine(item);
        }
    }
}

class DineInOrder : Order
{
    private int tableNumber;

    public DineInOrder(string orderId, decimal totalAmount, int tableNumber)
        : base(orderId, totalAmount)
    {
        this.tableNumber = tableNumber;
    }

    public override void DisplayOrderDetails()
    {
        base.DisplayOrderDetails();
        Console.WriteLine($"Order Type: Dine-in");
        Console.WriteLine($"Table Number: {tableNumber}");
    }
}

class TakeoutOrder : Order
{
    private string customerName;
    private string phoneNumber;

    public TakeoutOrder(string orderId, decimal totalAmount, string customerName, string phoneNumber)
        : base(orderId, totalAmount)
    {
        this.customerName = customerName;
        this.phoneNumber = phoneNumber;
    }

    public override void DisplayOrderDetails()
    {
        Console.WriteLine($"Order Type: Takeout");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        base.DisplayOrderDetails();
       
    }
}

