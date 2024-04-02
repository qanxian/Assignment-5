// See https://aka.ms/new-console-template for more information
namespace myOrderManagement
{
    public interface _OrderService      //四种主要功能
    {
        void addOrder();
        void removeOrder();
        void searchOrder(int i);
        void showOrders();
    }
    public class Program
    {
        static void Main(string[] args)
        {
            OrderService orders = new OrderService();
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Input 1 to add order, Input 2 to remove order, Input 3 to search order, Input 4 to show order, Input 5 to quit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        orders.addOrder();
                        break;

                    case "2":
                        orders.removeOrder();
                        break;

                    case "3":
                        Console.WriteLine("Input 1 to search orders in money " +
                            "Input 2 to search orders in customer");
                        break;

                    case "4":
                        orders.showOrders();
                        break;

                    case "5":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Input error! Please input the choose again!");
                        break;
                }
            }
        }
    }
}
