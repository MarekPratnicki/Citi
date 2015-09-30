using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Client
    {
        public Client()
        {
            orders = new List<Order>();
            ordersCount = 0;
            ordersSum = 0;
            orderPrizesSum = 0;
        }

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        private List<Order> orders;
        public void AddOrder(Order order)
        {
            orders.Add(order);

            if (order.Type == OrderType.BUY)
                ordersSum += order.Count;
            else
                ordersSum -= order.Count;

            ordersCount += order.Count;
            orderPrizesSum += order.TotalValue;
        }

        public decimal CalculateNet()
        {
            return AveragePrice * OrdersSum;
        }

        public decimal AveragePrice
        {
            get
            {
                if (ordersCount > 0)
                    return Convert.ToDecimal(string.Format("{0:F2}", orderPrizesSum / ordersCount));
                else
                    return 0;
            }
        }

        private decimal orderPrizesSum;
        public decimal OrderPrizesSum
        {
            get
            {
                return orderPrizesSum;
            }
        }

        private int ordersSum;
        public int OrdersSum
        {
            get
            {
                return ordersSum;
            }
        }

        private int ordersCount;
        public int OrdersCount
        {
            get
            {
                return ordersCount;
            }
        }

    }
}
