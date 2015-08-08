namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeIndexed<out TResult>
	{
		TResult Indexed();
	}
}