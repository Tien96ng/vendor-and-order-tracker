using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      //
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("controllers", "PS5 Controller order", 5500);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      Order newOrder = new Order("controllers", "PS5 Controller order", 5500);
      Assert.AreEqual("controllers", newOrder.Name);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      Order newOrder = new Order("pastic can", "Pastic cans to put sode in", 5);
      Assert.AreEqual("Pastic cans to put sode in", newOrder.Description);
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_Int()
    {
      Order newOrder = new Order("pastic can", "Pastic cans to put sode in", 5);
      Assert.AreEqual(5, newOrder.Price);
    }
  }
}