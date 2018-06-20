using System;
using System.Collections.Generic;
using System.IO;
using Core.Model;
using Core.Securities;

namespace DataSource.Providers
{
	public static class ContextManager
	{

		public static void PopulateData(LoaderConfig loaderConfig, IEnumerable<PortfolioRisk> portfolioRisks)
		{
			
			if (!Directory.Exists(loaderConfig.FileLocation))
				Directory.CreateDirectory(loaderConfig.FileLocation);

			using (TextWriter tw = new StreamWriter(loaderConfig.FileLocation + loaderConfig.FileName))
			{
				foreach (var item in portfolioRisks)
				{
					tw.WriteLine(item.ToString());
				}
			}

		}

	}
}
