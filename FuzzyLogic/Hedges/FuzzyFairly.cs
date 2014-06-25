using System;
namespace FuzzyLogic.Hedges
{
	public class FuzzyFairly : IFuzzyTerm
	{
		private IFuzzySet _set;

		public double Value
		{
			get
			{
				return Math.Sqrt(_set.Value);
			}
			set
			{
				// Do nothing
			}
		}

		public FuzzyFairly(IFuzzySet set)
		{
			this._set = set;
		}

		public void ORWithValue(double p)
		{
			_set.ORWithValue(Value);
		}

		public void ClearValue()
		{
			_set.ClearValue();
		}
	}
}
