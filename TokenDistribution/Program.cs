namespace TokenDistribution
{
    public class Program
    {
        static void Main(string[] args)
        {
            TokenHelper helper = new TokenHelper();
            while (true)
            {
                if (!helper.GetTokenAmount(out var tokenAmount))
                    continue;

                if (!helper.GetWeightList(out var weightList))
                    continue;

                helper.CalculateTokenReceivers(weightList, tokenAmount);
            }

        }


    }
}
