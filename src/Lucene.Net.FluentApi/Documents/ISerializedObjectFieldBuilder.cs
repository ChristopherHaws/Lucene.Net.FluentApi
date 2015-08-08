using System;

namespace Lucene.Net.Documents
{
	public interface ISerializedObjectFieldBuilder : IFieldBuilder
	{
		ISerializedObjectFieldBuilder WithCompression();

		ISerializedObjectFieldBuilder WithCompression(Int32 compressionLevel);

		ISerializedObjectFieldBuilder WithCompression(Int32 offset, Int32 length);

		ISerializedObjectFieldBuilder WithCompression(Int32 offset, Int32 length, Int32 compressionLevel);
	}
}