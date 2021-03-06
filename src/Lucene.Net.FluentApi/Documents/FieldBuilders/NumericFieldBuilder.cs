using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldPropertyBuilders;
using Lucene.Net.Util;

namespace Lucene.Net.Fluent.Documents.FieldBuilders
{
	public abstract class NumericFieldBuilder<TValue> :
		INumericFieldBuilder<TValue>,
		INumericFieldBuilderIndexed<TValue>,
		INumericFieldBuilderIndexedWithPrecisionStep<TValue>
	{
		protected readonly Document Document;
		protected readonly TValue Value;
		private Int32 precisionStep;
		private readonly StoredFieldPropertyBuilder<NumericFieldBuilder<TValue>> storeBuilder;
		private readonly IndexedFieldPropertyBuilder<NumericFieldBuilder<TValue>> indexBuilder;
		private readonly BoostFieldPropertyBuilder<NumericFieldBuilder<TValue>> boostBuilder;

		protected NumericFieldBuilder(Document document, TValue value)
		{
			this.Document = document;
			this.Value = value;
			this.precisionStep = NumericUtils.PRECISION_STEP_DEFAULT;
            this.storeBuilder = new StoredFieldPropertyBuilder<NumericFieldBuilder<TValue>>(this);
			this.indexBuilder = new IndexedFieldPropertyBuilder<NumericFieldBuilder<TValue>>(this);
			this.boostBuilder = new BoostFieldPropertyBuilder<NumericFieldBuilder<TValue>>(this);
		}

		public INumericFieldBuilder<TValue> Stored()
		{
			return this.storeBuilder.Store();
		}

		public INumericFieldBuilderIndexed<TValue> Indexed()
		{
			return this.indexBuilder.Index();
		}

		public INumericFieldBuilderIndexedWithPrecisionStep<TValue> WithPrecisionStep(Int32 precisionStep)
		{
			this.precisionStep = precisionStep;
			return this;
		}

		public INumericFieldBuilder<TValue> BoostBy(Single amount)
		{
			return this.boostBuilder.BoostBy(amount);
		}

		public abstract void As(String name);

		protected NumericField BuildField(String name)
		{
			var stored = this.storeBuilder.ToFieldStore();
			var indexed = this.indexBuilder.ToFieldIndex() != Field.Index.NO;

			var field = new NumericField(name, this.precisionStep, stored, indexed)
			{
				Boost = this.boostBuilder.ToBoost()
			};
			
			return field;
		}
	}
}