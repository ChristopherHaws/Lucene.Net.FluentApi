using Lucene.Net.Fluent.Documents.FieldProperties;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public interface IStringFieldBuilder :
		IFieldBuilder,
		ICanBeStored<IStringFieldBuilderStored>,
		ICanBeIndexed<IStringFieldBuilderWithIndex>,
		ICanContainTermVector<IStringFieldBuilderWithTermVector>
	{
	}

	public interface IStringFieldBuilderStored :
		IStringFieldBuilder,
		ICanBeCompressed<IStringFieldBuilder>
	{
	}

	public interface IStringFieldBuilderWithIndex :
		IStringFieldBuilder,
		ICanBeBoosted<IStringFieldBuilderStored>,
		ICanBeAnalyzed<IStringFieldBuilderWithIndexAnalyzed>,
		ICanOmitNorms<IStringFieldBuilderWithIndexedWithoutNorms>
	{
	}

	public interface IStringFieldBuilderWithIndexAnalyzed :
		IStringFieldBuilder,
		ICanBeBoosted<IStringFieldBuilderStored>,
		ICanOmitNorms<IStringFieldBuilderWithIndexedWithoutNorms>
	{
	}

	public interface IStringFieldBuilderWithIndexedWithoutNorms :
		IStringFieldBuilder,
		ICanBeBoosted<IStringFieldBuilderStored>
	{
	}

	public interface IStringFieldBuilderWithTermVector :
		ICanContainTermVectorPositionsAndOffsets<IStringFieldBuilder>
	{
	}
}