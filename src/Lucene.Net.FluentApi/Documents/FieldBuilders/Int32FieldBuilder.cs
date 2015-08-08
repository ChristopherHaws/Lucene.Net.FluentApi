using System;
using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public class Int32FieldBuilder : NumericFieldBuilder<Int32>
	{
		public Int32FieldBuilder(Document document, Int32 value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetIntValue(this.Value));
		}
	}
}