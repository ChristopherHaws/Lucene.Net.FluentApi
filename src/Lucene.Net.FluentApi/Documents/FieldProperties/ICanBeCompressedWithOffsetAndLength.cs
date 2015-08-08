using System;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeCompressedWithOffsetAndLength<out TResult> : ICanBeCompressed<TResult>
	{
		TResult WithCompression(Int32 offset, Int32 length);

		TResult WithCompression(Int32 offset, Int32 length, Int32 compressionLevel);
	}
}