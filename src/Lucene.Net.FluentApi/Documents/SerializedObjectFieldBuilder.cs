using System;
using Lucene.Net.Extentions;

namespace Lucene.Net.Documents
{
	public class SerializedObjectFieldBuilder
	{
		private readonly Document document;
		private readonly Object value;

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
		}

		public void As(String name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			var valueBytes = this.value.BinarySerialize();
			this.document.Add(new Field(name, valueBytes, Field.Store.YES));
		}
	}
}