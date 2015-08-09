using System;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	internal static class TypeExtentions
	{
		public static Type GetUnderlyingType(this Type type)
		{
			return Nullable.GetUnderlyingType(type) ?? type;
		}
	}
}