namespace FuzzyLogic.Hedges
{
	public class FuzzyVery : IFuzzyTerm
	{
		private IFuzzySet _set;

		public double Value
		{
			get { return _set.Value * _set.Value; }
		}

		public FuzzyVery(IFuzzySet set)
		{
			this._set = set;
		}

		public void ORWithValue(double p)
		{
			_set.ORWithValue(p * p);
		}

		public void ClearValue()
		{
			_set.ClearValue();
		}
	}
}
