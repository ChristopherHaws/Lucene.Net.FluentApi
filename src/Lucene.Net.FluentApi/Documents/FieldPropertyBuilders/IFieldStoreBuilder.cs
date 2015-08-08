using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal interface IFieldStoreBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder Store();

		Field.Store ToFieldStore();
	}
}