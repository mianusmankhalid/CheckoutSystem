using PodCheckout.src.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodCheckout.src.Rules
{
	public class Discount : Rule
	{
		public int Purchased { get; set; }
		public int ChargedFor { get; set; }

		public override Tuple<List<Product>, double> execute(List<Product> cartItems)
		{
			var selectedItems = cartItems.Where(x => x.Name == this.ProductName);
			double itemPrice = 0;

			if (selectedItems.Any())
				itemPrice = selectedItems.FirstOrDefault().Price;

			if (selectedItems.Count() >= this.Purchased)
			{
				for (int i = 0; i < this.Purchased; i++)
				{
					cartItems.Remove(cartItems.FirstOrDefault(x => x.Name == this.ProductName));
				}

				return new Tuple<List<Product>, double>(cartItems, itemPrice * this.ChargedFor);
			}

			return new Tuple<List<Product>, double>(cartItems, 0);
		}
	}
}
