using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvestoBank;

namespace InvestoBankTest
{
    class TestMessage
    {
        public static string Order(Order order) 
        {
            string message = "";

            message += order.Client.Name + " ";
                        
            if (order.Type == OrderType.BUY)   
                message += "buys ";
            else
                message += "sels ";

            message += Convert.ToString(order.Count) + " at " + Convert.ToString(order.TotalValue);         
 
            return message;
        }

        public static string ClientNetPositions(Client client, decimal value)
        {            
            return client.Name + " net positions value: " + Convert.ToString(value);            
        }
        
        public static string BrokerTransSum(Broker broker, int value) 
        {
            return broker.Name + " transactions sum value: " + Convert.ToString(value);
        }
    }
}
