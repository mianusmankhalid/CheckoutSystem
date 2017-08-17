using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src;
using System.Dynamic;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class RuleMakerTest
	{
		[TestMethod]
		public void GetRulesForCustomer_NoMatchRule_ReturnsBasicRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			// Act
			var result = RuleMaker.MakeRule("New Product", "promotions", param);
			// Assert
			Assert.AreEqual("New Product", result.ProductName);
		}

		[TestMethod]
		public void GetRulesForCustomer_Discount_ReturnsDiscountRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			param.purchased = 3;
			param.charged_for = 2;
			// Act
			var result = RuleMaker.MakeRule("Classic Ad", "discount", param);
			// Assert
			Assert.AreEqual("Classic Ad", result.ProductName);
		}
	}
}
