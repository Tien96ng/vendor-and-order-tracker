using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Vendor
  {
    public string Name { get; }
    public string Description { get; }
    public int Id { get; set;}
    // public List<Order> Orders { get; set; }
    private List<Vendor> _instances =  new List<Vendor> {};

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      Id = _instances.Count;
      // Orders = new List<Order> {};
    }
  }
}