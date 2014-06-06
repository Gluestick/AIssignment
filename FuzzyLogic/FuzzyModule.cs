using System.Collections.Generic;

namespace FuzzyLogic
{
	public class FuzzyModule
	{
		private IDictionary<string, FuzzyVariable> _variables;
		private ICollection<FuzzyRule> _rules;

		public FuzzyModule()
		{
			_variables = new Dictionary<string, FuzzyVariable>();
			_rules = new List<FuzzyRule>();
		}

		public FuzzyVariable CreateFLV(string name)
		{
			_variables.Add(name, new FuzzyVariable());
			return _variables[name];
		}

		public void AddRule(IFuzzyTerm condition, IFuzzyTerm consequence)
		{
			_rules.Add(new FuzzyRule(condition, consequence));
		}

		public void Fuzzify(string flv, double value)
		{
			_variables[flv].Fuzzify(value);
		}

		public double DeFuzzify(string flv, DefuzzifyType method)
		{
			ResetConfidenceOfConsequence();

			foreach (FuzzyRule rule in _rules)
			{
				rule.Calculate();
			}

			switch (method)
			{
			case DefuzzifyType.MaxAv:
				return _variables[flv].DeFuzzifyMaxAv();
			}
			return 0;
		}

		private void ResetConfidenceOfConsequence()
		{
			foreach (FuzzyRule rule in _rules)
			{
				rule.ResetConfidenceOfConsequence();
			}
		}
	}
}
