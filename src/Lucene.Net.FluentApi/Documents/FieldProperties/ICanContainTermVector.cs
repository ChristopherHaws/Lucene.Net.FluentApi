namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanContainTermVector<out TResult>
	{
		/// <summary>
		/// Stores the term vectors of the document. A term vector is a list of the document's terms and their number of occurrences in that document
		/// </summary>
		TResult WithTermVector();
	}
}