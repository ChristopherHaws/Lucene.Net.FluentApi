namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeAnalyzed<out TResult>
	{
		/// <summary>
		/// Index the tokens produced by running the field's value through an Analyzer. This is useful for common text.
		/// </summary>
		TResult Analyzed();
	}
}