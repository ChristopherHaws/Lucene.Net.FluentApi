using System;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class FieldAttributeInfo<TAttribute> where TAttribute : BaseFieldAttribute
	{
		public String Name { get; set; }

		public TAttribute Settings { get; set; }
	}
}