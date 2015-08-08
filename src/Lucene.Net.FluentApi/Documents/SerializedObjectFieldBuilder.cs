using System;
using Lucene.Net.Extentions;

namespace Lucene.Net.Documents
{
	public class SerializedObjectFieldBuilder : ISerializedObjectFieldBuilder
	{
		private readonly Document document;
		private readonly Object value;
		private readonly FieldStoreBuilder<ISerializedObjectFieldBuilder> storedBuilder;

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
			this.storedBuilder = new FieldStoreBuilder<ISerializedObjectFieldBuilder>(this);
		}

		public ISerializedObjectFieldBuilder Compressed()
		{
			return this.storedBuilder.Store();
		}

		public void As(String name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			var stored = this.storedBuilder.ToFieldStore();

			var valueBytes = this.value.BinarySerialize();
			this.document.Add(new Field(name, valueBytes, stored));
		}
	}

	public interface ISerializedObjectFieldBuilder : IFieldBuilder
	{
		ISerializedObjectFieldBuilder Compressed();
	}
}