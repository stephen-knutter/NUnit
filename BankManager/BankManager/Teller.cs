﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public class Teller
    {
        private readonly AccountRepository _accountRepository;
        public Teller(AccountRepository accountRepository)
        {
            if (accountRepository == null)
                throw new ArgumentNullException("accountRepository");
            _accountRepository = accountRepository;
        }

        public int CheckBalance()
        {
            Logging.WriteLine("Checking the user's balance.");
            return _accountRepository.GetBalance();
        }

        public int ProcessTransaction(int amount)
        {
            Logging.WriteLine("Processing a transaction of $" + amount);
            _accountRepository.ProcessTransaction(amount);
            return CheckBalance();
        }
    }
}
