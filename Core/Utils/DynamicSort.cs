using System.Linq;
using System.Linq.Dynamic;

namespace Core.Utils
{
	public static class DynamicSort
	{
		public static IQueryable Sort(this IQueryable collection, string sortBy)
		{
			return collection.OrderBy(sortBy);
		}
	}
}
