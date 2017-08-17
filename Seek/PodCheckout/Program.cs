using PodCheckout.src.Cart;
using PodCheckout.src.Products;
using PodCheckout.src.Rules;
using System;
using System.Collections.Generic;
using System.IO;

namespace PodCheckout
{
	class Program
	{
		static void Main(string[] args)
		{
			string pricing_rule_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", @"assets\pricing_rules.json");
			// Read the rules
			List<CustomerRule> fileRules = RuleHelper.ReadRules(pricing_rule_path);

			// Perform checkout
			Console.WriteLine("Total of cart is : " + Checkout.PerformCheckout(
				new List<Product>
				{
					new ClassicAd(),
					new StandoutAd(),
					new PremiumAd()
				},
				RuleHelper.GetRulesForCustomer("usman", fileRules)
			));

			Console.WriteLine("Total of cart is : " + Checkout.PerformCheckout(
				new List<Product>
				{
					new ClassicAd(),
					new ClassicAd(),
					new ClassicAd(),
					new PremiumAd()
				},
				RuleHelper.GetRulesForCustomer("unilever", fileRules)
			));

			Console.WriteLine("Total of cart is : " + Checkout.PerformCheckout(
				new List<Product>
				{
					new StandoutAd(),
					new StandoutAd(),
					new StandoutAd(),
					new PremiumAd()
				},
				RuleHelper.GetRulesForCustomer("apple", fileRules)
			));

			Console.WriteLine("Total of cart is : " + Checkout.PerformCheckout(
				new List<Product>
				{
					new PremiumAd(),
					new PremiumAd(),
					new PremiumAd(),
					new PremiumAd()
				},
				RuleHelper.GetRulesForCustomer("nike", fileRules)
			));
		}
	}
}
