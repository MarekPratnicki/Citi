using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Report
    {
        public static decimal GetClientNetPositions(Client client)
        {
            return client.CalculateNet();    
        }

        public static int GetBrokerTransSum(Broker broker)
        {
            return broker.GetTransactionsSum();
        }
    }
}
