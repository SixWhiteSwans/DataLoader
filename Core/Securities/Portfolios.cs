using System;
using System.Collections.Concurrent;

namespace Core.Securities
{
	public class Portfolios:BlockingCollection<PortfolioRisk>
	{
		public string Source { get; set; }

		public TimeSpan LoadTime { get; set; }

	}
}
