using System;
using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public class Int64FieldBuilder : NumericFieldBuilder<Int64>
	{
		public Int64FieldBuilder(Document document, Int64 value) :
			base(document, value)
		{
			this.WithPrecisionStep(8);
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetLongValue(this.Value));
		}
	}
}