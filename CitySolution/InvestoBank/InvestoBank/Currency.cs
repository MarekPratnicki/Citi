using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public class Currency : ITradeable
    {
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

        private string symbol;
        public string Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                this.symbol = value;
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


    }
}
