using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Models
{
  public class Order
  {
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

     public static List<Order> GetAll()
    {
      return _instances;
    }
    
    public static Order Find(int id)
    {
      return _instances[id - 1];
    }
    public static void Delete(int id)
    {
      Order removeOrder = Order.Find(id);
      _instances.Remove(removeOrder);
      for(int i = 0; i < _instances.Count; i++)
      {
        _instances[i].Id = i + 1;
      }
    }
  }
}