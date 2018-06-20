using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;
using Core.Model;
using Core.Securities;
using Core.Utils;
using DataSource.Configuration;
using DataSource.Providers;


namespace DataSource.Loaders
{
	public class BatchJob
	{

		public static async Task<ContextLoaderDataValidation> RunTickerLoader(DateTime valueDate)
		{
			
			var progress = new Progress<ProgressManager>(ConsoleLogger.ProcessDataLogMessage);

			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var configData = ConfigDataHandler.GetDataConfig();
			

			var validFileInfo = PortfolioLoadManager.GetValidationInfo(configData.First(), progress);
			var data = await PortfolioLoadManager.GetData(validFileInfo, valueDate);

			var validatedRisk = PortfolioLoadManager.ValidatedPortfolioRisk(data);
			
			var filteredValidatedPortfolioRisk = validatedRisk.Where(x => x.IsValid).Select(x => x.Value);


			var configSaveData = ConfigDataHandler.GetSaveDataConfig();
			var validSaveFileInfo =  configSaveData.SingleOrDefault(x => x.Source.Equals("PortfolioRiskResults"));



			validSaveFileInfo.FileName = "3.txt";			
			SaveData(filteredValidatedPortfolioRisk.AsQueryable().Sort("TenorDays,PortfolioId").OfType<PortfolioRisk>().ToList(),
				validSaveFileInfo);



			validSaveFileInfo.FileName = "4.txt";			
			SaveData(filteredValidatedPortfolioRisk.AsQueryable().Sort("PortfolioId,TenorDays").OfType<PortfolioRisk>(),
				validSaveFileInfo);


			stopWatch.Stop();

			Console.WriteLine("Total seconds:" + stopWatch.Elapsed.TotalSeconds);
			return new ContextLoaderDataValidation(true, string.Empty);

		}


		private static void SaveData(IEnumerable<PortfolioRisk> portfolioRisks, LoaderConfig loaderConfig)
		{


			ContextManager.PopulateData(loaderConfig, portfolioRisks);

		}


	}
}
