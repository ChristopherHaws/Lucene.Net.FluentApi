namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanOmitNorms<out TResult>
	{
		TResult WithoutNorms();
	}
}