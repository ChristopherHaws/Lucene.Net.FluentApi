using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lucene.Net.Extentions;

namespace Lucene.Net.Documents
{
	public class FieldBuilder
	{
		private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

		private readonly Document document;
		private readonly String name;
		private Field.Store store;
		private Field.Index index;

		public FieldBuilder(Document document, String name)
		{
			if (document == null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Value must not be null or whitespace", nameof(name));
			}

			this.document = document;
			this.name = name;
			this.store = Field.Store.NO;
			this.index = Field.Index.NO;
		}

		public FieldBuilder Stored()
		{
			this.store = Field.Store.YES;
			return this;
		}

		public FieldBuilder Indexed(Boolean analyzed = false, Boolean norms = false)
		{
			if(analyzed)
			{
				this.index = norms ? Field.Index.ANALYZED : Field.Index.ANALYZED_NO_NORMS;
			}
			else
			{
				this.index = norms ? Field.Index.NOT_ANALYZED : Field.Index.NOT_ANALYZED_NO_NORMS;
			}

			return this;
		}
		
		public void Value(String value)
		{
			this.document.Add(new Field(this.name, value, this.store, this.index));
		}

		public void Value(Int32 value)
		{
			this.document.Add(new NumericField(this.name, this.store, this.index != Field.Index.NO).SetIntValue(value));
		}

		public void Value(Int64 value)
		{
			this.document.Add(new NumericField(this.name, this.store, this.index != Field.Index.NO).SetLongValue(value));
		}

		public void Value(Single value)
		{
			this.document.Add(new NumericField(this.name, this.store, this.index != Field.Index.NO).SetFloatValue(value));
		}

		public void Value(Double value)
		{
			this.document.Add(new NumericField(this.name, this.store, this.index != Field.Index.NO).SetDoubleValue(value));
		}

		public void Value(Boolean value)
		{
			this.Value(value ? 1 : 0);
		}

		public void Value(DateTime value)
		{
			this.Value(value.Ticks);
		}

		public void SerializedValue(Object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			var valueBytes = value.BinarySerialize();
			this.document.Add(new Field(this.name, valueBytes, Field.Store.YES));
		}
	}
}