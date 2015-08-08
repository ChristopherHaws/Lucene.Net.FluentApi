using Lucene.Net.Documents.FieldBuilders;

namespace Lucene.Net.Documents.FieldPropertyBuilders
{
	public interface IFieldStoreBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder Store();

		Field.Store ToFieldStore();
	}
}