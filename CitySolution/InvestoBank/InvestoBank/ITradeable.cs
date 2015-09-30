using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestoBank
{
    public interface ITradeable
    {
        int Id
        {
            get;
        }

        string Symbol
        {
            get;
        }

        string Name
        {
            get;
        }
    }
}
