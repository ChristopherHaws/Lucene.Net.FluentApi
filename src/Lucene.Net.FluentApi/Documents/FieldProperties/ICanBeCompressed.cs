using System;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeCompressed<out TResult>
	{
		TResult WithCompression();

		TResult WithCompression(Int32 compressionLevel);
	}
}