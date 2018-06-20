using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
	public static class SerializeItem
	{
		public static MemoryStream Serialize<T>(this T t)
		{
			var memoryStream = new MemoryStream();
			var binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, t);

			return memoryStream;

		}

		public static T Deserialize<T>(this MemoryStream memoryStream)
		{

			var binaryFormatter = new BinaryFormatter();

			memoryStream.Position = 0;
			T returnValue = (T)binaryFormatter.Deserialize(memoryStream);

			memoryStream.Close();
			memoryStream.Dispose();

			return returnValue;

		}

	}
}
