using System;

namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanBeBoosted<out TResult>
	{
		/// <summary>
		/// <para>Sets a boost factor for hits on any field of this document. This value will be multiplied into the score of all hits on this document.</para>
		/// <para>The default value is 1.0.</para>
		/// <para>Values are multiplied into the value of Fieldable.getBoost() of each field in this document.Thus, this method in effect sets a default boost for the fields of this document.</para>
		/// </summary>
		/// <param name="amount">The amount to boost by.</param>
		TResult BoostBy(Single amount);
	}
}