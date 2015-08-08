using System;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal interface IFieldBoostBuilder<out TFieldBuilder>
		where TFieldBuilder : IFieldBuilder
	{
		TFieldBuilder BoostBy(Single amount);

		Single ToBoost();
	}
}