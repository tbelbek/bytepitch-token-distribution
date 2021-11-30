using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenDistribution
{
    public class TokenReceiver
    {
        public decimal Weight { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal CalculatePercent => Weight / TotalWeight;

        public decimal TokenShare(int tokenAmount)
        {
            //Rounded for exact integer value because it's not possible to divide tokens :)
            return decimal.Round(tokenAmount * CalculatePercent);
        }

        public decimal TokenAllShared(IEnumerable<decimal> shareWeight, int tokenAmount, int index)
        {
            var distributedAmount = shareWeight.Select(t => Decimal.Round(tokenAmount * t, MidpointRounding.ToZero)).Sum(t => t);

            return decimal.Round(shareWeight.ToList()[index] * tokenAmount, MidpointRounding.ToZero) + LargestRemainderDistribution.Round(shareWeight.ToList(), tokenAmount - distributedAmount)[index];
        }
    }
}