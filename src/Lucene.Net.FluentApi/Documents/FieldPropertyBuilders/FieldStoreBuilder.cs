using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal class FieldStoreBuilder<TFieldBuilder> : IFieldStoreBuilder<TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		private readonly TFieldBuilder fieldBuilder;

		private Field.Store store;

		public FieldStoreBuilder(TFieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
			this.store = Field.Store.NO;
		}

		public TFieldBuilder Store()
		{
			if (this.store == Field.Store.YES)
			{
				throw new InvalidOperationException("Field is already set to be stored.");
			}

			this.store = Field.Store.YES;

			return this.fieldBuilder;
		}

		public Field.Store ToFieldStore()
		{
			return this.store;
		}
	}
}