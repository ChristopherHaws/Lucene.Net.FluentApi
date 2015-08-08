using System;

namespace Lucene.Net.Documents.FieldBuilders
{
	public class DateTimeFieldBuilder : NumericFieldBuilder<DateTime>
	{
		public DateTimeFieldBuilder(Document document, DateTime value) :
			base(document, value)
		{
			this.WithPrecisionStep(8);
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetLongValue(this.Value.Ticks));
		}
	}
}