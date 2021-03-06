using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      string name = "Pepsi";
      string description = "Soda product seller";
      Vendor newVendor = new Vendor(name, description);
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      Vendor newVendor = new Vendor("pepsi", "Soda Product seller");
      Assert.AreEqual("pepsi", newVendor.Name);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      Vendor newVendor = new Vendor("pepsi", "Soda Product seller");
      Assert.AreEqual("Soda Product seller", newVendor.Description);
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      Vendor newVendor1 = new Vendor("pepsi", "Soda Product seller");
      Assert.AreEqual(1, newVendor1.Id);
    }

    [TestMethod]
    public void GetAll__ReturnAllObjectsInList_List()
    {
      Vendor pepsi = new Vendor("pepsi", "Sode product seller");
      Vendor apple = new Vendor("apple", "Technology enterprise");

      List<Vendor> result = new List<Vendor> { pepsi, apple };
      CollectionAssert.AreEqual(result, Vendor.GetAll());
    }

    [TestMethod]
    public void Find_ReturnSpecificObjectInList_List()
    {
      Vendor pepsi = new Vendor("pepsi", "Sode product seller");
      Vendor apple = new Vendor("apple", "Technology enterprise");
      Vendor result = Vendor.Find(2);

      Assert.AreEqual(apple, result);
    }
  }
}