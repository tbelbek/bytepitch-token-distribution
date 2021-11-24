using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TokenDistribution;

namespace TokenDistribution_tests
{
    [TestClass]
    public class UnitTest1
    {
        public TokenHelper TokenHelper { get; set; }
        public UnitTest1()
        {
            TokenHelper = new TokenHelper();
        }

        [TestMethod]
        public void GetTokens_ShouldPass_ReturnsInteger()
        {
            Mock<TokenHelper> tokenHelper = new Mock<TokenHelper>();
            int tokenAmount = 1000;
            IEnumerable<int> weightList = new List<int>() { 10, 20, 30, 40 };
            tokenHelper.Setup(t => t.GetTokenAmount(out tokenAmount)).Returns(true);
            tokenHelper.Setup(t => t.GetWeightList(out weightList)).Returns(true);

            tokenHelper.Object.CalculateTokenReceivers(weightList, tokenAmount);

            //should not throw any exception
        }
    }
}
