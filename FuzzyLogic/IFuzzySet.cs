namespace FuzzyLogic
{
	public interface IFuzzySet : IFuzzyTerm
	{
		double Min { get; }
		double Max { get; }
		double CalculateValue(double value);
		double RepresentativeValue { get; set; }
		double Peak { get; }
	}
}
