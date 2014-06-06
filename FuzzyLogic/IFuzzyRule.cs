namespace FuzzyLogic
{
	public interface IFuzzyRule
	{
		void Calculate();
		void ResetConfidenceOfConsequence();
	}
}
