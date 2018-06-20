using System;

namespace Core.Model
{
	public class ProgressManager
	{
		public int Progress { get; set; }
		public Guid Guid { get; set; }
		public DateTime TimeStamp { get; set; }
		public string Message { get; set; }

		public string Action { get; set; }
	}
}
