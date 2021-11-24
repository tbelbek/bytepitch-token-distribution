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
            var tokenReceivers = weightList.Select(t => new TokenReceiver() { Weight = t, TotalWeight = weightList.Sum() });
            foreach (var tokenReceiver in tokenReceivers)
            {
                Console.WriteLine(
                    $"Weight with {tokenReceiver.Weight} receives {tokenReceiver.TokenShare(tokenAmount)} of the {tokenAmount} tokens");
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
                catch (FormatException e)
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