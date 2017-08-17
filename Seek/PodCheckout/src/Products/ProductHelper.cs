using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace PodCheckout.src.Products
{
	public class ProductHelper
	{
		public static double GetOriginalPrice(List<Product> products, String productName)
		{
			var product = products.Find(x => x.Name.Equals(productName));
			if (product != null)
			{
				return product.Price;
			}
			return -1;
		}

		public static List<Product> ReadProducts(String filename)
		{
			return new JavaScriptSerializer().Deserialize<List<Product>>(new StreamReader(filename).ReadToEnd());
		}
	}
}
