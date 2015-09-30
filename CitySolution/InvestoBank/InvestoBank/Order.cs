using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public enum OrderType { BUY, SELL }

    public class Order : ICloneable
    {
        public Order()
        {
            Commission = 0;
            Quote = 0;
            Count = 0;
            TotalValue = 0;
        }
    
        private Client client;
        public Client Client
        {
            get
            {
                return this.client;
            }

            set
            {
                this.client = value;
            }
        }

        private OrderType type;
        public OrderType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        private ITradeable product;
        public ITradeable Product
        {
            get
            {
                return this.product;
            }

            set
            {
                this.product = value;
            }
        }

        private decimal commission;
        public decimal Commission
        {
            get
            {
                return this.commission;
            }

            set
            {
                this.commission = value;
            }
        }

        private decimal quote;
        public decimal Quote
        {
            get
            {
                return this.quote;
            }

            set
            {
                this.quote = value;
            }
        }

        private int count;
        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }

        public decimal BrokerValue
        {
            get
            {
                return (Count * Quote * (100 + Commission)) / 100;                
            }
        }

        private decimal totalValue;
        public decimal TotalValue
        {
            get
            {
                return this.totalValue;
            }

            set
            {
                this.totalValue = value;
            }
        }

        public object Clone()
        {
            return new Order() 
            { 
                Client = this.Client, 
                Type = this.Type, 
                Product = this.Product, 
                Commission = this.Commission, 
                Quote = this.Quote,  
                Count = this.Count
            };
        }
    }
}
