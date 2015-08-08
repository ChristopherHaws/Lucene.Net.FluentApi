namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeStored<out TResult>
	{
		/// <summary>
		/// A field whose value is stored so that IndexSearcher's and IndexReader's will return the field and its value.
		/// </summary>
		TResult Stored();
	}
}