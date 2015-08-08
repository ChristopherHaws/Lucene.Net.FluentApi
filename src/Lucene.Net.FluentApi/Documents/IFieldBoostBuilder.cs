using System;

namespace Lucene.Net.Documents
{
	public interface IFieldBoostBuilder<out TFieldBuilder>
		where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder Boost(Single boost);

		Single ToBoost();
	}
}