namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeIndexed<out TResult>
	{
		/// <summary>
		/// Index the field's value so it can be searched. If the field is not analyzed, then the value will be stored as a single term. This is useful for unique Ids like product numbers.
		/// </summary>
		TResult Indexed();
	}
}