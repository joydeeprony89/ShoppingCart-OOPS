using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Address
    {
        public string HouseNO { get; set; }
    }

    public enum OrderStatus
    {

    }

    public enum ShipmentSttaus
    {

    }

    public enum AccountStatus
    {

    }

    public enum PaymenetStatus
    {

    }

    public class CardDetail
    {

    }

    public class Account
    {
        List<Address> addresses;
        List<CardDetail> cardDetails;

        public bool ResetPassowrd() { return true; }
        bool AddProduct(Product product);
        bool RemoveProduct(Product product);
        bool AddReview(ProductReview review);
    }

    public abstract class Customer
    {
        Cart Cart;
        Order Order;

        Cart GetCart();
        bool AddItemTocart(Item item);
        bool RemoveItemFromcart(Item item);
    }

    public class Guest : Customer
    {
        bool CreateAccount();
    }

    public class Member : Customer
    {
        Account Account;
        OrderStatus PlaceOrder(Order order);
    }

    public class ProductCategory
    {
        string name;
        string descripttion;
    }

    public class ProductReview
    {
        int revireId;
        string review;
        Member reviewer;
    }

    public class Product
    {
        ProductCategory category;
        Account seller;
        ProductReview productReview;
        string name;
        double price;

        int getAvailibility();
        double updateProce(double newPrice);

    }
    public class Item
    {
        string prodctId;
        string name;
        double price;
        int quantiy;

        bool updateQuantity(int newQuantiyy);
    }

    public class Cart
    {

        List<Item> items;
        bool AddItem(Item item);
        bool removeItem(Item item);
        bool Checkout();
        List<Item> getItems();

    }

    public class OrderLog
    {
        OrderStatus orderStatus;
        DateTime creation;
    }

    public class Order
    {
        string orderno;
        List<OrderLog> orderLogs;
        DateTime orderdate;

        bool makePayment(Payment payment);
        bool sendForShippment();
    }

    public class Payment
    {

    }

    public class Shipment
    {
        List<ShipmentLog> shipmentLogs;
        DateTime expecteddelivery;
        DateTime shipmentdate;
        string method;
        bool AddLog(ShipmentLog log);
    }

    public class ShipmentLog
    {
        ShipmentSttaus shipmentSttaus;
        DateTime creationdate;
    }
    
    public abstract class Notification
    {
        int id;
        string content;
        bool SendNotification(Account account);
    }

    public interface Search
    {
        List<Product> SearchByName(string name);
        List<Product> SearchByCategory(string name);
    }

    public class Catelog : Search
    {
        Dictionary<string, List<Product>> productNames;
        Dictionary<string, List<Product>> productCategories;
        public List<Product> SearchByCategory(string name)
        {
            return productNames[name];
        }

        public List<Product> SearchByName(string name)
        {
            return productCategories[name];
        }
    }

}
