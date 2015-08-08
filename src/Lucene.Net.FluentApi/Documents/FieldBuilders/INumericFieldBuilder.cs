using Lucene.Net.Fluent.Documents.FieldProperties;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public interface INumericFieldBuilder<TValue> :
		IFieldBuilder,
		ICanBeStored<INumericFieldBuilder<TValue>>,
		ICanBeIndexed<INumericFieldBuilderIndexed<TValue>>
	{
	}

	public interface INumericFieldBuilderIndexed<TValue> :
		INumericFieldBuilder<TValue>,
		ICanContainPrecisionStep<INumericFieldBuilderIndexedWithPrecisionStep<TValue>>,
        ICanBeBoosted<INumericFieldBuilder<TValue>>
    {
	}

	public interface INumericFieldBuilderIndexedWithPrecisionStep<TValue> :
		INumericFieldBuilder<TValue>,
		ICanBeBoosted<INumericFieldBuilder<TValue>>
	{
	}
}