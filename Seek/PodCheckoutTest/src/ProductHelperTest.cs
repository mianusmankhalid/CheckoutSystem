using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodCheckout.src.Products;
using System.Collections.Generic;

namespace PodCheckoutTest.src
{
	[TestClass]
	public class ProductHelperTest
	{
		[TestMethod]
		public void GetOriginalPrice_NoProduct_ReturnsNothing()
		{
			// Arrange
			var products = new List<Product> { };
			var productName = "Standout Ad";
			// Act
			var result = ProductHelper.GetOriginalPrice(products, productName);
			// Assert
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void GetOriginalPrice_DifferentProduct_ReturnsSpecificProductPrice()
		{
			// Arrange
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Standout Ad", Price = 322.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			var productName = "Standout Ad";
			// Act
			var result = ProductHelper.GetOriginalPrice(products, productName);
			// Assert
			Assert.AreEqual(322.99, result);
		}
	}
}
