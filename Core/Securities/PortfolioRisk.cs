using System;
using Core.Extensions;

namespace Core.Securities
{
	public class PortfolioRisk
	{

		public DateTime RunDate { get; set; }
		public DateTime ValueDate { get; set; }
		
		public int PortfolioId { get; set; }

		public string Tenor { get; set; }

		public int TenorDays => Tenor.TenorPointToDays();


		public double Value { get; set; }

		public string LastUpdated { get; set; }

		public string Source { get; set; }

		public DateTime UpdateDate { get; set; }

		public override string ToString()
		{
			return $"{Tenor},{PortfolioId},{Value}";
		}
	}
}
