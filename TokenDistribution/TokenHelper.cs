using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenDistribution
{
    public class TokenHelper
    {
        public void CalculateTokenReceivers(IEnumerable<int> weightList, int tokenAmount)
        {
            //Creates token receivers
            var tokenReceivers = weightList.Select(t => new TokenReceiver()
            { Weight = t, TotalWeight = weightList.Sum() });

            for (int i = 0; i < tokenReceivers.ToList().Count(); i++)
            {
                Console.WriteLine(
                    $"Weight with {tokenReceivers.ToList()[i].Weight} receives {tokenReceivers.ToList()[i].TokenAllShared(tokenReceivers.Select(t => t.CalculatePercent).ToList(), tokenAmount, i)} of the {tokenAmount} tokens");
            }

        }

        public virtual bool GetWeightList(out IEnumerable<int> weightList)
        {
            //Get weights
            Console.WriteLine("Enter weight with comma separated each:");
            weightList = Console.ReadLine()?.Split(',').Select(t =>
            {
                try
                {
                    return Convert.ToInt32(t);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Error parsing value {t}");
                    return -1;
                }
            });
            return weightList != null && weightList.Any(t => t != -1);
        }

        public virtual bool GetTokenAmount(out int tokenAmount)
        {
            try
            {
                //Get token amount
                Console.WriteLine("Enter token amount:");
                tokenAmount = Convert.ToInt32(Console.ReadLine());
                return true;
            }
            catch (FormatException)
            {
                tokenAmount = 0;
                Console.WriteLine("Illegal token value");
                return false;
            }
        }
    }
}