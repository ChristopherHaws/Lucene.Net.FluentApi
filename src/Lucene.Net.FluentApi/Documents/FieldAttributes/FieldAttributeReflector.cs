using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class FieldAttributeReflector
	{
		//private static readonly Dictionary<Type, PropertyInfo[]> CachedProperties = new Dictionary<Type, PropertyInfo[]>();

		public IEnumerable<FieldAttributeInfoWithValue> GetFieldAttributeInfosWithValues(Type type, Object value)
		{
			return
				from property in GetProperties(type)
				from attribute in property.GetCustomAttributes<FieldAttribute>(true)
				select new FieldAttributeInfoWithValue
				{
					Name = property.Name,
					Value = property.GetValue(value, null),
					Settings = attribute
				};
		}

		public IEnumerable<FieldAttributeInfoWithValue> GetFieldAttributeInfosWithValues<T>(Object value)
		{
			return this.GetFieldAttributeInfosWithValues(typeof (T), value);
		}

		public IEnumerable<FieldAttributeInfo> GetFieldAttributeInfos(Type type, Object value)
		{
			return
				from property in GetProperties(type)
				from attribute in property.GetCustomAttributes<FieldAttribute>(true)
				select new FieldAttributeInfo
				{
					Name = property.Name,
					Settings = attribute
				};
		}

		public IEnumerable<FieldAttributeInfo> GetFieldAttributeInfos<T>(Object value)
		{
			return this.GetFieldAttributeInfos(typeof(T), value);
		}

		private static PropertyInfo[] GetProperties(Type type)
		{
			PropertyInfo[] properties;

			//if (!FieldAttributeReflector.CachedProperties.TryGetValue(type, out properties))
			{
				properties = type.GetProperties();
				//FieldAttributeReflector.CachedProperties.Add(type, properties);
			}

			return properties;
		}
	}
}