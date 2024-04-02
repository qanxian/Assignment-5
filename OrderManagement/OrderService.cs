using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrderManagement
{
    public class OrderService : _OrderService
    {
        public List<Order> orders = new List<Order>();
        public void addOrder()
        {
            try
            {
                Console.WriteLine("Please input the id of the order: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please input the customer of the order: ");
                string customer = Console.ReadLine();
                Console.WriteLine("Please input the date of the order: ");
                string date = Console.ReadLine();
                Order order = new Order(id, customer, date);        //创建订单

                bool judge = true;
                bool same = false;      //判断订单是否重复
                foreach (Order ord in orders)
                {
                    if (ord.Equals(order))
                        same = true;
                }
                if (same == true)
                {
                    Console.WriteLine("Input error!");
                }
                else
                {
                    Console.WriteLine("Please follow the steps to add the item of the order: ");
                    while (judge == true && same == false)
                    {
                        Console.WriteLine("Please input the name of the item: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please input the number of the item: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please input the price of the item: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        order.addOrderDetails(name, number, price);
                        Console.WriteLine("Continue to add the item or not?");
                        string x = Console.ReadLine();
                        if (x == "yes" || x == "Yes")
                            judge = true;
                        else
                            judge = false;
                    }
                    orders.Add(order);
                    order.setMoney();
                    Console.WriteLine("Buile the new order successfully!");
                }

            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }
        public void removeOrder()
        {
            try
            {
                Console.WriteLine("Input the id of the order to remove:");
                int id = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (Order order in orders)
                {
                    if (order.Id == id)
                        index = this.orders.IndexOf(order);
                }
                this.orders[index].showOrderDetails();
                this.orders[index].removeOrderDetails();
                this.orders.RemoveAt(index);
                Console.WriteLine("Remove successfully!");
            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }
        public void searchOrder(int i)
        {
            try
            {
                switch (i)
                {
                    case 1:
                        int min, max;
                        Console.WriteLine("Input the mininum money to query: ");
                        min = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input the maxinum money to query: ");
                        max = Convert.ToInt32(Console.ReadLine());

                        var queryInMoney = from order in this.orders
                                           where order.Money >= min && order.Money <= max
                                           orderby order.Money descending
                                           select order;

                        List<Order> orderQueryInMoney = queryInMoney.ToList();
                        foreach (Order order in orderQueryInMoney)
                        {
                            Console.WriteLine("Id Customer Date Money");
                            Console.WriteLine(order.Id + " " + order.Customer + " " + order.Date + " " + order.Money);
                            order.showOrderDetails();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Input the customer to query: ");
                        string customer = Console.ReadLine();

                        var queryInCustomer = from order in this.orders
                                              where order.Customer == customer
                                              orderby order.Money
                                              select order;

                        List<Order> orderQueryInCustomer = queryInCustomer.ToList();
                        foreach (Order order in orderQueryInCustomer)
                        {
                            Console.WriteLine("Id Customer Date Money");
                            Console.WriteLine(order.Id + " " + order.Customer + " " + order.Date + " " + order.Money);
                            order.showOrderDetails();
                        }
                        break;

                    default:
                        Console.WriteLine("Input error!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }
        public void showOrders()
        {
            foreach (var order in orders)
            {
                Console.WriteLine("Id Customer Date Money");
                Console.WriteLine(order.Id + " " + order.Customer + " " + order.Date + " " + order.Money);
                order.showOrderDetails();
            }
        }
    }
}
