using System;

namespace Lucene.Net.Documents
{
	public interface IStringFieldBuilder : IFieldBuilder
	{
		IStringFieldBuilderStored Stored();

		IStringFieldBuilderWithIndex Indexed();

		/// <summary>
		/// Stores the term vectors of the document. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		IStringFieldBuilderWithTermVector WithTermVector();

		IStringFieldBuilderStored Boost(Single boost);
	}

	public interface IStringFieldBuilderStored : IStringFieldBuilder
	{

		IStringFieldBuilder WithCompression();

		IStringFieldBuilder WithCompression(Int32 compressionLevel);
	}

	public interface IStringFieldBuilderWithIndex : IStringFieldBuilder
	{
		IStringFieldBuilderWithIndexAnalyzed Analyzed();

		IStringFieldBuilder WithoutNorms();
	}

	public interface IStringFieldBuilderWithIndexAnalyzed : IStringFieldBuilder
	{
		IStringFieldBuilder WithoutNorms();
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