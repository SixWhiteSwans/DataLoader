using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Model;

namespace Core.Extensions
{
	public enum TenorDayTypes
	{
		Na=0,
		D=1,
		W=7,
		M=30,
		Y=360
	}

	public static class TenorToDays
	{
		public static int TenorPointToDays(this string tenor)
		{

			var queue = new Queue<string>(Regex.Split(tenor, @"(?<=['y', 'm', 'w', 'd])"));
			var filtered = queue.Where(x => !string.IsNullOrEmpty(x));

			return filtered.Sum(point =>
			{
				var multi = point.Substring(0, point.Length - 1);
				var code = point.Substring(point.Length - 1, 1);

				var days = TenorDayTypes.Na;
				Enum.TryParse(code.ToUpper(), true,out days);

				return (int)days * Convert.ToInt16(multi);

			});

		}

	}
}
