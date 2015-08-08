namespace Lucene.Net.Documents
{
	public interface IFieldStoreBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder Store();

		Field.Store ToFieldStore();
	}
}