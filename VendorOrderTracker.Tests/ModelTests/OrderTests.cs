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
      Order.ClearAll();
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

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      Order newOrder1 = new Order("pastic can", "Pastic cans to put sode in", 5);
      Order newOrder2 = new Order("toliet paper", "bath necessity", 5);
      Console.WriteLine(newOrder1.Id);
      Assert.AreEqual(1, newOrder1.Id);
    }

    [TestMethod]
    public void GetDate_ReturnsDateOfOrder_String()
    {
      Order newOrder = new Order("pastic can", "Pastic cans to put sode in", 5);
      string currentDate = DateTime.Now.ToString().Substring(0, 8);
      Assert.AreEqual(currentDate, newOrder.Date);
    }

    [TestMethod]
    public void GetAll__ReturnAllObjectsInList_List()
    {
      Order newOrder1 = new Order("pastic can", "Pastic cans to put sode in", 5);
      Order newOrder2 = new Order("toliet paper", "bath necessity", 5);

      List<Order> result = new List<Order> { newOrder1, newOrder2 };
      CollectionAssert.AreEqual(result, Order.GetAll());
    }

    [TestMethod]
    public void Find_ReturnSpecificObjectInList_List()
    {
      Order newOrder1 = new Order("pastic can", "Pastic cans to put sode in", 5);
      Order newOrder2 = new Order("toliet paper", "bath necessity", 5);

      Assert.AreEqual(newOrder2, Order.Find(2));
    }

    [TestMethod]
    public void Delete_RemovesSpecificObjectInList_List()
    {
      Order newOrder1 = new Order("pastic can", "Pastic cans to put sode in", 5);
      Order newOrder2 = new Order("toliet paper", "bath necessity", 5);
      Order.Delete(1);
      List<Order> orderList = Order.GetAll();

      Assert.AreEqual(newOrder2, orderList[0]);
    }
  }
}