namespace FuzzyLogic
{
	public interface IFuzzyTerm
	{
		double Value { get; set; }
		void ORWithValue(double p);
		void ClearValue();
	}
}
