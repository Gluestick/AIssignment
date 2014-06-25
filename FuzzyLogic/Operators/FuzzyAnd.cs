using System.Collections.Generic;

namespace FuzzyLogic.Operators
{
	public class FuzzyAnd : FuzzyOperator
	{
		public FuzzyAnd(IEnumerable<IFuzzyTerm> terms)
		{
			Operate(terms);
		}

		public override double Value
		{
			get
			{
				double smallest = float.MaxValue;
				foreach (IFuzzyTerm term in _terms)
				{
					if (term.Value < smallest)
					{
						smallest = term.Value;
					}
				}
				return smallest;
			}
		}
	}
}
