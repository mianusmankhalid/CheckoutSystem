﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace PodCheckout.src.Rules
{
	public class RuleHelper
	{
		public static List<Rule> GetRulesForCustomer(String customerName, IEnumerable<CustomerRule> allCustomerRules)
		{
			List<Rule> custRules = allCustomerRules
			.Where(x => x.CustomerName.Equals(customerName))
			.Select(o => o.Rule).ToList();

			custRules.Add(new Rule());
			return custRules;
		}

		public static List<CustomerRule> ReadRules(String filename)
		{
			dynamic ruleTupples = JsonConvert.DeserializeObject<List<ExpandoObject>>(
				new StreamReader(filename).ReadToEnd(),
				new ExpandoObjectConverter());

			List<CustomerRule> allRules = new List<CustomerRule>();

			foreach (var tup in ruleTupples)
			{
				var ruleTup = tup.rule;
				if (!tup.neglected)
				{
					allRules.Add(
					new CustomerRule()
					{
						CustomerName = tup.customer_name,
						Rule = RuleMaker.MakeRule(
							ruleTup.product_name,
							ruleTup.rule_type,
							ruleTup.rule_parameters)
					});
				}
			}
			return allRules;
		}
	}
}
