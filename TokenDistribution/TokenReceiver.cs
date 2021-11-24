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
    }
}