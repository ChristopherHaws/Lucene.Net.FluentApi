namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanContainTermVectorPositionsAndOffsets<out TResult>
	{
		/// <summary>
		/// Store the token position information for the term vector.
		/// </summary>
		TResult WithPositions();

		/// <summary>
		/// Store the token offset information for the term vector.
		/// </summary>
		TResult WithOffsets();

		/// <summary>
		/// Store token position and offset information for the term vector.
		/// </summary>
		TResult WithPositionsAndOffsets();
	}
}