using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
	class Triangle : IFuzzySet
	{
		private double peak;
		private double p1;
		private double p2;

		public Triangle(double peak, double p1, double p2)
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
