using System;
using Lucene.Net.Documents.FieldBuilders;

namespace Lucene.Net.Documents.FieldPropertyBuilders
{
	public interface IFieldBoostBuilder<out TFieldBuilder>
		where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder Boost(Single boost);

		Single ToBoost();
	}
}