using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Bank
    {
        private List<Broker> brokers;

        public Bank()
        {
            brokers = new List<Broker>();
        }

        public Order MakeOrder(Client client, ITradeable product, OrderType type, int count)
        {
            Order order = new Order();
            order.Client = client;
            order.Product = product;
            order.Type = type;
            order.Count = count;

            Order tempOrder = (Order)order.Clone();
            Order [] brokerOrders = new Order[brokers.Count];
            bool [] rtnCdes = new bool[brokers.Count];
            int modCount = order.Count;
            int idx = 0;            
            int maxCount = 0;
            decimal minBrokerValue = 0;
            int brokerValueIdx = -1;

            while (modCount > 0)
            {
                tempOrder.Count = modCount;
                
                maxCount = 0;
                idx = 0;
                foreach (Broker broker in brokers)
                {
                    rtnCdes[idx] = broker.PrepareOrder(tempOrder, out brokerOrders[idx]);
                    if (rtnCdes[idx])
                    {
                        if (brokerOrders[idx].Count > maxCount)
                            maxCount = brokerOrders[idx].Count;                                            
                    }

                    idx++;
                }

                if (maxCount == 0)
                    return order;

                minBrokerValue = decimal.MaxValue;
                brokerValueIdx = -1;
                for(idx = 0; idx < brokers.Count; ++idx)
                {
                    if (rtnCdes[idx])
                    {
                        if (brokerOrders[idx].Count == maxCount)
                        {
                            if (brokerOrders[idx].BrokerValue < minBrokerValue)
                            { 
                                minBrokerValue = brokerOrders[idx].BrokerValue;
                                brokerValueIdx = idx;
                            }
                        }
                    }
                }                

                if (brokerValueIdx == -1)
                    return order;

                brokers[brokerValueIdx].AddOrder(brokerOrders[brokerValueIdx]);
                order.TotalValue += brokerOrders[brokerValueIdx].BrokerValue;                
                modCount -= brokerOrders[brokerValueIdx].Count;
            }

            client.AddOrder(order);
            return order;
       }        

        public void AddBroker(Broker broker)
        {
            brokers.Add(broker);
        }
    }
}
