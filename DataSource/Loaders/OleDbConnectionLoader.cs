using System;
using System.Data;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;

namespace DataSource.Loaders
{
	public class OleDbConnectionLoader : IDataLoaderPortfolioRisk
	{

		public async Task<T> LoadData<T>(ValidFileInfo fileInfo,Func<DataTable,string,DateTime,T> dataConsummer,DateTime valueDate)
		{
			


			//return await Task.Run(() =>
			//{
				try
				{

					var oleDbConnectionString = new OleDbConnectionString(fileInfo);

					var progressItem = new ProgressManager
					{
						TimeStamp = DateTime.UtcNow,
						Progress = 1,
						Action = "OleDbLoader Load data: ",
						Message = "OleDbLoader Loader Load data started:" + fileInfo.Source
					};

					oleDbConnectionString.ValidFileInfo.ProgressLogger?.Report(progressItem);

					var oledbConn = new System.Data.OleDb.OleDbConnection(oleDbConnectionString.Value);
					var command = new System.Data.OleDb.OleDbDataAdapter(oleDbConnectionString.Sql, oledbConn);
					command.TableMappings.Add("Table", "LoadTable");
					var dtSet = new DataSet();
					command.Fill(dtSet);
					var table = dtSet.Tables[0];

					var portfolios = dataConsummer.Invoke(table, fileInfo.Source,valueDate); 
					
					oledbConn.Close();
					
					progressItem = new ProgressManager
					{
						TimeStamp = DateTime.UtcNow,
						Progress = 1,
						Action = "OleDbLoader Load data",
						Message = "OleDbLoader Loader Load data stopped" + fileInfo.Source
					};

					oleDbConnectionString.ValidFileInfo.ProgressLogger?.Report(progressItem);

					return portfolios;



				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}



				return default(T);

			//});
		}


		

	}
}
