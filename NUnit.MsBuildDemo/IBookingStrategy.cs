using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit.MsBuildDemo
{
    public interface IBookingStrategy
    {
        bool ShouldBuy(decimal price, string symbol);
    }
}
