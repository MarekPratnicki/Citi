using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvestoBank;

namespace InvestoBankTest
{
    class Program
    {
        private static Broker broker1 = null;
        private static Broker broker2 = null;

        private static Client clientA = null;
        private static Client clientB = null;
        private static Client clientC = null;

        static void Main(string[] args)
        {
            Currency digiCoin = new Currency();
            digiCoin.Id = 1;
            digiCoin.Symbol = "DIGI";
            digiCoin.Name = "DigiCoin";

            InitBrokers();
            InitClients();

            Bank bank = new Bank();
            bank.AddBroker(broker1);
            bank.AddBroker(broker2);

            Order order = null;
            order = bank.MakeOrder(clientA, digiCoin, OrderType.BUY, 10);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }            

            order = bank.MakeOrder(clientB, digiCoin, OrderType.BUY, 40);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientA, digiCoin, OrderType.BUY, 50);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientB, digiCoin, OrderType.BUY, 100);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientB, digiCoin, OrderType.SELL, 80);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientC, digiCoin, OrderType.SELL, 70);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientA, digiCoin, OrderType.BUY, 130);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }

            order = bank.MakeOrder(clientB, digiCoin, OrderType.SELL, 60);
            if (order != null)
            {
                System.Console.WriteLine(TestMessage.Order(order));
            }
            
            decimal netPositions = Report.GetClientNetPositions(clientA);
            System.Console.WriteLine(TestMessage.ClientNetPositions(clientA, netPositions));

            netPositions = Report.GetClientNetPositions(clientB);
            System.Console.WriteLine(TestMessage.ClientNetPositions(clientB, netPositions));

            netPositions = Report.GetClientNetPositions(clientC);
            System.Console.WriteLine(TestMessage.ClientNetPositions(clientC, netPositions));

            int transactionsSum = Report.GetBrokerTransSum(broker1);
            System.Console.WriteLine(TestMessage.BrokerTransSum(broker1, transactionsSum));
            
            transactionsSum = Report.GetBrokerTransSum(broker2);
            System.Console.WriteLine(TestMessage.BrokerTransSum(broker2, transactionsSum));
        }

        private static void InitBrokers()
        {
            broker1 = new Broker(1);
            broker1.Name = "Broker 1";
            broker1.MinCount = 10;
            broker1.MaxCount = 100;
            broker1.Multiplicity = 10;
        
            broker1.SetCommissions(Configuration.GetBrokerCommissions(1));
            broker1.SetQuotations(Configuration.GetBrokerQuotations(1));

            broker2 = new Broker(2);
            broker2.Name = "Broker 2";
            broker2.MinCount = 10;
            broker2.MaxCount = 100;
            broker2.Multiplicity = 10;
                    
            broker2.SetCommissions(Configuration.GetBrokerCommissions(2));
            broker2.SetQuotations(Configuration.GetBrokerQuotations(2));
        }

        private static void InitClients()
        {
            clientA = new Client();
            clientA.Id = 1;
            clientA.Name = "Client A";

            clientB = new Client();
            clientB.Id = 2;
            clientB.Name = "Client B";

            clientC = new Client();
            clientC.Id = 3;
            clientC.Name = "Client C";
        }
    }
}
