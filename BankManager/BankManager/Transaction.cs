using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public abstract class Transaction
    {
        public int BaseAmount { get; private set; }

        protected Transaction(int baseAmount)
        {
            BaseAmount = baseAmount;
        }

        public abstract int CalculateTotalTransaction();
    }
}
