namespace FuzzyLogic
{
	public interface IFuzzyTerm
	{
		double Value { get; }
		void ORWithValue(double p);
		void ClearValue();
	}
}
