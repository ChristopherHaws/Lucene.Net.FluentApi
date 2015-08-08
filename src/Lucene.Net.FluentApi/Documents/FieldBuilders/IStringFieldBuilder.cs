using System;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public interface IStringFieldBuilder : IFieldBuilder
	{
		IStringFieldBuilderStored Stored();

		IStringFieldBuilderWithIndex Indexed();

		/// <summary>
		/// Stores the term vectors of the document. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		IStringFieldBuilderWithTermVector WithTermVector();
	}

	public interface IStringFieldBuilderStored : IStringFieldBuilder
	{

		IStringFieldBuilder WithCompression();

		IStringFieldBuilder WithCompression(Int32 compressionLevel);
	}

	public interface IStringFieldBuilderWithIndex : IStringFieldBuilder
	{
		IStringFieldBuilderWithIndexAnalyzed Analyzed();

		IStringFieldBuilderWithIndexedWithoutNorms WithoutNorms();

		IStringFieldBuilderStored BoostBy(Single amount);
	}

	public interface IStringFieldBuilderWithIndexAnalyzed : IStringFieldBuilder
	{
		IStringFieldBuilderWithIndexedWithoutNorms WithoutNorms();

		IStringFieldBuilderStored BoostBy(Single amount);
	}

	public interface IStringFieldBuilderWithIndexedWithoutNorms : IStringFieldBuilder
	{
		IStringFieldBuilderStored BoostBy(Single amount);
	}

	public interface IStringFieldBuilderWithTermVector : IStringFieldBuilder
	{
		/// <summary>
		/// Store the token position information for the term vector.
		/// </summary>
		IStringFieldBuilder WithPositions();

		/// <summary>
		/// Store the token offset information for the term vector.
		/// </summary>
		IStringFieldBuilder WithOffsets();

		/// <summary>
		/// Store token position and offset information for the term vector.
		/// </summary>
		IStringFieldBuilder WithPositionsAndOffsets();
	}
}