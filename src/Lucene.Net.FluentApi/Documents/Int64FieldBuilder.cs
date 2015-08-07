using System;

namespace Lucene.Net.Documents
{
	public class Int64FieldBuilder : NumericFieldBuilder<Int64>
	{
		public Int64FieldBuilder(Document document, Int64 value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetLongValue(this.Value));
		}
	}
}