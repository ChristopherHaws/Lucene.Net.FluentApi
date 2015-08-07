using System;

namespace Lucene.Net.Documents
{
	public class DoubleFieldBuilder : NumericFieldBuilder<Double>
	{
		public DoubleFieldBuilder(Document document, Double value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetDoubleValue(this.Value));
		}
	}
}