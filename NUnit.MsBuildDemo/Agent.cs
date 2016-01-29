using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit.MsBuildDemo
{
    public class Agent
    {
        private IBooker booker;
        private IBookingStrategy bookingStrategy;

        public Agent(IBooker booker, IBookingStrategy bookingStrategy)
        {
            this.booker = booker;
            this.bookingStrategy = bookingStrategy;
        }

        public void Book(decimal price, string symbol)
        {
            if (bookingStrategy.ShouldBuy(price, symbol))
            {
                this.booker.Buy(symbol);
            }
        }
    }
}
