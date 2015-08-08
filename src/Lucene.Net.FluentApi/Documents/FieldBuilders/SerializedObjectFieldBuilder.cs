using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldProperties;
using Lucene.Net.Fluent.Documents.FieldPropertyBuilders;
using Lucene.Net.Fluent.Extentions;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public class SerializedObjectFieldBuilder : ISerializedObjectFieldBuilder
	{
		private readonly Document document;
		private readonly Object value;
		private readonly CompressionFieldPropertyBuilder<ISerializedObjectFieldBuilder> compressionBuilder;

		public SerializedObjectFieldBuilder(Document document, Object value)
		{
			if (document == null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			this.document = document;
			this.value = value;
			this.compressionBuilder = new CompressionFieldPropertyBuilder<ISerializedObjectFieldBuilder>(this);
		}

		public ISerializedObjectFieldBuilder WithCompression()
		{
			return this.compressionBuilder.WithCompression();
		}

		public ISerializedObjectFieldBuilder WithCompression(CompressionLevel compressionLevel)
		{
			return this.compressionBuilder.WithCompression(compressionLevel);
		}

		public ISerializedObjectFieldBuilder WithCompression(Int32 offset, Int32 length)
		{
			return this.compressionBuilder.WithCompression(offset, length);
		}

		public ISerializedObjectFieldBuilder WithCompression(Int32 offset, Int32 length, CompressionLevel compressionLevel)
		{
			return this.compressionBuilder.WithCompression(offset, length, compressionLevel);
		}

		public void As(String name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			var valueBytes = this.value.BinarySerialize();

			if (this.compressionBuilder.IsCompressed)
			{
				valueBytes = this.compressionBuilder.CompressBytes(valueBytes);
			}
			
			this.document.Add(new Field(name, valueBytes, Field.Store.YES));
		}
	}
}