using System;
using System.Linq;
using Core.Securities;

namespace Core.Model
{
	public struct ValidPortfolioRisk
	{

		private static readonly char[] ValidCodes ={ 'y', 'm','w','d'};
		public PortfolioRisk Value { get; }

		public bool IsValid { get; }

		public string ErrorMessage { get; }

		public ValidPortfolioRisk(PortfolioRisk portfolioRisk)
		{
			IsValid = true;
			ErrorMessage = string.Empty;

			//if (string.IsNullOrEmpty(portfolioRisk.Tenor))
			//{
			//	ErrorMessage = "The tenor code is not valid";
			//	IsValid = false;
				
			//}

			var result = portfolioRisk.Tenor.ToCharArray().Where(x => !ValidCodes.Any(y => y.Equals(x)) && !Char.IsNumber(x));
			if (result.Any())
			{
				ErrorMessage = "The tenor code is not valid";
				IsValid = false;
			}

			//validate order
			var codes = portfolioRisk.Tenor.Where(x => Char.IsLetter(x));
			
			var ordered = ValidCodes.Where(x => codes.Any(y => y.Equals(x)));


			var sequenceEqual = ordered.SequenceEqual(codes.ToList());
			if (!sequenceEqual)
			{
				ErrorMessage = "The tenor code sequency is not correct";
				IsValid = false;

			}

			Value = portfolioRisk;
		}


	}
}
