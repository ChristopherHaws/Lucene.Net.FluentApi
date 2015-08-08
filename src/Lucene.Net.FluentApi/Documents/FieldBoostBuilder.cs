using System;

namespace Lucene.Net.Documents
{
	public class FieldBoostBuilder<TFieldBuilder> :
		IFieldBoostBuilder<TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		private readonly TFieldBuilder fieldBuilder;
		private Single? boost;

		public FieldBoostBuilder(TFieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
		}

		public TFieldBuilder Boost(Single boost)
		{
			this.boost = boost;
			return this.fieldBuilder;
		}

		public Single ToBoost()
		{
			return this.boost ?? 1.0f;
		}
	}
}