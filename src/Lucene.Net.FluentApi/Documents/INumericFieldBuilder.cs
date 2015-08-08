namespace Lucene.Net.Documents
{
	public interface INumericFieldBuilder<TValue> : IFieldBuilder
	{
		INumericFieldBuilder<TValue> Stored();

		INumericFieldBuilderIndexed<TValue> Indexed();
	}
}