using System;
using System.Linq;

namespace Lucene.Net.Documents
{
	public class StringFieldBuilder
	{
		private readonly Document document;
		private readonly String value;
		private Field.Store store;
		private Field.Index index;

		public StringFieldBuilder(Document document, String value)
		{
			if (document == null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (String.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Value must not be null or whitespace", nameof(value));
			}

			this.document = document;
			this.value = value;
			this.store = Field.Store.NO;
			this.index = Field.Index.NO;
		}

		public StringFieldBuilder Store()
		{
			if (this.store == Field.Store.YES)
			{
				throw new InvalidOperationException("Value is already set to be stored.");
			}

			this.store = Field.Store.YES;

			return this;
		}
		
		public StringFieldBuilder Index()
		{
			if (this.index != Field.Index.NO)
			{
				throw new InvalidOperationException("Value is already set to be indexed.");
			}

			this.index = Field.Index.NOT_ANALYZED;

			return this;
		}

		public StringFieldBuilder Analyze()
		{
			if (this.index == Field.Index.NO)
			{
				throw new InvalidOperationException("Value must be indexed to be analyzed.");
			}

			if (new[] { Field.Index.ANALYZED, Field.Index.ANALYZED_NO_NORMS }.Contains(this.index))
			{
				throw new InvalidOperationException("Value is already set to be analyzed.");
			}

			this.index = Field.Index.ANALYZED;

			return this;
		}

		public StringFieldBuilder OmitNorms()
		{
			if (!new[] { Field.Index.ANALYZED, Field.Index.NOT_ANALYZED }.Contains(this.index))
			{
				throw new InvalidOperationException("Value must be indexed to omit norms.");
			}

			this.index = this.index == Field.Index.ANALYZED
				? Field.Index.ANALYZED_NO_NORMS
				: Field.Index.NOT_ANALYZED_NO_NORMS;

			return this;
		}

		public void As(String name)
		{
			this.document.Add(new Field(name, this.value, this.store, this.index));
		}
	}
}