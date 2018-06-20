using Core.Model;
using Core.Securities;
using NUnit.Framework;

namespace Core.Tests
{
	[TestFixture]
	public class ValidPortfolioRiskTest
	{
		//todo: also make the y,m,w,d order fixed
		[Test]
		public void ValidTenor()
		{
			var tenor = "2y11m1w2d";

			var pr = new PortfolioRisk() {Tenor = tenor};

			var vt = new ValidPortfolioRisk(pr);			
			StringAssert.AreEqualIgnoringCase(tenor, vt.Value.Tenor);



		}
		[Test]
		public void InValidTenor()
		{
			var tenor = "2x11f1w2d";
			var pr = new PortfolioRisk() { Tenor = tenor };
			var vpr = new ValidPortfolioRisk(pr);
			Assert.IsFalse(vpr.IsValid);
			
			//var ex = Assert.Throws<ArgumentException>(() => new ValidPortfolioRisk(pr));
			//StringAssert.AreEqualIgnoringCase("The tenor code is not valid", ex.Message);

		}
		[TestCase("1d3m", ExpectedResult = false)]
		public bool InValidTenorAsInWrongOrder(string tenor)
		{
			tenor = "1d3m";
			var pr = new PortfolioRisk() { Tenor = tenor };
			var vpr = new ValidPortfolioRisk(pr);
 			return vpr.IsValid;

			//var ex = Assert.Throws<ArgumentException>(() => new ValidPortfolioRisk(pr));
			//StringAssert.AreEqualIgnoringCase("The tenor code is not valid", ex.Message);
			}


		[TestCase("3m1w1d", ExpectedResult = true)]
		[TestCase("3m1d", ExpectedResult = true)]
		[TestCase("3y1d", ExpectedResult = true)]
		[TestCase("3y2w1d", ExpectedResult = true)]

		public bool ValidTenorAsInWrongOrder(string tenor)
		{
			tenor = "3m1d";
			var pr = new PortfolioRisk() { Tenor = tenor };
			var vpr = new ValidPortfolioRisk(pr);
			 return  vpr.IsValid;

		}

		//var ex = Assert.Throws<ArgumentException>(() => new ValidPortfolioRisk(pr));
		//StringAssert.AreEqualIgnoringCase("The tenor code is not valid", ex.Message);

	}
}
