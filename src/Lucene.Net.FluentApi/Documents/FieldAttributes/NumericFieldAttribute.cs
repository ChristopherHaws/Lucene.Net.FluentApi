using System;
using Lucene.Net.Util;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class NumericFieldAttribute : BaseFieldAttribute
	{
		public NumericFieldAttribute()
		{
			this.Index = false;
			this.PrecisionStep = NumericUtils.PRECISION_STEP_DEFAULT;
		}

		public Boolean Index { get; set; }

		public Int32 PrecisionStep { get; set; }
	}
}