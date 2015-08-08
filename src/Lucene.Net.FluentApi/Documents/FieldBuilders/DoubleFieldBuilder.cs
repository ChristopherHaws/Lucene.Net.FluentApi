using System;

namespace Lucene.Net.Documents.FieldBuilders
{
	public class DoubleFieldBuilder : NumericFieldBuilder<Double>
	{
		public DoubleFieldBuilder(Document document, Double value) :
			base(document, value)
		{
			this.WithPrecisionStep(8);
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetDoubleValue(this.Value));
		}
	}
}