using System;
using System.Linq;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal class FieldIndexBuilder<TFieldBuilder> : IFieldIndexBuilder<TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		private readonly TFieldBuilder fieldBuilder;

		private Field.Index index;

		public FieldIndexBuilder(TFieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
			this.index = Field.Index.NO;
		}

		public TFieldBuilder Index()
		{
			if (this.index != Field.Index.NO)
			{
				throw new InvalidOperationException("Field is already set to be indexed.");
			}

			this.index = Field.Index.NOT_ANALYZED;

			return this.fieldBuilder;
		}

		public TFieldBuilder Analyzed()
		{
			if (this.index != Field.Index.NOT_ANALYZED)
			{
				throw new InvalidOperationException("Field must be indexed to be analyzed.");
			}

			this.index = Field.Index.ANALYZED;

			return this.fieldBuilder;
		}

		public TFieldBuilder WithoutNorms()
		{
			if (!new[] { Field.Index.ANALYZED, Field.Index.NOT_ANALYZED }.Contains(this.index))
			{
				throw new InvalidOperationException("Field must be indexed to omit norms.");
			}

			this.index = this.index == Field.Index.ANALYZED
				? Field.Index.ANALYZED_NO_NORMS
				: Field.Index.NOT_ANALYZED_NO_NORMS;

			return this.fieldBuilder;
		}

		public Field.Index ToFieldIndex()
		{
			return this.index;
		}
	}
}