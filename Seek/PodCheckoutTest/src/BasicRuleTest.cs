using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src.Products;
using PodCheckout.src.Rules;
using System.Collections.Generic;
using System.Linq;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class BasicRuleTest
	{
		private Rule _target;

		[TestMethod]
		public void execute_NoProduct_ReturnsNothing()
		{
			// Arrange
			_target = new Rule();
			var products = new List<Product> { };
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void execute_DifferentProduct_ReturnsRemaingItemsAndPrice()
		{
			// Arrange
			_target = new Rule();
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(1, result.Item1.Count);
			Assert.AreEqual("Premium Ad", result.Item1.FirstOrDefault().Name);
			Assert.AreEqual(269.99, result.Item2);
		}

	}
}
