using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Core.Model;

namespace DataSource.Configuration
{
	public static class ConfigDataHandler
	{

		public static string SystemName = "AutoLoad";

		public static IEnumerable<LoaderConfig> GetDataConfig()
		{

			var loader = new List<LoaderConfig>
			{
				new LoaderConfig() { FileName = "PortfolioRiskData", FileType = FileTypes.Txt, Source = "PortfolioData" },
				
			};

			var updated = loader.Select(x => {
				x.FileLocation = ConfigurationManager.AppSettings[x.FileName];

				return x;
			});

			return updated;
		}
		public static IEnumerable<LoaderConfig> GetSaveDataConfig()
		{

			var loader = new List<LoaderConfig>
			{
				new LoaderConfig() { FileName = "PortfolioRiskResults", FileType = FileTypes.Txt, Source = "PortfolioRiskResults" },

			};

			var updated = loader.Select(x => {
				x.FileLocation = ConfigurationManager.AppSettings[x.FileName];

				return x;
			});

			return updated;
		}


	}
}
