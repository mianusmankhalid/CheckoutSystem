using PodCheckout.src.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodCheckout.src.Rules
{
	public class Rule : IRule
	{
		public String ProductName { get; set; }

		public virtual Tuple<List<Product>, double> execute(List<Product> cartItems)
		{
			if (cartItems.Count > 0)
			{
				var item = cartItems.FirstOrDefault();
				cartItems.Remove(item);
				return new Tuple<List<Product>, double>(cartItems, item.Price);
			}

			return null;
		}
	}
}
