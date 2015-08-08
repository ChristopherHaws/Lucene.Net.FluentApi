namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeAnalyzed<out TResult>
	{
		TResult Analyzed();
	}
}