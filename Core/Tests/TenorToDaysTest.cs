using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Core.Extensions;
using NUnit.Framework;

namespace Core.Tests
{
	[TestFixture]
	public class TenorToDaysTest
	{
		[Test]
		public void SplitTest()
		{

			var tenor = "2y11m1w2d";
			var queue = new Queue<string>(Regex.Split(tenor, @"(?<=['y', 'm', 'w', 'd])"));
			
			Assert.GreaterOrEqual(5,queue.Count);

		}

		[TestCase("1y", ExpectedResult = 360)]
		[TestCase("1m", ExpectedResult = 30)]
		[TestCase("1w", ExpectedResult = 7)]
		[TestCase("1d",ExpectedResult = 1)]
		public int SinglePeriod(string tenor)
		{
			return tenor.TenorPointToDays();
		}

		[TestCase("2y11m1w2d", ExpectedResult = 1059)]		
		public int MultiPeriod(string tenor)
		{
			return tenor.TenorPointToDays();
		}

		[TestCase("1y6m1w2d", ExpectedResult = 549)]
		[TestCase("1y6m2d", ExpectedResult = 542)]
		public int MultiPeriod2(string tenor)
		{
			return tenor.TenorPointToDays();
		}
		

		[Test]
		public void MultiPeriod3()
		{
			string tenor = "1y6m1w2d";
			var days=  tenor.TenorPointToDays();
		}

	}
}
