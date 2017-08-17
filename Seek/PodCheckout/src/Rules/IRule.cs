using PodCheckout.src.Products;
using System;
using System.Collections.Generic;

namespace PodCheckout.src.Rules
{
	interface IRule
	{
		Tuple<List<Product>, double> execute(List<Product> cartItems);
	}
}
