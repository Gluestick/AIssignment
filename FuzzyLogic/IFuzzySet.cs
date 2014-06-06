namespace FuzzyLogic
{
	public interface IFuzzySet
	{
		double Min { get; }
		double Max { get; }
		double CalculateValue(double value);
		double Value { get; set; }
		double Peak { get; }
	}
}
