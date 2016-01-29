using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Moq;
using NUnit.Framework;

namespace NUnit.MsBuildDemo.Tests
{
    [TestFixture]
    public class AgentTests
    {
        private Mock<IBookingStrategy> bookingStrategy;
        private Mock<IBooker> booker;

        [SetUp]
        public void Setup()
        {
            bookingStrategy = new Mock<IBookingStrategy>();
            booker = new Mock<IBooker>();
        }

        [TestCase(50, 49,"GBP")]
        [TestCase(100, 99,"USD")]
        [TestCase(500, 499,"YEN")]
        public void ShouldBookTests(decimal limit, decimal price, string symbol)
        {
            DoAgentBuyTestsAsserts(limit, price, symbol,1);
        }

        [TestCase(50, 51, "GBP")]
        [TestCase(100, 101, "USD")]
        [TestCase(500, 501, "YEN")]
        public void ShouldNotBookTests(decimal limit, decimal price, string symbol)
        {
            DoAgentBuyTestsAsserts(limit, price, symbol, 0);
        }

        private void DoAgentBuyTestsAsserts(decimal limit, decimal price, string symbol, int bookerCalledCount)
        {
            bookingStrategy = new Mock<IBookingStrategy>();
            bookingStrategy.Setup(x => x.ShouldBuy(price, symbol))
                .Returns(price < limit);

            booker = new Mock<IBooker>();
            Agent agent = new Agent(booker.Object, bookingStrategy.Object);
            agent.Book(price, symbol);
            booker.Verify(foo => foo.Buy(symbol), Times.Exactly(bookerCalledCount));
        }
    }
}
