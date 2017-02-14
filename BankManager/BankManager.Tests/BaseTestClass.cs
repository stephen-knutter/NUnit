using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    public abstract class BaseTestClass
    {
        [SetUp]
        public virtual void SetUp()
        {
            var logger = Mock.Of<ILogger>();
            Mock.Get(logger).Setup(x => x.WriteLine(It.IsAny<string>()))
                .Callback<string>(Console.WriteLine);
            Logging.Logger = logger;
            // Logging.Logger = Mock.Of<ILogger>();
        }
    }
}
