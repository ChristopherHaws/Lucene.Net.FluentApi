using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

		public void Value(DateTime value)
		{
			this.Value(value.Ticks);
		}

		public void Value(Object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			if (string.IsNullOrWhiteSpace(this.name))
			{
				throw new ArgumentException("fieldName must not be null or whitespace", "fieldName");
			}

			byte[] valueBytes = BinarySerialize(value);
			doc.Add(new Field(fieldName, valueBytes, Field.Store.YES));
			return doc;
		}
		
		private byte[] BinarySerialize(object input)
		{
			if (input == null)
			{
				return null;
			}

			using (var stream = new MemoryStream())
			{
				BinaryFormatter.Serialize(stream, input);
				return stream.ToArray();
			}
		}
		
		private T BinaryDeserialize<T>(byte[] input)
		{
			if (input == null)
			{
				return default(T);
			}

			using (var ms = new MemoryStream(input))
			{
				var value = BinaryFormatter.Deserialize(ms);
				if (value is T)
				{
					return (T)value;
				}

				return default(T);
			}
		}
	}
}