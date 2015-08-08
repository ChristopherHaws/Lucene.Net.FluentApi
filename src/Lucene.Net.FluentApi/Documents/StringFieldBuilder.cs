using System;

namespace Lucene.Net.Documents
{
	public class StringFieldBuilder :
		IStringFieldBuilder,
		IStringFieldBuilderStored,
        IStringFieldBuilderWithIndex,
		IStringFieldBuilderWithIndexAnalyzed,
		IStringFieldBuilderWithIndexedWithoutNorms,
        IStringFieldBuilderWithTermVector
	{
		private readonly Document document;
		private readonly String value;
		private readonly IFieldStoreBuilder<StringFieldBuilder> storeBuilder;
		private readonly IFieldIndexBuilder<StringFieldBuilder> indexBuilder;
		private readonly IFieldTermVectorBuilder<StringFieldBuilder> fieldTermVectorBuilder;
		private readonly IFieldCompressionBuilder<StringFieldBuilder> compressionBuilder;
		private readonly IFieldBoostBuilder<StringFieldBuilder> boostBuilder;

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
			this.compressionBuilder = new FieldCompressionBuilder<StringFieldBuilder>(this);
			this.boostBuilder = new FieldBoostBuilder<StringFieldBuilder>(this);
		}

		public IStringFieldBuilderStored Stored()
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

		public IStringFieldBuilderWithIndexedWithoutNorms WithoutNorms()
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

		public IStringFieldBuilder WithCompression()
		{
			return this.compressionBuilder.WithCompression();
		}

		public IStringFieldBuilder WithCompression(Int32 compressionLevel)
		{
			return this.compressionBuilder.WithCompression(compressionLevel);
		}

		public IStringFieldBuilderStored Boost(Single boost)
		{
			return this.boostBuilder.Boost(boost);
		}

		public void As(String name)
		{
			var store = this.storeBuilder.ToFieldStore();
            var index = this.indexBuilder.ToFieldIndex();
			var termVector = this.fieldTermVectorBuilder.ToTermVector();
			
			if (this.compressionBuilder.IsCompressed)
			{
				var compressedString = this.compressionBuilder.CompressString(this.value);

				var field = new Field(name, this.value, Field.Store.NO, index, termVector)
				{
					Boost = this.boostBuilder.ToBoost()
				};
				
				this.document.Add(field);
				this.document.Add(new Field(name, compressedString, Field.Store.YES));
			}
			else
			{
				var field = new Field(name, this.value, store, index, termVector)
				{
					Boost = this.boostBuilder.ToBoost()
				};

				this.document.Add(field);
			}
		}
	}
}