using System;

namespace Lucene.Net.Documents.FieldBuilders
{
	public class BooleanFieldBuilder : NumericFieldBuilder<Boolean>
	{
		public BooleanFieldBuilder(Document document, Boolean value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetIntValue(this.Value ? 1 : 0));
		}
	}
}