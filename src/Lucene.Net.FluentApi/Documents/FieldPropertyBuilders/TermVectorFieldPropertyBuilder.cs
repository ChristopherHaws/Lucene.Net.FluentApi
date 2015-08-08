using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal class TermVectorFieldPropertyBuilder<TFieldBuilder>
		where TFieldBuilder : IFieldBuilder
	{
		private readonly TFieldBuilder fieldBuilder;
		private Field.TermVector termVectorType;
		
		public TermVectorFieldPropertyBuilder(TFieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
			this.termVectorType = Field.TermVector.NO;
		}

		public TFieldBuilder WithTermVector()
		{
			if (this.termVectorType != Field.TermVector.NO)
			{
				throw new InvalidOperationException("Field is already set to store term vectors.");
			}

			this.termVectorType = Field.TermVector.YES;

			return this.fieldBuilder;
		}

		public TFieldBuilder WithPositions()
		{
			if (this.termVectorType != Field.TermVector.YES)
			{
				throw new InvalidOperationException("Field must be set to store term vectors.");
			}

			this.termVectorType = Field.TermVector.WITH_POSITIONS;

			return this.fieldBuilder;
		}

		public TFieldBuilder WithOffsets()
		{
			if (this.termVectorType != Field.TermVector.YES)
			{
				throw new InvalidOperationException("Field must be set to store term vectors.");
			}

			this.termVectorType = Field.TermVector.WITH_OFFSETS;

			return this.fieldBuilder;
		}

		public TFieldBuilder WithPositionsAndOffsets()
		{
			if (this.termVectorType != Field.TermVector.YES)
			{
				throw new InvalidOperationException("Field must be set to store term vectors.");
			}

			this.termVectorType = Field.TermVector.WITH_POSITIONS_OFFSETS;

			return this.fieldBuilder;
		}

		public Field.TermVector ToTermVector()
		{
			return this.termVectorType;
		}
	}
}