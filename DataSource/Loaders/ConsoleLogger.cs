using System;
using Core.Model;

namespace DataSource.Loaders
{
	public static class ConsoleLogger
	{

		public static void ProcessDataLogMessage(ProgressManager progress)
		{
		
			Console.WriteLine(progress.Message);
		}


	}
}
