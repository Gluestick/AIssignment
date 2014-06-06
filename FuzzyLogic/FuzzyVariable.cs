﻿using System.Collections.Generic;

namespace FuzzyLogic
{
	public class FuzzyVariable
	{
		private IDictionary<string, IFuzzySet> _memberSets;
		private double _min;
		private double _max;

		public FuzzyVariable()
		{
			_memberSets = new Dictionary<string, IFuzzySet>();
		}

		public void AddSet(string name, IFuzzySet set)
		{
			if (_memberSets.ContainsKey(name))
			{
				_memberSets[name] = set;
			}
			else
			{
				_memberSets.Add(name, set);
			}

			if (_min > set.Min)
			{
				_min = set.Min;
			}
			if (_max < set.Max)
			{
				_max = set.Max;
			}
		}

		public void Fuzzify(double value)
		{
			foreach (IFuzzySet set in _memberSets.Values)
			{
				set.Value = set.CalculateValue(value);
			}
		}

		public double DeFuzzifyMaxAv()
		{
			double bottom = 0;
			double top = 0;

			foreach (IFuzzySet set in _memberSets.Values)
			{
				bottom += set.Value;
				top += set.Peak * set.Value;
			}
			if (bottom == 0)
			{
				return 0;
			}
			return top / bottom;
		}

		public IFuzzySet AddTriangularSet(
			string name, double min, double peak, double max)
		{
			IFuzzySet set = new Triangle(peak, peak - min, max - peak);
			AddSet(name, set);
			return set;
		}

		public IFuzzySet addLeftShoulderSet(string name, float min, float peak, float max) {
			IFuzzySet set = new LeftShoulder(peak, peak - min, max - peak);
			AddSet(name, set);
			return set;
		}

		public IFuzzySet addRightShoulderSet(string name, float min, float peak, float max) {
			IFuzzySet set = new RightShoulder(peak, peak - min, max - peak);
			AddSet(name, set);
			return set;
		}
	}
}
