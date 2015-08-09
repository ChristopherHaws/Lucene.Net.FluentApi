using System;
using Lucene.Net.Fluent.Documents.Types;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeCompressedWithOffsetAndLength<out TResult> : ICanBeCompressed<TResult>
	{
		/// <summary>
		/// Compresses the specified byte range with the best compression level.
		/// </summary>
		TResult WithCompression(Int32 offset, Int32 length);
		
		/// <summary>
		/// Compresses the specified byte range with the provided compression level.
		/// </summary>
		TResult WithCompression(Int32 offset, Int32 length, CompressionLevel compressionLevel);
	}
}