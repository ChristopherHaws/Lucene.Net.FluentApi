using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lucene.Net.Fluent.Extentions;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class FieldAttributeReflector
	{
		private static readonly Dictionary<Type, PropertyInfo[]> CachedProperties = new Dictionary<Type, PropertyInfo[]>();

		public IEnumerable<FieldAttributeInfoWithValue<FieldAttribute>> GetFieldAttributeInfosWithValues(Type type, Object value)
		{
			return
				from property in GetProperties(type)
				from attribute in property.GetCustomAttributes<FieldAttribute>(true)
				select new FieldAttributeInfoWithValue<FieldAttribute>
				{
					Name = property.Name,
					Value = property.GetValue(value, null),
					Settings = attribute
				};
		}

		public IEnumerable<FieldAttributeInfoWithValue<FieldAttribute>> GetFieldAttributeInfosWithValues<T>(Object value)
		{
			return this.GetFieldAttributeInfosWithValues(typeof (T), value);
		}

		public IEnumerable<FieldAttributeInfo<FieldAttribute>> GetFieldAttributeInfos(Type type)
		{
			return
				from property in GetProperties(type)
				from attribute in property.GetCustomAttributes<FieldAttribute>(true)
				select new FieldAttributeInfo<FieldAttribute>
				{
					Name = property.Name,
					Settings = attribute
				};
		}

		public IEnumerable<FieldAttributeInfo<FieldAttribute>> GetFieldAttributeInfos<T>()
		{
			return this.GetFieldAttributeInfos(typeof(T));
		}

		public IEnumerable<FieldAttributeInfoWithValue<NumericFieldAttribute>> GetNumericFieldAttributeInfosWithValues(Type type, Object value)
		{
			return
				from property in GetProperties(type)
				from attribute in property.GetCustomAttributes<NumericFieldAttribute>(true)
				select new FieldAttributeInfoWithValue<NumericFieldAttribute>
				{
					Name = property.Name,
					Value = property.GetValue(value, null),
					Settings = attribute
				};
		}

		public IEnumerable<FieldAttributeInfoWithValue<NumericFieldAttribute>> GetNumericFieldAttributeInfosWithValues<T>(Object value)
		{
			return this.GetNumericFieldAttributeInfosWithValues(typeof(T), value);
		}

		private static PropertyInfo[] GetProperties(Type type)
		{
			PropertyInfo[] properties;

			if (!FieldAttributeReflector.CachedProperties.TryGetValue(type, out properties))
			{
				properties = type.GetProperties();
				FieldAttributeReflector.CachedProperties.Add(type, properties);
			}

			return properties;
		}
	}
}