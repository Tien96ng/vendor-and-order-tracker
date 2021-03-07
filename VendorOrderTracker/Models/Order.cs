using System.Collections.Generic;
using System;
using System.Globalization;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    // Create an Order class. This class should include properties for the title, the description, the price, the date, and 
    // any other properties you would like to include.
    public string Name { get; }
    public string Description { get; }
    public string Date { get; }
    public int Price { get; }
    public int Id { get; set; }
    private static List<Order> _instances = new List<Order> {};
    
    public Order(string name, string description, int price)
    {
      Name = name;
      Description = description;
      Price = price;
      Date = DateTime.Now.ToString().Substring(0, 8);
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}