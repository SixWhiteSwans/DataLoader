using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
	public class LoaderConfig
	{
		public string FileName { get; set; }
		public FileTypes FileType { get; set; }

		public string FileLocation { get; set; }

		public string Source { get; set; }

	}
}
