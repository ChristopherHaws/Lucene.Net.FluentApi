using System;

namespace Lucene.Net.Fluent.Extentions
{
	internal static class TypeExtentions
	{
		public static Type GetUnderlyingType(this Type type)
		{
			return Nullable.GetUnderlyingType(type) ?? type;
		}
	}
}