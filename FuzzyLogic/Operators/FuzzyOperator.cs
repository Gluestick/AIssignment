using System.Collections.Generic;

namespace FuzzyLogic.Operators
{
	public abstract class FuzzyOperator : IFuzzyTerm
	{
		protected ICollection<IFuzzyTerm> _terms;

		public abstract double Value { get; }

		public FuzzyOperator()
		{
			_terms = new List<IFuzzyTerm>();
		}

		public void Operate(IEnumerable<IFuzzyTerm> terms)
		{
			foreach (IFuzzyTerm term in terms)
			{
				_terms.Add(term);
			}
		}

		public void ORWithValue(double p)
		{
			foreach (IFuzzyTerm term in _terms)
			{
				term.ORWithValue(p);
			}
		}

		public void ClearValue()
		{
			foreach (IFuzzyTerm term in _terms)
			{
				term.ClearValue();
			}
		}
	}
}
