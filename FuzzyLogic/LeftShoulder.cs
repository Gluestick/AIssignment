﻿namespace FuzzyLogic
{
	public class LeftShoulder : FuzzySet
	{
		public LeftShoulder(double peak, double minOffset, double maxOffset)
			: base(((peak - minOffset) + peak) / 2, peak, minOffset, maxOffset)
		{
		}

		public override double CalculateValue(double value)
		{
			if ((_minOffset == 0.0 && _peakPoint == value) ||
				(_maxOffset == 0.0 && _peakPoint == value))
			{
				return 1.0;
			}
			else if (value >= _peakPoint && value < (_peakPoint + _maxOffset))
			{
				double grad = 1.0 / -_maxOffset;
				return grad * (value - _peakPoint) + 1.0;
			}
			else if (value < _peakPoint && value >= (_peakPoint - _minOffset))
			{
				return 1.0;
			}
			else
			{
				return 0.0f;
			}
		}
	}
}
