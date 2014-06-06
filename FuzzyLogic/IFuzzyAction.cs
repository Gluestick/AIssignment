namespace FuzzyLogic
{
	public interface IFuzzyAction<T>
	{
		double CalculateDesirability(T instance);
	}
}
