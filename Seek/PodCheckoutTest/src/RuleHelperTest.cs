using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src.Rules;
using System.Collections.Generic;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class RuleHelperTest
	{
		[TestMethod]
		public void GetRulesForCustomer_NoMatchRule_ReturnsBasicRule()
		{
			// Arrange
			var customerRule = new List<CustomerRule> { };
			// Act
			var result = RuleHelper.GetRulesForCustomer("",customerRule);
			// Assert
			Assert.AreEqual(1, result.Count);
		}

		[TestMethod]
		public void GetRulesForCustomer_SpecificCustomer_ReturnsSpecialAndBasicRule()
		{
			// Arrange
			var customerRule = new List<CustomerRule> {
				new CustomerRule { CustomerName = "UNILEVER", Rule = new Rule { ProductName = "Classic Ads" } },
				new CustomerRule { CustomerName = "APPLE", Rule = new Rule { ProductName = "Standout Ads" } },
				new CustomerRule { CustomerName = "NIKE", Rule = new Rule { ProductName = "Premium Ads" } },
			};
			// Act
			var result = RuleHelper.GetRulesForCustomer("UNILEVER", customerRule);
			// Assert
			Assert.AreEqual(2, result.Count);
		}
	}
}
