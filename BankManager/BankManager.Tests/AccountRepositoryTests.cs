using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    class AccountRepositoryTests : BaseTestClass
    {
        private AccountRepository _accountRepository;
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _accountRepository = new AccountRepository();
        }

        [Test]
        public void GetBalance_WithNoTransactions_Returns0Balance()
        {
            var balance = _accountRepository.GetBalance();

            const int expectedBalance = 0;
            Assert.That(balance, Is.EqualTo(expectedBalance),
                "Empty account should return a 0 balance");
        }

        [Test]
        public void ProcessTransaction_FirstTransaction_StoredTransactionContainsOnlyOne()
        {
            const int depositAmount = 10;

            _accountRepository.ProcessTransaction(depositAmount);

            var transactions = _accountRepository.GetTransactions();
            Assert.That(transactions.First, Is.EqualTo(depositAmount),
                "Deposit amount should equal 10");
        }
    }
}
