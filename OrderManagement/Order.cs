using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrderManagement
{
    public class Order : IComparable
    {
        //private int orderNumber;
        //private string client;
        //private double price;
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Date { get; set; }
        public double Money { get; set; }

        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public Order() {
            this.Id = 0;
            this.Customer = string.Empty;
            this.Date = string.Empty;
            this.Money = 0;
        }
        public Order(int id, string customer, string date)
        {
            this.Id = id;
            this.Customer = customer;
            this.Date = date;
            this.Money = 0;
        }
        public void setMoney()
        {
            double money = 0;
            foreach (OrderDetails details in orderDetails)
            {
                money = money + details.getAllPrice();
            }
            this.Money = money;     //总价格
        }
        public void addOrderDetails(string name, int number, double price)
        {
            OrderDetails details = new OrderDetails(name, number, price);
            this.orderDetails.Add(details);
        }
        public void removeOrderDetails()
        {
            Console.WriteLine("Please intput the id of the orderdetails to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            this.orderDetails.RemoveAt(id);
            Console.WriteLine("Remove successfully");
        } 
        public void showOrderDetails() {
            foreach (OrderDetails details in this.orderDetails)
            {
                Console.WriteLine("Id Name Number Price");
                Console.WriteLine(this.orderDetails.IndexOf(details)+" "+details.Name+" "+details.Number+" "+details.Price);
            }
        }

        #region IComparable Members
        public int CompareTo(object? obj)
        {
            if (obj != null)
            {
                Order? order = obj as Order;
                return this.Id.CompareTo(order?.Id);
            }
            else
            {
                return -1;
            }
        }
        public override bool Equals(object? obj)
        {
            Order? order = (obj as Order);
            return this.Id.Equals(order?.Id);
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Id);
        }
    }

}
#endregion