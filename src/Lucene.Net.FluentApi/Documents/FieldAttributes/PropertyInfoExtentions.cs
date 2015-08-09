using System.Linq;
using System.Reflection;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public static class PropertyInfoExtentions
	{
		public static T GetCustomAttribute<T>(this PropertyInfo property, bool inherit) where T : class
		{
			return property.GetCustomAttributes<T>(inherit).SingleOrDefault();
		}

		public static T[] GetCustomAttributes<T>(this PropertyInfo property, bool inherit) where T : class
		{
			return property.GetCustomAttributes(typeof(T), inherit).Cast<T>().ToArray();
		}
	}
}