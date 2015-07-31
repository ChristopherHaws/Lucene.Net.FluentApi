using System;

namespace Lucene.Net.Documents
{
	public static class DocumentExtentions
	{
		public static FieldBuilder AddField(this Document document, String name)
		{
			return new FieldBuilder(document, name);
		}

		public static String GetValue(this Document document, String name)
		{
			return document.Get(name);
		}
		public static DateTime GetDateTime(this Document document, String name, DateTimeKind kind)
		{
			var result = document.GetDateTimeOrNull(name, kind);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static DateTime? GetDateTimeOrNull(this Document document, String name, DateTimeKind kind)
		{
			var value = document.Get(name);

			DateTime result;

			if (!DateTime.TryParse(value, out result))
			{
				return null;
			}

			return new DateTime(result.Ticks, kind);
		}

		public static Boolean GetBoolean(this Document document, String name, DateTimeKind kind)
		{
			var result = document.GetBooleanOrNull(name);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static Boolean? GetBooleanOrNull(this Document document, String name)
		{
			var value = document.Get(name);
			Boolean result;

			if(!Boolean.TryParse(value, out result))
			{
				return null;
			}

			return result;
		}

		public static T? GetValue<T>(this Document doc, String name) where T : struct, IConvertible
		{
			var value = doc.GetValueOrNull<T>(name);

			if(value == null)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return value;
		}

		public static T? GetValueOrNull<T>(this Document doc, String name) where T : struct, IConvertible
		{
			var value = doc.Get(name);
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}

			if(typeof(T) == typeof(Boolean))
			{
				if(value == "1")
				{
					value = "True";
				}

				if (value == "0")
				{
					value = "False";
				}
			}

			return (T)Convert.ChangeType(value, typeof(T));
		}
	}
}