using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lucene.Net.Fluent.Documents.FieldAttributes;
using Xunit;

namespace Lucene.Net.FluentApi.Tests.AddFieldByAttributes
{
    public class WhenIAddAStringFieldByAttribute
    {
		[Fact]
	    public void Foo()
	    {
			var foo = new ClassWithFieldAttributes
			{
				FieldOne = "Test"
			};

			var fieldAttributeReflector = new FieldAttributeReflector();

			var infos = fieldAttributeReflector.GetFieldAttributeInfosWithValues<ClassWithFieldAttributes>(foo);

			foreach (var info in infos)
			{
				Assert.Equal("FieldOne", info.Name);
				Assert.Equal("Test", info.Value as String);
				Assert.Equal(true, info.Settings.Store);
			}
	    }
    }

	public class FieldAttributeBuilder<T>
	{
		public void AddFields(Object value)
		{
			
		}
	}

	public class FieldAttributeReflector
	{
		private static readonly Dictionary<Type, PropertyInfo[]> CachedProperties = new Dictionary<Type, PropertyInfo[]>();

		public IEnumerable<FieldAttributeInfoWithValue> GetFieldAttributeInfosWithValues(Type type, Object value)
		{
			PropertyInfo[] properties;

			if (!FieldAttributeReflector.CachedProperties.TryGetValue(type, out properties))
			{
				properties = type.GetProperties();
				FieldAttributeReflector.CachedProperties.Add(type, properties);
            }

			return
				from property in properties
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
			var properties = type.GetProperties();

			return
				from property in properties
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
	}

	public static class PropertyInfoExtentions
	{
		public static IEnumerable<T> GetCustomAttributes<T>(this PropertyInfo property, bool inherit) where T : class
		{
			return
				from attribute in property.GetCustomAttributes(typeof (FieldAttribute), true)
				let fieldAttribute = attribute as T
				where fieldAttribute != null
				select fieldAttribute;
		}
    }


	public class FieldAttributeInfo
	{
		public String Name { get; set; }

		public FieldAttribute Settings { get; set; }
	}

	public class FieldAttributeInfoWithValue : FieldAttributeInfo
	{
		public Object Value { get; set; }
	}

	public class ClassWithFieldAttributes
	{
		[Field(IndexMode = IndexMode.Analyzed, Store = true)]
		public String FieldOne { get; set; }
	}
}
