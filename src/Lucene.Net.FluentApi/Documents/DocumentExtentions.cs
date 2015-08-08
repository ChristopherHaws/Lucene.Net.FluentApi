using System;
using System.Globalization;
using System.Linq;

namespace Lucene.Net.Documents
{
	public static class DocumentExtentions
	{
		public static StringFieldBuilder Add(this Document document, String value)
		{
			return new StringFieldBuilder(document, value);
		}

		public static Int32FieldBuilder Add(this Document document, Int32 value)
		{
			return new Int32FieldBuilder(document, value);
		}

		public static Int64FieldBuilder Add(this Document document, Int64 value)
		{
			return new Int64FieldBuilder(document, value);
		}

		public static BooleanFieldBuilder Add(this Document document, Boolean value)
		{
			return new BooleanFieldBuilder(document, value);
		}

		public static SingleFieldBuilder Add(this Document document, Single value)
		{
			return new SingleFieldBuilder(document, value);
		}

		public static DoubleFieldBuilder Add(this Document document, Double value)
		{
			return new DoubleFieldBuilder(document, value);
		}

		public static DateTimeFieldBuilder Add(this Document document, DateTime value)
		{
			return new DateTimeFieldBuilder(document, value);
		}

		public static SerializedObjectFieldBuilder Add(this Document document, Object value)
		{
			return new SerializedObjectFieldBuilder(document, value);
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
			
			if (Lucene.Net.Support.Single.TryParse(value, out result))
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
	}
}