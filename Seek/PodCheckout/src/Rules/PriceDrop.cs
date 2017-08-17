using PodCheckout.src.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodCheckout.src.Rules
{
	public class PriceDrop : Rule
	{
		public double DroppedPrice { get; set; }
		public int MinNumItems { get; set; }

		public override Tuple<List<Product>, double> execute(List<Product> cartItems)
		{
			var selectedItems = cartItems.Where(x => x.Name == this.ProductName);
			if (selectedItems.Count() >= this.MinNumItems)
			{
				int itemCount = selectedItems.Count();
				cartItems.RemoveAll(x => x.Name == this.ProductName);

				return new Tuple<List<Product>, double>(cartItems, itemCount * this.DroppedPrice);
			}

			return new Tuple<List<Product>, double>(cartItems, 0);
		}
	}
}
