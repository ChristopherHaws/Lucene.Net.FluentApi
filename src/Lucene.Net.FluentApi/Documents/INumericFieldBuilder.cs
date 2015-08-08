using System;

namespace Lucene.Net.Documents
{
	public interface INumericFieldBuilder<TValue> : IFieldBuilder
	{
		INumericFieldBuilder<TValue> Stored();

		INumericFieldBuilderIndexed<TValue> Indexed();
	}

	public interface INumericFieldBuilderIndexed<TValue> : INumericFieldBuilder<TValue>
	{
		/// <summary>
		/// You can choose any precisionStep when encoding values. Lower step values mean more precisions and so more terms in index (and index gets larger). On the other hand, the maximum number of terms to match reduces, which optimized query speed.
		/// </summary>
		INumericFieldBuilderIndexedWithPrecisionStep<TValue> WithPrecisionStep(Int32 precisionStep);

		INumericFieldBuilder<TValue> Boost(Single boost);
	}

	public interface INumericFieldBuilderIndexedWithPrecisionStep<TValue> : INumericFieldBuilder<TValue>
	{
		INumericFieldBuilder<TValue> Boost(Single boost);
	}
}