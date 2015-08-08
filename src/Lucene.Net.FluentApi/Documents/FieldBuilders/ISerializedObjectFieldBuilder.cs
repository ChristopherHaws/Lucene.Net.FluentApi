using Lucene.Net.Fluent.Documents.FieldProperties;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public interface ISerializedObjectFieldBuilder :
		IFieldBuilder,
		ICanBeCompressedWithOffsetAndLength<ISerializedObjectFieldBuilder>
	{
	}
}