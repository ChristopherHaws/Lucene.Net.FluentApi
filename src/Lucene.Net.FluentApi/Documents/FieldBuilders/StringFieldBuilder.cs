using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldPropertyBuilders;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
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
		private readonly StoredFieldPropertyBuilder<StringFieldBuilder> storeBuilder;
		private readonly IndexedFieldPropertyBuilder<StringFieldBuilder> indexBuilder;
		private readonly TermVectorFieldPropertyBuilder<StringFieldBuilder> termVectorFieldPropertyBuilder;
		private readonly CompressionFieldPropertyBuilder<StringFieldBuilder> compressionBuilder;
		private readonly BoostFieldPropertyBuilder<StringFieldBuilder> boostBuilder;

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

			this.storeBuilder = new StoredFieldPropertyBuilder<StringFieldBuilder>(this);
			this.indexBuilder = new IndexedFieldPropertyBuilder<StringFieldBuilder>(this);
			this.termVectorFieldPropertyBuilder = new TermVectorFieldPropertyBuilder<StringFieldBuilder>(this);
			this.compressionBuilder = new CompressionFieldPropertyBuilder<StringFieldBuilder>(this);
			this.boostBuilder = new BoostFieldPropertyBuilder<StringFieldBuilder>(this);
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
			return this.termVectorFieldPropertyBuilder.WithTermVector();
		}

		public IStringFieldBuilder WithPositions()
		{
			return this.termVectorFieldPropertyBuilder.WithPositions();
		}

		public IStringFieldBuilder WithOffsets()
		{
			return this.termVectorFieldPropertyBuilder.WithOffsets();
		}

		public IStringFieldBuilder WithPositionsAndOffsets()
		{
			return this.termVectorFieldPropertyBuilder.WithPositionsAndOffsets();
		}

		public IStringFieldBuilder WithCompression()
		{
			return this.compressionBuilder.WithCompression();
		}

		public IStringFieldBuilder WithCompression(Int32 compressionLevel)
		{
			return this.compressionBuilder.WithCompression(compressionLevel);
		}

		public IStringFieldBuilderStored BoostBy(Single amount)
		{
			return this.boostBuilder.BoostBy(amount);
		}

		public void As(String name)
		{
			var store = this.storeBuilder.ToFieldStore();
            var index = this.indexBuilder.ToFieldIndex();
			var termVector = this.termVectorFieldPropertyBuilder.ToTermVector();
			
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