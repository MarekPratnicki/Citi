using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Commission
    {
        public Commission()
        {
            FromCount = null;
            ToCount = null;
            Percent = 0;
        }

        private int? fromCount;
        public int? FromCount
        {
            get
            {
                return this.fromCount;
            }

            set
            {
                this.fromCount = value;
            }
        }

        private int? toCount;
        public int? ToCount
        {
            get
            {
                return this.toCount;
            }

            set
            {
                this.toCount = value;
            }
        }

        private decimal percent;
        public decimal Percent
        {
            get
            {
                return this.percent;
            }

            set
            {
                this.percent = value;
            }
        }
    }
}
