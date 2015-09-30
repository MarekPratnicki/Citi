using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace InvestoBank
{
    public class Broker
    {
        public Broker(int id)
        {
            Id = id;

            orders = new List<Order>();

            transactionsSum = 0;
        
            MinCount = 1;
            MaxCount = int.MaxValue;
            Multiplicity = 1;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);

            transactionsSum += order.Count;
        }

        public bool PrepareOrder(Order order, out Order newOrder)
        {
            newOrder = (Order)order.Clone();
            if (order.Count < MinCount)
            {
                return false;
            }

            if (order.Count > MaxCount)
            {
                newOrder.Count = MaxCount;
            }
            else 
            {
                int countMod = order.Count % Multiplicity;
                if (countMod != 0)
                {
                    newOrder.Count -= countMod;
                }
            }

            Quotation quotation = GetQuote(newOrder.Product);
            newOrder.Quote = quotation.Value;
            newOrder.Commission = GetCommission(newOrder);

            return true;            
        }

        public Quotation GetQuote(ITradeable product)
        {
            List<Quotation> quotationList = quotations[product.Symbol];
            return quotationList.LastOrDefault();
        }

        public decimal GetCommission(Order order)
        {
            int count = order.Count;

            int fromCount = 0;
            int toCount = 0;
            
            foreach (Commission commission in commissions)
            {
                if (commission.FromCount != null)                
                    fromCount = commission.FromCount.Value;                
                else
                    fromCount = 0;

                if (commission.ToCount != null)
                    toCount = commission.ToCount.Value;
                else
                    toCount = int.MaxValue;

                if (count >= fromCount && count <= toCount)
                    return commission.Percent;
            }

            return 0;
        }

        public int GetTransactionsSum()
        {
            return transactionsSum;
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

        private int multiplicity;
        public int Multiplicity
        {
            get
            {
                return this.multiplicity;
            }

            set
            {
                this.multiplicity = value;
            }
        }

        private int minCount;
        public int MinCount
        {
            get
            {
                return this.minCount;
            }

            set
            {
                this.minCount = value;
            }
        }

        private int maxCount;
        public int MaxCount
        {
            get
            {
                return this.maxCount;
            }

            set
            {
                this.maxCount = value;
            }
        }

        private List<Order> orders;
        private List<Commission> commissions;
        private Dictionary<string, List<Quotation>> quotations;
        private int transactionsSum;

        public void SetCommissions(List<Commission> commissions)
        {
            this.commissions = commissions;
        }

        public void SetQuotations(Dictionary<string, List<Quotation>> quotations)
        {
            this.quotations = quotations;
        }
    }
}
