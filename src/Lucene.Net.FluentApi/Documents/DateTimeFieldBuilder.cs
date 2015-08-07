using System;

namespace Lucene.Net.Documents
{
	public class DateTimeFieldBuilder : NumericFieldBuilder<DateTime>
	{
		public DateTimeFieldBuilder(Document document, DateTime value) :
			base(document, value)
		{
		}

		public override void As(String name)
		{
			this.Document.Add(this.BuildField(name).SetLongValue(this.Value.Ticks));
		}
	}
}