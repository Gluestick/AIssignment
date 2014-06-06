namespace FuzzyLogic
{
	public class LeftShoulder : FuzzySet
	{
		public LeftShoulder(double peak, double minOffset, double maxOffset)
			: base(((peak - minOffset) + peak) / 2, peak, minOffset, maxOffset)
		{
		}

		public override double CalculateValue(double value)
		{
			if ((_minOffset == 0f && _peakPoint == value) ||
				(_maxOffset == 0f && _peakPoint == value))
			{
				return 1f;
			}
			else if (value >= _peakPoint && value < (_peakPoint + _maxOffset))
			{
				double grad = 1.0f / -_maxOffset;
				return grad * (value - _peakPoint) + 1.0f;
			}
			else if (value < _peakPoint && value >= (_peakPoint - _minOffset))
			{
				return 1.0f;
			}
			else
			{
				return 0.0f;
			}
		}
	}
}
