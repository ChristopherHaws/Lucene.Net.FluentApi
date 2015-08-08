using System;

namespace Lucene.Net.Documents
{
	public class StringFieldBuilder :
		IStringFieldBuilder,
		IStringFieldBuilderWithIndex,
		IStringFieldBuilderWithIndexAnalyzed,
        IStringFieldBuilderWithTermVector
	{
		private readonly Document document;
		private readonly String value;
		private readonly IFieldStoreBuilder<StringFieldBuilder> storeBuilder;
		private readonly IFieldIndexBuilder<StringFieldBuilder> indexBuilder;
		private readonly IFieldTermVectorBuilder<StringFieldBuilder> fieldTermVectorBuilder;

		public StringFieldBuilder(Document document, String value)
		{
			if (document == null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (String.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Field must not be null or whitespace.", nameof(value));
			}

			this.document = document;
			this.value = value;

			this.storeBuilder = new FieldStoreBuilder<StringFieldBuilder>(this);
			this.indexBuilder = new FieldIndexBuilder<StringFieldBuilder>(this);
			this.fieldTermVectorBuilder = new FieldTermVectorBuilder<StringFieldBuilder>(this);
		}

		public IStringFieldBuilder Stored()
		{
			return this.storeBuilder.Store();
		}
		
		public IStringFieldBuilderWithIndex Indexed()
		{
			return this.indexBuilder.Index();
		}

		public IStringFieldBuilderWithIndexAnalyzed Analyzed()
		{
			return this.indexBuilder.Analyzed();
		}

		public IStringFieldBuilder WithoutNorms()
		{
			return this.indexBuilder.WithoutNorms();
		}
		
		public IStringFieldBuilderWithTermVector WithTermVector()
		{
			return this.fieldTermVectorBuilder.WithTermVector();
		}

		public IStringFieldBuilder WithPositions()
		{
			return this.fieldTermVectorBuilder.WithPositions();
		}

		public IStringFieldBuilder WithOffsets()
		{
			return this.fieldTermVectorBuilder.WithOffsets();
		}

		public IStringFieldBuilder WithPositionsAndOffsets()
		{
			return this.fieldTermVectorBuilder.WithPositionsAndOffsets();
		}

		public void As(String name)
		{
			var store = this.storeBuilder.ToFieldStore();
            var index = this.indexBuilder.ToFieldIndex();
			var termVector = this.fieldTermVectorBuilder.ToTermVector();
			
			this.document.Add(new Field(name, this.value, store, index, termVector));
		}
	}
}