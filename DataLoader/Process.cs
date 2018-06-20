using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using DataSource.Configuration;
using DataSource.Loaders;
using DataSource.Providers;

namespace DataLoader
{
	public static class Process
	{
		public static async Task<ContextLoaderDataValidation> RunPortfolioLoader(DateTime valueDate)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Console.WriteLine("Batch Loader Started");
			

			var result =  await BatchJob.RunTickerLoader(valueDate);
			stopwatch.Stop();
			Console.WriteLine($"Batch Loader Completed:  Total Seconds {stopwatch.Elapsed.TotalSeconds}");

			return result;

		}



	}
}
