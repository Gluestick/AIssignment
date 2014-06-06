using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
	public class LeftShoulder : IFuzzySet
	{
		private float peak;
		private float p1;
		private float p2;

		public LeftShoulder(float peak, float p1, float p2)
		{
			// TODO: Complete member initialization
			this.peak = peak;
			this.p1 = p1;
			this.p2 = p2;
		}

		public double Min
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double Max
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double CalculateValue(double value)
		{
			throw new NotImplementedException();
		}

		public double Value
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

		public double Peak
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
