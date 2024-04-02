using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOrderManagement
{
    public class OrderDetails       //一个订单包括多个订单明细，可以购买多个商品
    {
        //public OrderDetails next;       指向同一订单中的下一个订单明细

        //private string productName;
        //private double productPrice;
        //public OrderDetails(string proNam, double propri) 
        //{
        //next = null;
        //productName = proNam;
        //productPrice = propri;
        //}
        private string name;        //货品的名称
        public string Name { get { return name; } set { name = value; } }
        private int number;     //货品的数量
        public int Number { get { return number; } set { number = value; } }
        private double price;       //货品的单价
        public double Price { get { return price; } set { price = value; } }
        public OrderDetails()
        {
            this.Name = string.Empty;
            this.Number = 0;
            this.Price = 0;
        }
        public OrderDetails(string name, int number, double price)
        {
            this.Name = name;
            this.Number = number;
            this.Price = price;
        }
        public double getAllPrice()
        {
            return this.price * this.number;
        }

    }
}
