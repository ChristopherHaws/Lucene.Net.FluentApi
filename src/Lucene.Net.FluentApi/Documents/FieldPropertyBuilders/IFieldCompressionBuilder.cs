using System;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal interface IFieldCompressionBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		Boolean IsCompressed { get; }

		TFieldBuilder WithCompression();

		TFieldBuilder WithCompression(Int32 compressionLevel);

		TFieldBuilder WithCompression(Int32 offset, Int32 length);

		TFieldBuilder WithCompression(Int32 offset, Int32 length, Int32 compressionLevel);

		Byte[] CompressBytes(Byte[] value);

		Byte[] CompressString(String value);
	}
}