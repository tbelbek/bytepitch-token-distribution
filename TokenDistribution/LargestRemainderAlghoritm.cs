using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenDistribution
{
    public class LargestRemainderDistribution
    {
        public static List<decimal> Round(List<decimal> original,
            decimal forceSum, int decimals = 0)
        {
            var rounded = original.Select(x => Math.Round(x, decimals)).ToList();
            var delta = forceSum - rounded.Sum();
            if (delta == 0) return rounded;
            var deltaUnit = Convert.ToDecimal(Math.Pow(0.1, decimals)) * Math.Sign(delta);

            List<int> applyDeltaSequence;
            if (delta < 0)
            {
                applyDeltaSequence = original
                    .Zip(Enumerable.Range(0, int.MaxValue), (x, index) => new { x, index })
                    .OrderBy(a => original[a.index] - rounded[a.index])
                    .ThenByDescending(a => a.index)
                    .Select(a => a.index).ToList();
            }
            else
            {
                applyDeltaSequence = original
                    .Zip(Enumerable.Range(0, int.MaxValue), (x, index) => new { x, index })
                    .OrderByDescending(a => original[a.index] - rounded[a.index])
                    .Select(a => a.index).ToList();
            }

            Enumerable.Repeat(applyDeltaSequence, int.MaxValue)
                .SelectMany(x => x)
                .Take(Convert.ToInt32(delta / deltaUnit)).ToList()
                .ForEach(index => rounded[index] += deltaUnit);

            return rounded;
        }
    }
}