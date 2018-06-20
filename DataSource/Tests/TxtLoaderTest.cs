using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;
using Core.Securities;
using DataSource.Loaders;
using NUnit.Framework;

namespace DataSource.Tests
{
	[TestFixture]
	public class TxtLoaderTest
	{
		//todo 
		//can the file creation to make the tests shorter.
		//apply these tests to the operation tests cases.

		private readonly IDataLoaderPortfolioRisk _dataLoader = new TxtLoader();
		private string _filePath;
		private ValidFileInfo _validFileInfo;
		[SetUp]
		public void Setup()
		{
			var fileName = ConfigurationManager.AppSettings["POrtfolioData"];
			_filePath = @"D: \DataLoader\Data\";
		}

		[TestCase("Data.txt", "PortfolioRiskData")]
		public void LoadSecurities(string fileName, string source)
		{
			var fileLocation = string.Concat(_filePath, fileName);
			_validFileInfo = new ValidFileInfo(fileLocation, source, FileTypes.Csv);


			var valueDate = DateTime.Today.Date;

			Func<DataTable, string, DateTime, Portfolios> consummer = PortfolioLoadingDelegate.Process;

			Task<Portfolios> result = _dataLoader.LoadData(_validFileInfo, consummer,valueDate);
			result.Wait();

			var list = result.Result.ToList();

			Assert.Greater(list.Count, 0);

			list.ForEach(p =>
			{
				
				Assert.IsNotEmpty(p.Tenor);
				Assert.Greater(p.PortfolioId,0);
				
			});

		}
	}
}
