using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Vendor
  {
    public string Name { get; }
    public string Description { get; }
    public int Id { get; set;}
    public List<Order> Orders { get; set; }
    private static List<Vendor> _instances =  new List<Vendor> {};

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order> {};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor Find(int id)
    {
      return _instances[id - 1];
    }

    public static void Delete(int id)
    {
      for(int i = 0; i < _instances.Count; i++)
      {
        if(id == _instances[i].Id){
          _instances.Remove(_instances[i]);
        }
        _instances[i].Id = i + 1;
      }
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}