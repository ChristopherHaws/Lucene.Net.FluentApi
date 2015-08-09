using System;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class FieldAttributeInfoWithValue<TAttribute> : FieldAttributeInfo<TAttribute> where TAttribute : BaseFieldAttribute
	{
		public Object Value { get; set; }
	}
}