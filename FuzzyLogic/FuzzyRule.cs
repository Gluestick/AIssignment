namespace FuzzyLogic
{
	public class FuzzyRule : IFuzzyRule
	{
		private IFuzzyTerm _condition;
		private IFuzzyTerm _consequence;

		public FuzzyRule(IFuzzyTerm condition, IFuzzyTerm consequence)
		{
			this._condition = condition;
			this._consequence = consequence;
		}

		public void ResetConfidenceOfConsequence()
		{
			_consequence.ClearValue();
		}

		public void Calculate()
		{
			_consequence.ORWithValue(_condition.Value);
		}
	}
}
