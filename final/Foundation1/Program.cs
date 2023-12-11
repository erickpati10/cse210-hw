using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Restaurant restaurant = new Restaurant();

    
        restaurant.DisplayAvailableMenu();

     
        restaurant.TakeOrder("Burger");

      
        restaurant.DisplayAllOrders();
    }
}


class Menu
{
    private Dictionary<string, decimal> items;

    public Menu()
    {
        items = new Dictionary<string, decimal>();
        items.Add("Burger", 5.99M);
        items.Add("Pizza", 8.99M);
        items.Add("Fries", 3.99M);        
        items.Add("Drink", 1.79M);
        items.Add("Milshake", 4.50M);
        
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key}: ${item.Value}");
        }
    }

    public decimal GetItemPrice(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            return items[itemName];
        }
        return 0;
    }
}

class Order
{
    private List<string> items;
    private decimal totalPrice;

    public Order()
    {
        items = new List<string>();
        totalPrice = 0;
    }

    public void AddItem(string itemName, decimal price)
    {
        items.Add(itemName);
        totalPrice += price;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order Details:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Total Price: ${totalPrice}");
    }
}

class Restaurant
{
    private Menu menu;
    private List<Order> orders;

    public Restaurant()
    {
        menu = new Menu();
        orders = new List<Order>();
    }

    public void DisplayAvailableMenu()
    {
        menu.DisplayMenu();
    }

    public void TakeOrder(string itemName)
    {
        decimal itemPrice = menu.GetItemPrice(itemName);
        if (itemPrice > 0)
        {
            Order newOrder = new Order();
            newOrder.AddItem(itemName, itemPrice);
            orders.Add(newOrder);
            Console.WriteLine("Order placed successfully!");
        }
        else
        {
            Console.WriteLine("Item not found in the menu.");
        }
    }

    public void DisplayAllOrders()
    {
        Console.WriteLine("All Orders:");
        foreach (var order in orders)
        {
            order.DisplayOrder();
        }
    }
}

