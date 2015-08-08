using System;
using Lucene.Net.Documents.FieldBuilders;

namespace Lucene.Net.Documents.FieldPropertyBuilders
{
	public class FieldCompressionBuilder<TFieldBuilder> : IFieldCompressionBuilder<TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		private readonly TFieldBuilder fieldBuilder;
		private Int32? offset;
		private Int32? length;
		private Int32? compressionLevel;

		public FieldCompressionBuilder(TFieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
		}

		public Boolean IsCompressed { get; private set; }

		public TFieldBuilder WithCompression()
		{
			this.IsCompressed = true;
			return this.fieldBuilder;
		}

		public TFieldBuilder WithCompression(Int32 compressionLevel)
		{
			this.compressionLevel = compressionLevel;
			return this.fieldBuilder;
		}

		public TFieldBuilder WithCompression(Int32 offset, Int32 length)
		{
			this.offset = offset;
			this.length = length;
			return this.fieldBuilder;
		}

		public TFieldBuilder WithCompression(Int32 offset, Int32 length, Int32 compressionLevel)
		{
			this.offset = offset;
			this.length = length;
			this.compressionLevel = compressionLevel;
			return this.fieldBuilder;
		}

		public Byte[] CompressBytes(Byte[] value)
		{
			if (!this.IsCompressed)
			{
				throw new InvalidOperationException("Field is not set to be compressed.");
			}

			if (this.compressionLevel.HasValue)
			{
				return CompressionTools.Compress(value, this.offset ?? 0, this.length ?? value.Length, this.compressionLevel.Value);
			}

			return !this.offset.HasValue && !this.length.HasValue
				? CompressionTools.Compress(value)
				: CompressionTools.Compress(value, this.offset ?? 0, this.length ?? value.Length);
		}

		public Byte[] CompressString(String value)
		{
			if (!this.IsCompressed)
			{
				throw new InvalidOperationException("Field is not set to be compressed.");
			}

			return !this.compressionLevel.HasValue
				? CompressionTools.CompressString(value)
				: CompressionTools.CompressString(value, this.compressionLevel.Value);
		}
	}
}