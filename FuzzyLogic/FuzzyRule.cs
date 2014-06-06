namespace FuzzyLogic
{
	public class FuzzyRule
	{
		private FuzzyTerm _condition;
		private FuzzyTerm _consequence;

		public FuzzyRule(FuzzyTerm condition, FuzzyTerm consequence)
		{
			this._condition = condition;
			this._consequence = consequence;
		}

		internal void ResetConfidenceOfConsequence()
		{
			throw new System.NotImplementedException();
		}

		internal void Calculate()
		{
			throw new System.NotImplementedException();
		}
	}
}
