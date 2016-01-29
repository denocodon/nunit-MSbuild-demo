using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit.MsBuildDemo
{
    public class StopLossBookingStrategy
    {
        private Dictionary<string, decimal> symbolThreshholds = new Dictionary<string, decimal>();

        public StopLossBookingStrategy()
        {
            symbolThreshholds.Add("GBP", 50);
            symbolThreshholds.Add("USD", 100);
            symbolThreshholds.Add("YEN", 500);
        }

        public bool ShouldBuy(decimal price, string symbol)
        {
            if (symbolThreshholds.ContainsKey(symbol))
            {
                return price < symbolThreshholds[symbol];
            }
            return false;
        }
    }
}
