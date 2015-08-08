using System;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeBoosted<out TResult>
	{
		TResult BoostBy(Single amount);
	}
}