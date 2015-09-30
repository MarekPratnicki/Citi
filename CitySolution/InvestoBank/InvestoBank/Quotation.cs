using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Quotation
    {
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

        private decimal value;
        public decimal Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        private DateTime moment;
        public DateTime Moment
        {
            get
            {
                return this.moment;
            }

            set
            {
                this.moment = value;
            }
        }
    }
}
