using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyLogic.Tests
{
	[TestClass]
	public class IntegrationTests
	{
		private FuzzyModule _module;

		[TestInitialize]
		public void Initialize()
		{
			_module = new FuzzyModule();

			FuzzyVariable ammo = _module.CreateFLV("ammo");
			IFuzzySet ammoLow = ammo.AddLeftShoulderSet("low", 0, 2, 8);
			IFuzzySet ammoDecent = ammo.AddTriangularSet("decent", 2, 8, 16);
			IFuzzySet ammoPlenty = ammo.AddRightShoulderSet("plenty", 8, 16, 32);

			FuzzyVariable desirability = _module.CreateFLV("desirability");
			IFuzzySet undesirable = desirability.AddLeftShoulderSet("undesirable", 0, 25, 50);
			IFuzzySet desirable = desirability.AddTriangularSet("desirable", 25, 50, 75);
			IFuzzySet veryDesirable = desirability.AddRightShoulderSet("very_desirable", 50, 75, 100);

			// Desirability for reloading.
			_module.AddRule(ammoLow, veryDesirable);
			_module.AddRule(ammoDecent, desirable);
			_module.AddRule(ammoPlenty, undesirable);
		}

		[TestMethod]
		public void LowAmmo_DeFuzzify_HighDesirability()
		{
			_module.Fuzzify("ammo", 30);
			double value = _module.DeFuzzify("desirability", DefuzzifyType.MaxAv);
		}
	}
}
