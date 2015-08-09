using ICSharpCode.SharpZipLib.Zip.Compression;

namespace Lucene.Net.Fluent.Documents.Types
{
	public enum CompressionLevel
	{
		Best = Deflater.BEST_COMPRESSION,
		BestSpeed = Deflater.BEST_SPEED,
		Deflated = Deflater.DEFLATED,
		Normal = Deflater.DEFAULT_COMPRESSION,
		None = Deflater.NO_COMPRESSION,
	}
}