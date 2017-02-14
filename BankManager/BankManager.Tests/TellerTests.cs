using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

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
            const int depositAmount = 10;

            _teller.ProcessTransaction(depositAmount);

            Mock.Get(_accountRepository).Verify(x => x.ProcessTransaction(depositAmount), Times.Once(),
                "teller should forward the process transaction request to the repository");
        }
    }
}
