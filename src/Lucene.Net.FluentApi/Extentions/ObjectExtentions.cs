using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lucene.Net.Fluent.Extentions
{
	internal static class ObjectExtentions
	{
		private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

		/// <summary>
		/// Binaries the serialize.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		internal static byte[] BinarySerialize(this object input)
		{
			if (input == null)
			{
				return null;
			}

			using (var stream = new MemoryStream())
			{
				BinaryFormatter.Serialize(stream, input);
				return stream.ToArray();
			}
		}

		/// <summary>
		/// Binaries the deserialize.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		internal static T BinaryDeserialize<T>(this byte[] input)
		{
			if (input == null)
			{
				return default(T);
			}

			using (var ms = new MemoryStream(input))
			{
				object obj = BinaryFormatter.Deserialize(ms);
				if (obj is T)
				{
					return (T)obj;
				}

				return default(T);
			}
		}
	}
}
