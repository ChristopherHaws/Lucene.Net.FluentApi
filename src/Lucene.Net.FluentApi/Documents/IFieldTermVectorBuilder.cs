namespace Lucene.Net.Documents
{
	public interface IFieldTermVectorBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		/// <summary>
		/// Stores the term vectors of the document. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		TFieldBuilder WithTermVector();

		/// <summary>
		/// Store the term vector and token position information. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		TFieldBuilder WithPositions();

		/// <summary>
		/// Store the term vector and token offset information. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		TFieldBuilder WithOffsets();

		/// <summary>
		/// Store the term vector and token position and offset information. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		TFieldBuilder WithPositionsAndOffsets();

		/// <summary>
		/// Builds the TermVector
		/// </summary>
		Field.TermVector ToTermVector();
	}
}