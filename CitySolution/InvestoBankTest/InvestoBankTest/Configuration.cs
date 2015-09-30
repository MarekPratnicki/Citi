using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using InvestoBank;

namespace InvestoBankTest
{
    class Configuration
    {
        public static List<Commission> GetBrokerCommissions(int id)
        {
            int fromCount = 0;
            int toCount = 0;
            decimal percent = 0;

            XElement configuration = XElement.Load("Configuration.xml");

            var brokers = from brk in configuration.Elements("Broker")
                          where brk.Attribute("id").Value.Equals(Convert.ToString(id))
                          select brk;

            List<Commission> commissions = new List<Commission>();

            foreach (XElement broker in brokers)
            {
                var commissionsElem = from comm in broker.Elements("Commission")
                                      select comm;

                foreach (XElement commission in commissionsElem)
                {
                    Commission commission_ = new Commission();

                    if (commission.Element("fromCount") != null)
                    {
                        if (int.TryParse(commission.Element("fromCount").Value, out fromCount))
                        {
                            commission_.FromCount = fromCount;
                        }
                    }

                    if (commission.Element("toCount") != null)
                    {
                        if (int.TryParse(commission.Element("toCount").Value, out toCount))
                        {
                            commission_.ToCount = toCount;
                        }
                    }

                    if (commission.Element("value") != null)
                    {
                        if (decimal.TryParse(commission.Element("value").Value, out percent))
                        {
                            commission_.Percent = percent;
                        }
                    }

                    commissions.Add(commission_);
                }
            }

            return commissions;
        }

        public static Dictionary<string, List<Quotation>> GetBrokerQuotations(int id)
        {
            string symbol = "";
            decimal value = 0;
            Currency product = new Currency();
            product.Symbol = "DIGI";
            List<Quotation> quotations_;

            XElement quotationsRoot = XElement.Load("Quotations.xml");

            var brokers = from brk in quotationsRoot.Elements("Broker")
                          where brk.Attribute("id").Value.Equals(Convert.ToString(id))
                          select brk;

            Dictionary<string, List<Quotation>> quotations = new Dictionary<string, List<Quotation>>();

            foreach (XElement broker in brokers)
            {
                var quotationsElem = from quote in broker.Elements("Quotation")
                                      select quote;

                foreach (XElement quotation in quotationsElem)
                {
                    Quotation quotation_ = new Quotation();

                    if (quotation.Element("symbol") != null)
                    {
                        symbol = quotation.Element("symbol").Value;

                        if (symbol == product.Symbol)
                            quotation_.Product = product;
                    }

                    if (quotation.Element("value") != null)
                    {
                        if (decimal.TryParse(quotation.Element("value").Value, out value))
                        {
                            quotation_.Value = value;
                        }
                    }

                    if (symbol != "")
                    {
                        if (quotations.ContainsKey(symbol))
                        {
                            quotations_ = quotations[symbol];
                            quotations_.Add(quotation_);
                            quotations[symbol] = quotations_;
                        }
                        else
                        {
                            quotations_ = new List<Quotation>();
                            quotations_.Add(quotation_);
                            quotations[symbol] = quotations_;
                        }
                    }
                }
            }

            return quotations;
        }
    }
}
