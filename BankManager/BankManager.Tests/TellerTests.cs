using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using System.Threading;

namespace BankManager.Tests
{
    [TestFixture]
    public class TellerTests : BaseTestClass
    {
        private Teller _teller;
        private AccountRepository _accountRepository;
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _accountRepository = Mock.Of<AccountRepository>();
            _teller = new Teller(_accountRepository);
        }

        [Test]
        public void CheckBalance_RequestsTheAccountBalanceFromTheRepository()
        {
            const int nonZeroBalance = 1;
            Mock.Get(_accountRepository).Setup(x => x.GetBalance())
                .Returns(nonZeroBalance);

            var balance = _teller.CheckBalance();

            Assert.That(balance, Is.EqualTo(nonZeroBalance),
                "Checking the balance should return the balance retrieved from the repository.");
        }

        [Test]
        public void ProcessTransaction_TransactionValueGiven_TellerSubmitsGivenTransactionToTheRepository()
        {
            var transaction = new SimpleTransaction(10);
            var processTransactionTrigger = new ManualResetEvent(false);
            Mock.Get(_accountRepository).Setup(x => x.ProcessTransaction(transaction.CalculateTotalTransaction()))
                .Callback(() => processTransactionTrigger.Set());

            _teller.ProcessTransaction(transaction);

            processTransactionTrigger.WaitOne(TimeSpan.FromSeconds(1));
            Mock.Get(_accountRepository).Verify(x => x.ProcessTransaction(transaction.CalculateTotalTransaction()), Times.Once(),
                "teller should forward the process transaction request to the repository");
        }
    }
}
