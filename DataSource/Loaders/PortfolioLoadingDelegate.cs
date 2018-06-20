using System;
using System.Data;
using System.Diagnostics;
using Core.Securities;
using DataSource.Configuration;

namespace DataSource.Loaders
{
	public static class PortfolioLoadingDelegate
	{
		public static Portfolios Process(DataTable table, string source,DateTime valueDate)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var portfolios = new Portfolios { Source = source };

			var tenorCol = table.Columns["tenor"];
			var portfolioidCol = table.Columns["portfolioid"];
			var valueCol = table.Columns["value"];

			
			var sql = "tenor is not null AND portfolioid <> 0";

			//remove any null rows. Its assumed all other data is valid that has been saved to file.
			var rows = table.Select(sql);

			//todo: AsParallel() this read.
			foreach (DataRow tableRow in rows)
			{

				var tenor = tableRow[tenorCol].ToString();
				var portfolioid = Utils.SafeCastToIntParse(tableRow[portfolioidCol].ToString());
				var value = Utils.SafeCastToDoubleParse(tableRow[valueCol].ToString());

				var pr = new PortfolioRisk()
				{
					Tenor = tenor,
					PortfolioId = portfolioid,
					Value = value,
					ValueDate = valueDate,
					Source = source,
					LastUpdated = ConfigDataHandler.SystemName,
					UpdateDate = DateTime.UtcNow
				};
				portfolios.Add(pr);
			}


			stopWatch.Stop();
			portfolios.LoadTime = stopWatch.Elapsed;

			return portfolios;

		}
	}
}
