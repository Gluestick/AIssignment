using System;

namespace FuzzyLogic
{
	public abstract class FuzzySet : IFuzzySet
	{
		protected double _peakPoint;
		protected double _minOffset;
		protected double _maxOffset;
		protected double _value;
		private double _repValue;

		public FuzzySet(
			double repVal, double peak, double minOffset, double maxOffset)
		{
			ClearValue();
			_peakPoint = peak;
			_minOffset = minOffset;
			_maxOffset = maxOffset;
			_repValue = repVal;
		}

		public double Min
		{
			get { return _minOffset; }
		}

		public double Max
		{
			get { return _maxOffset; }
		}

		public abstract double CalculateValue(double value);

		public double Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public double Peak
		{
			get { return _peakPoint; }
		}


		public void ORWithValue(double value)
		{
			if (this._value < value)
			{
				this._value = value;
			}
		}

		public void ClearValue()
		{
			throw new NotImplementedException();
		}


		public double RepresentativeValue
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
