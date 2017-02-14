using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public class FeeTransaction : Transaction
    {
        private readonly int _fee;
        public FeeTransaction(int baseAmount, int fee) : base(baseAmount)
        {
            _fee = fee;
        }

        public override int CalculateTotalTransaction()
        {
            return BaseAmount - _fee;
        }
    }
}
