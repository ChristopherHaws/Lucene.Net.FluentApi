using System;
using Lucene.Net.Documents.FieldPropertyBuilders;
using Lucene.Net.Util;

namespace Lucene.Net.Documents.FieldBuilders
{
	public abstract class NumericFieldBuilder<TValue> :
		INumericFieldBuilder<TValue>,
		INumericFieldBuilderIndexed<TValue>,
		INumericFieldBuilderIndexedWithPrecisionStep<TValue>
	{
		protected readonly Document Document;
		protected readonly TValue Value;
		private Int32 precisionStep;
		private readonly IFieldStoreBuilder<NumericFieldBuilder<TValue>> storeBuilder;
		private readonly IFieldIndexBuilder<NumericFieldBuilder<TValue>> indexBuilder;
		private readonly IFieldBoostBuilder<NumericFieldBuilder<TValue>> boostBuilder;

		protected NumericFieldBuilder(Document document, TValue value)
		{
			this.Document = document;
			this.Value = value;
			this.precisionStep = NumericUtils.PRECISION_STEP_DEFAULT;
            this.storeBuilder = new FieldStoreBuilder<NumericFieldBuilder<TValue>>(this);
			this.indexBuilder = new FieldIndexBuilder<NumericFieldBuilder<TValue>>(this);
			this.boostBuilder = new FieldBoostBuilder<NumericFieldBuilder<TValue>>(this);
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

		public INumericFieldBuilder<TValue> Boost(Single boost)
		{
			return this.boostBuilder.Boost(boost);
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