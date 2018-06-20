using System;
using System.Data;
using System.Threading.Tasks;
using Core.Model;

namespace Core.Interfaces
{
	public interface IDataLoaderPortfolioRisk
	{
		Task<T> LoadData<T>(ValidFileInfo fileInfo, Func<DataTable, string,DateTime, T> dataConsummer,DateTime valueDate);
	}
}
