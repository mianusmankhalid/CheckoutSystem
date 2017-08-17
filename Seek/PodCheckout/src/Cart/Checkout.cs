using PodCheckout.src.Products;
using PodCheckout.src.Rules;
using System.Collections.Generic;

namespace PodCheckout.src.Cart
{
	public class Checkout
	{
		public static double PerformCheckout(List<Product> items, List<Rule> pricingRules)
		{
			if (items.Count == 0)
			{
				return 0;
			}

			double ratio = double.MaxValue;
			List<Product> remainingItems = items;
			double consumptionPrice = double.MinValue;

			foreach (var rule in pricingRules)
			{
				var executeResult = rule.execute(new List<Product>(items));
				var consumedItems = items.Count - executeResult.Item1.Count;

				var consumptionRatio = executeResult.Item2/ consumedItems;
				if (consumptionRatio < ratio)
				{
					ratio = consumptionRatio;
					remainingItems = executeResult.Item1;
					consumptionPrice = executeResult.Item2;
				}
			}

			return PerformCheckout(remainingItems, pricingRules) + consumptionPrice;
		}
	}
}
