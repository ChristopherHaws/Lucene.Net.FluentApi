using System;
using Lucene.Net.Util;

namespace Lucene.Net.Documents
{
	public abstract class NumericFieldBuilder<TValue> :
		INumericFieldBuilder<TValue>,
		INumericFieldBuilderIndexed<TValue>
	{
		protected readonly Document Document;
		protected readonly TValue Value;
		private Int32 precisionStep;
		private readonly IFieldStoreBuilder<NumericFieldBuilder<TValue>> storeBuilder;
		private readonly IFieldIndexBuilder<NumericFieldBuilder<TValue>> indexBuilder;

		protected NumericFieldBuilder(Document document, TValue value)
		{
			this.Document = document;
			this.Value = value;
			this.precisionStep = NumericUtils.PRECISION_STEP_DEFAULT;
            this.storeBuilder = new FieldStoreBuilder<NumericFieldBuilder<TValue>>(this);
			this.indexBuilder = new FieldIndexBuilder<NumericFieldBuilder<TValue>>(this);
		}

		public INumericFieldBuilder<TValue> Stored()
		{
			return this.storeBuilder.Store();
		}

		public INumericFieldBuilderIndexed<TValue> Indexed()
		{
			return this.indexBuilder.Index();
		}

		public INumericFieldBuilder<TValue> WithPrecisionStep(Int32 precisionStep)
		{
			this.precisionStep = precisionStep;
			return this;
		}

		public abstract void As(String name);

		protected NumericField BuildField(String name)
		{
			var stored = this.storeBuilder.ToFieldStore();
			var indexed = this.indexBuilder.ToFieldIndex() != Field.Index.NO;

			return new NumericField(name, this.precisionStep, stored, indexed);
        }
	}
}