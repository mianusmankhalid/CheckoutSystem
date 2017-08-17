using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src.Products;
using PodCheckout.src.Rules;
using System.Collections.Generic;
using System.Linq;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class DiscountTest
	{
		private readonly Discount _target = new Discount();

		[TestMethod]
		public void execute_NoProduct_ReturnsNothing()
		{
			// Arrange
			var products = new List<Product> { };
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(0, result.Item1.Count);
			Assert.AreEqual(0, result.Item2);
		}

		[TestMethod]
		public void execute_DifferentProduct_ReturnsRemainingItemsAndDiscountedPrice()
		{
			// Arrange
			_target.ProductName = "Classic Ad";
			_target.Purchased = 3;
			_target.ChargedFor = 2;
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(1, result.Item1.Count);
			Assert.AreEqual("Premium Ad", result.Item1.FirstOrDefault().Name);
			Assert.AreEqual(539.98, result.Item2);
		}
	}
}
