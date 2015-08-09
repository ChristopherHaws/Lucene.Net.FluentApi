using Lucene.Net.Fluent.Documents.Types;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeCompressed<out TResult>
	{
		/// <summary>
		/// Compresses the entire value with the best compression level.
		/// </summary>
		TResult WithCompression();

		/// <summary>
		/// Compresses the entire value with the provided compression level.
		/// </summary>
		/// <param name="compressionLevel">The compression level</param>
		TResult WithCompression(CompressionLevel compressionLevel);
	}
}