using System;

namespace Lucene.Net.Documents.FieldBuilders
{
	public class SingleFieldBuilder : NumericFieldBuilder<Single>
	{
		public SingleFieldBuilder(Document document, Single value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetFloatValue(this.Value));
		}
	}
}