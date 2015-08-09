using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.Types
{
	public enum TermVectorMode
	{
		No = Field.TermVector.NO,
		Yes = Field.TermVector.YES,
		WithOffsets = Field.TermVector.WITH_OFFSETS,
		WithPositions = Field.TermVector.WITH_POSITIONS,
		WithPositionsAndOffsets = Field.TermVector.WITH_POSITIONS_OFFSETS
	}
}