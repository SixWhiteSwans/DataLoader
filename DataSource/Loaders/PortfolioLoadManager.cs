using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;
using Core.Securities;
using Core.Utils;
using DataSource.Loaders;


namespace DataSource.Providers
{
	public static class PortfolioLoadManager
	{

		//validate path/load,validate portfolio data /sort/print

		private static readonly TxtLoader Loader = new TxtLoader();
	
		public static ValidFileInfo GetValidationInfo(LoaderConfig loaderConfig, IProgress<ProgressManager> progress)
		{
			var validFileInfo = new ValidFileInfo(loaderConfig.FileLocation, loaderConfig.Source, FileTypes.Txt);

			if (progress != null)
				validFileInfo.ProgressLogger = progress;


			return validFileInfo;
		}

		public static async Task<Portfolios> GetData(ValidFileInfo validFileInfo,DateTime valueDate)
		{

			Func<DataTable, string, DateTime, Portfolios> consummer = PortfolioLoadingDelegate.Process;
			return await Loader.LoadData(validFileInfo, consummer,valueDate);

		}

		public static IEnumerable<ValidPortfolioRisk> ValidatedPortfolioRisk(IEnumerable<PortfolioRisk> portfolioRisks)
		{
			return portfolioRisks.Select(pr => new ValidPortfolioRisk(pr));
		}


		



	}
}
