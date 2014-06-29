using System.Collections.Generic;

namespace FuzzyLogic.Operators
{
	public class FuzzyOr : FuzzyOperator
	{
		public FuzzyOr(params IFuzzyTerm[] terms)
		{
			Operate(terms);
		}

		public override double Value
		{
			get
			{
				double highest = double.MinValue;
				foreach (IFuzzyTerm term in _terms)
				{
					if (term.Value > highest)
					{
						highest = term.Value;
					}
				}
				return highest;
			}
		}
	}
}