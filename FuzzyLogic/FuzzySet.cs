﻿using System;

namespace FuzzyLogic
{
	public abstract class FuzzySet : IFuzzySet
	{
		protected double _peakPoint;
		protected double _minOffset;
		protected double _maxOffset;
		protected double _value;
		private double _repVal;

		public FuzzySet(
			double repVal, double peak, double minOffset, double maxOffset)
		{
			ClearValue();
			_peakPoint = peak;
			_minOffset = minOffset;
			_maxOffset = maxOffset;
			_repVal = repVal;
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
			this._value = 0;
		}


		public double RepresentativeValue
		{
			get
			{
				return this._repVal;
			}
		}
	}
}
