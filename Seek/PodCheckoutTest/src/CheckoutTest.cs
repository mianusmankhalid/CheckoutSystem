using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src.Cart;
using PodCheckout.src.Products;
using PodCheckout.src.Rules;
using System.Collections.Generic;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class CheckoutTest
	{
		[TestMethod]
		public void PerformCheckout_NoProduct_ReturnsNothing()
		{
			// Arrange
			var products = new List<Product> { };
			var rules = new List<Rule> { };
			// Act
			var result = Checkout.PerformCheckout(products, rules);
			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void PerformCheckout_DifferentProductWithRules_ReturnsTotalAmount()
		{
			// Arrange
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			var rules = new List<Rule> {
				new Rule { ProductName = "Classic Ads" },
				new Rule { ProductName = "Standout Ads" }
			};
			// Act
			var result = Checkout.PerformCheckout(products, rules);
			// Assert
			Assert.AreEqual(664.98, result);
		}
	}
}
