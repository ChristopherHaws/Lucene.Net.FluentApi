using System;
using System.Globalization;
using System.Linq;

namespace Lucene.Net.Documents
{
	public static class DocumentExtentions
	{
		public static FieldBuilder AddField(this Document document, String name)
		{
			return new FieldBuilder(document, name);
		}

		public static String GetString(this Document document, String name)
		{
			var result = document.Get(name);

			if (result == null)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result;
		}
		public static String GetStringOrNull(this Document document, String name)
		{
			return document.Get(name);
		}

		public static Int32 GetInt32(this Document document, String name)
		{
			var result = document.GetInt32OrNull(name);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static Int32? GetInt32OrNull(this Document document, String name)
		{
			var value = document.Get(name);

			Int32 result;

			if (!Int32.TryParse(value, out result))
			{
				return null;
			}

			return result;
		}

		public static Int64 GetInt64(this Document document, String name)
		{
			var result = document.GetInt64OrNull(name);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static Int64? GetInt64OrNull(this Document document, String name)
		{
			var value = document.Get(name);

			Int64 result;

			if (!Int64.TryParse(value, out result))
			{
				return null;
			}

			return result;
		}

		public static Single GetSingle(this Document document, String name)
		{
			var result = document.GetSingleOrNull(name);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static Single? GetSingleOrNull(this Document document, String name)
		{
			var value = document.Get(name);

			Single result;

			if (Single.TryParse(value, out result))
			{
				return result;
			}

			if (value == Single.MaxValue.ToString(CultureInfo.InvariantCulture))
			{
				return Single.MaxValue;
			}

			if (value == Single.MinValue.ToString(CultureInfo.InvariantCulture))
			{
				return Single.MinValue;
			}

			return null;
		}

		public static Double GetDouble(this Document document, String name)
		{
			var result = document.GetDoubleOrNull(name);

			if (!result.HasValue)
			{
				throw new InvalidOperationException("Document does not contain a field named " + name);
			}

			return result.Value;
		}

		public static Double? GetDoubleOrNull(this Document document, String name)
		{
			var value = document.Get(name);

			Double result;

			if (Double.TryParse(value, out result))
			{
				return result;
			}

			if (value == Double.MaxValue.ToString(CultureInfo.InvariantCulture))
			{
				return Double.MaxValue;
			}

			if (value == Double.MinValue.ToString(CultureInfo.InvariantCulture))
			{
				return Double.MinValue;
			}

			return null;
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

			Int64 result;

			if (!Int64.TryParse(value, out result))
			{
				return null;
			}

			return new DateTime(result, kind);
		}

		public static Boolean GetBoolean(this Document document, String name)
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

			if (new[] { "0", "1" }.Contains(value))
			{
				return value == "1";
			}

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