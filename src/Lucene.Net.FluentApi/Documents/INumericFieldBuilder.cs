using System;

namespace Lucene.Net.Documents
{
	public interface INumericFieldBuilder<TValue> : IFieldBuilder
	{
		INumericFieldBuilder<TValue> Stored();

		INumericFieldBuilderIndexed<TValue> Indexed();

		INumericFieldBuilder<TValue> Boost(Single boost);
	}
}